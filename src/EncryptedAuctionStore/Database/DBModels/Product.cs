using EncryptedAuctionDatatypes;
using LSHDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EncryptedAuctionStore.Database.DBModels
{
    public class Product : ProductBase, ILSHWeightedHashable, ILSHashable
    {
        [Key]
        public override Guid Id { get; set; }

        [JsonIgnore]
        public double Price { get; set; }

        public string GetStringToHash()
        {
            return Brand+Model;
        }

        public List<Tuple<string, double>> GetWeightedStringsToHash()
        {
            return new List<Tuple<string, double>>()
            {
                new Tuple<string, double>(Brand, 0.1),
                new Tuple<string, double>(Model, 0.4),
                new Tuple<string, double>(Brand + " " + Description, 0.5),
            };
        }
    }
}
