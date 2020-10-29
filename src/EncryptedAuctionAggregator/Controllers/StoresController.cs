using EncryptedAuctionAggregator.Database;
using EncryptedAuctionAggregator.Database.DBModels;
using EncryptedAuctionDatatypes;
using LSHDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionAggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ILogger<StoresController> _logger;
        private readonly DBContext _db;
        public StoresController(ILogger<StoresController> logger, DBContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }
        [HttpGet("TryRegister/{guid}")]
        public ActionResult<int[][]> TryRegister([FromRoute] Guid guid)
        {
            if (_db.Stores.Any(s => s.Id == guid))
            {
                return Ok(_db.LSHConfig.LSHHashSeed);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("Register/{guid}")]
        public ActionResult Register([FromRoute] Guid guid, [FromBody] List<HashedProductBase> products)
        {
            if (_db.Stores.Any(s => s.Id == guid))
            {
                try
                {
                    _db.HashedProducts.RemoveRange(_db.HashedProducts.Where(p => p.StoreId == guid));
                    var dbProducts = products.Select(p => new HashedProduct()
                    {
                        Id = p.Id,
                        Weights = p.Weights,
                        Hashes = p.Hashes,
                        Store = null,
                        StoreId = guid
                    });
                    _db.HashedProducts.AddRange(dbProducts);
                    _db.SaveChanges();
                    return Ok();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
