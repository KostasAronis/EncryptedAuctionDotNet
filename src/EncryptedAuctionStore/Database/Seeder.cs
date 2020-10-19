using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using EncryptedAuctionStore.Database.DBModels;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EncryptedAuctionStore.Database
{

    //TODO: FIX BEFORE MULTIPLE STORES, WILL HELP WITH DEMO SEEDING
    public static class Seeder
    {
        public static void Seedit(Registrator reg, string jsonData, DBContext context)
        {
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonData);
            if (!context.Products.Any())
            {
                try
                {
                    context.AddRange(products);
                    var tries = 3;
                    while (tries > 0)
                    {
                        tries -= 1;
                        try
                        {
                            reg.Register(products);
                            context.SaveChanges();
                            return;
                        }
                        catch(Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
