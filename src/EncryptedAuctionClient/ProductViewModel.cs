using EncryptedAuctionDatatypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptedAuctionClient
{
    public class ProductViewModel
    {
        public string Brand { get; internal set; }
        public string Model { get; internal set; }
        public string Description { get; internal set; }
        public int StoreCount { get; internal set; }
        public double Similarity { get; internal set; }
        public List<StoreBase> Stores { get; internal set; }
    }
}
