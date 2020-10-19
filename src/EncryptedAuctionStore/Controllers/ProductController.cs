using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncryptedAuctionStore.Database;
using EncryptedAuctionStore.Database.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EncryptedAuctionStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILogger<ProductController> _logger;
        private DBContext _db;

        public ProductController(ILogger<ProductController> logger, DBContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }
        [HttpPost]
        public List<Product> GetProducts([FromBody] List<Guid> guids)
        {
            return _db.Products.Where(p => guids.Contains(p.Id)).ToList();
        }
    }
}