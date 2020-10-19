using EncryptedAuctionDatatypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionAggregator.Database.DBModels
{
    public class Store : StoreBase
    {
        [Key]
        public override Guid Id { get; set; }
        public List<HashedProduct> HashedProducts { get; set; }
    }
}
