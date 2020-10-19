using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptedAuctionDatatypes
{
    public class MultiOfferQuery
    {
        List<Guid> Ids { get; set; }
        public string Key { get; set; }
    }
}
