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
/*
 *1 Eisagwgh
 *2 Thewria lsh
 *3 to provlhma kai pws to lunw arxitektonika
 *4 stoixeia ulopoihshs (upokefalaio ergaleia)
 *5 paradeigma ekteleshs
 *6 epilogos mellontikes epektaseis 
 * 
 * video => paradeigma
 * 
 */