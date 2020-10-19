using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionAggregator.Database.DBModels
{
    public class LSHConfig
    {
        public Guid Id { get; set; }
        public int[][] LSHHashSeed { get; set; }
    }
}
