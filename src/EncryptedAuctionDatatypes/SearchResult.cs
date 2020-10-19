using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptedAuctionDatatypes
{
    public class SearchResult
    {
        public ProductBase Product { get; set; }
        public StoreBase Store { get; set; }
        public double Similarity { get; set; }
    }
}
