using EncryptedAuctionDatatypes;
using LSHDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionAggregator.Database.DBModels
{
    public class HashedProduct : HashedProductBase, IWeightedHashed
    {
        public override Guid Id { get; set; }
        public Store Store { get; set; }
        public Guid StoreId { get; set; }

        public List<Tuple<int[], double>> GetWeightedHashes()
        {
            var r = new List<Tuple<int[], double>>();
            for (var i = 0; i < Weights.Length; i++)
            {
                r.Add(new Tuple<int[], double>(Hashes[i], Weights[i]));
            }
            return r;
        }
    }
}
