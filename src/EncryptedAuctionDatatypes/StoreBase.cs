using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptedAuctionDatatypes
{   
    public class StoreBase
    {
        public virtual Guid Id { get; set; }
        public string Name { get; set; }
        public string ApiUrl { get; set; }
    }
}
