using EncryptedAuctionStore.Database.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionStore.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContextOptions)
            : base(dbContextOptions)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
