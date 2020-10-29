using EncryptedAuctionAggregator.Database.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionAggregator.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Store> Stores { get; set; }
        public DbSet<HashedProduct> HashedProducts { get; set; }
        public DbSet<LSHConfig> LSHConfigs { get; set; }
        public LSHConfig LSHConfig
        {
            get
            {
                return LSHConfigs.FirstOrDefault();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasMany(s => s.HashedProducts)
                .WithOne(p => p.Store)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LSHConfig>()
                .Property(l => l.LSHHashSeed)
                .HasConversion(Converters.IntArrayArrayConverter);
            modelBuilder.Entity<HashedProduct>()
                .Property(h => h.Hashes)
                .HasConversion(Converters.IntArrayArrayConverter);
            modelBuilder.Entity<HashedProduct>()
                .Property(h => h.Weights)
                .HasConversion(Converters.DoubleArrayConverter);
        }
    }
    public static class Converters
    {
        public static ValueConverter IntArrayArrayConverter = new ValueConverter<int[][], string>(
        a => string.Join(";", a.Select(vv => string.Join(',', vv))),
        s => s.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(vv => vv.Split(",", StringSplitOptions.RemoveEmptyEntries)).Select(vvv => vvv.Select(vvvv => int.Parse(vvvv)).ToArray()).ToArray());

        public static ValueConverter IntArrayConverter = new ValueConverter<int[], string>(
                a => string.Join(",", a),
                s => s.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(vv => int.Parse(vv)).ToArray());

        public static ValueConverter DoubleArrayConverter = new ValueConverter<double[], string>(
        a => string.Join(",", a),
        s => s.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(vv => double.Parse(vv)).ToArray());
    }
}
