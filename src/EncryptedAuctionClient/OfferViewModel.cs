using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptedAuctionClient
{
    public class OfferViewModel
    {
        public Guid ProductId { get; set; }
        public string StoreName { get; set; }
        public string StoreApiUrl { get; set; }
        public long RealPrice { get; set; }
        public long EncryptedPrice { get; set; }
        public string ProductUrl
        {
            get
            {
                return $"{StoreApiUrl}/api/products/{ProductId}";
            }
        }
    }
}
