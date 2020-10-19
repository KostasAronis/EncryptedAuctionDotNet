using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptedAuctionDatatypes
{
    public class ProductBase
    {
        public virtual Guid Id { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
    }
}
