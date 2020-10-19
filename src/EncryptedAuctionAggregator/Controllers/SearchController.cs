using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncryptedAuctionAggregator.Database;
using EncryptedAuctionAggregator.Database.DBModels;
using EncryptedAuctionDatatypes;
using LSHDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EncryptedAuctionAggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ILogger<SearchController> _logger;
        private DBContext _db;

        public SearchController(ILogger<SearchController> logger, DBContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }

        [HttpGet]
        public int[][] GetHashSeed()
        {
            return _db.LSHConfig.LSHHashSeed;
        }

        [HttpPost]
        public List<SearchResult> Search(HashedSearchQuery search)
        {
            var minHasher = new MinHasher<Guid>(_db.LSHConfig.LSHHashSeed);
            var lshSearcher = new LSHSearch<Guid>(minHasher, SimilarityMeasures.Jaccard);
            var searchSpace = _db.HashedProducts
                .ToDictionary(p => p.Id, p => (IWeightedHashed)p);
            var res = lshSearcher.GetClosest(searchSpace, search.SearchTerm, search.MaxResults, search.MinimumSimilarity);
            var results = res.Select(r =>
                new SearchResult
                {
                    Product = new ProductBase()
                    {
                        Id = r.Id
                    },
                    Similarity = r.Similarity,
                    Store = _db.HashedProducts
                        .Include(p => p.Store)
                        .FirstOrDefault(p => p.Id == r.Id).Store
                }
            ).ToList();
            return results;
        }
    }
}