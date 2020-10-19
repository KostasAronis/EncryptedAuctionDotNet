using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncryptedAuctionDatatypes;
using EncryptedAuctionStore.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderPreservingEncryptionDotNet;

namespace EncryptedAuctionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;
        private readonly DBContext _db;

        public OfferController(ILogger<OfferController> logger, DBContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }
        [HttpPost]
        public long GetOffer(OfferQuery query)
        {
            var ope = new OPE(query.Key);
            var prod = _db.Products.FirstOrDefault(p => p.Id == query.Id);
            //TODO: IMPLEMENT DECIMAL ENCRYPTION IN OPE!!!
            var encryptedPrice = ope.Encrypt(Convert.ToInt32(Math.Ceiling(prod.Price)));
            return encryptedPrice;
        }
        //[HttpPost]
        //public long GetOffers(OfferQuery query)
        //{
        //    var ope = new OPE(query.Key);
        //    var prod = _db.Products.FirstOrDefault(p => p.Id == query.Id);
        //    //TODO: IMPLEMENT DECIMAL ENCRYPTION IN OPE!!!
        //    var encryptedPrice = ope.Encrypt(Convert.ToInt32(Math.Ceiling(prod.Price)));
        //    return encryptedPrice;
        //}
    }
}