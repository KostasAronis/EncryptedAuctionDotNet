using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using EncryptedAuctionAggregator.Database.DBModels;

namespace EncryptedAuctionAggregator.Database
{
    public static class Seeder
    {
        public static void Seedit(string jsonData, DBContext context)
        {
            if (!context.LSHConfigs.Any())
            {
                context.LSHConfigs.Add(new LSHConfig()
                {
                    Id = Guid.NewGuid(),
                    LSHHashSeed = LSHDotNet.MinHasher<Guid>.CreateMinHashSeeds(100)
                });
            }
            List<Store> products = JsonConvert.DeserializeObject<List<Store>>(jsonData);
            if (!context.Stores.Any())
            {
                context.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
