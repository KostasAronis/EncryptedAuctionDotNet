//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using EncryptedAuctionDatatypes;
//using EncryptedAuctionStore.Database;
//using EncryptedAuctionStore.Database.DBModels;
//using LSHDotNet;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using OrderPreservingEncryptionDotNet;

//namespace EncryptedAuctionStore.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SearchController : ControllerBase
//    {
//        private readonly StoreBase _store;
//        private readonly ILogger<SearchController> _logger;
//        private readonly DBContext _db;

//        public SearchController(StoreBase store, ILogger<SearchController> logger, DBContext dbContext)
//        {
//            _store = store;
//            _logger = logger;
//            _db = dbContext;
//        }

//        [HttpPost]
//        //searching by combination
//        public Dictionary<string, IEnumerable<SearchResult>> Search(SearchQuery search)
//        {
//            var str = JsonConvert.SerializeObject(new Tuple<int, int>(5, 14));
//            var results = new Dictionary<string, IEnumerable<SearchResult>>();
//            var products = _db.Products.ToList();
//            var minHasher = new MinHasher<Guid>(search.HashSeeds);
//            var lshSearcher = new LSHSearch<Guid>(minHasher, SimilarityMeasures.Jaccard);
//            var searchTermCombinations = GetCombinations(search.SearchTerms.ToList()).Where(c=>c.Count>0);
//            foreach (var searchTermCombination in searchTermCombinations.OrderByDescending(st => st.Count))
//            {
//                var searchTerm = String.Join(' ', searchTermCombination);
//                var partialResults = lshSearcher.GetClosest(
//                                                            products.ToDictionary(p => p.Id, p => (ILSHWeightedHashable)p),
//                                                            searchTerm,
//                                                            search.MaxResults,
//                                                            search.MinimumSimilarity
//                                                            );
//                var partialResultsWithNested = partialResults.Select(r =>
//                {
//                    return new SearchResult()
//                    {
//                        Product = JsonConvert.DeserializeObject<ProductBase>(JsonConvert.SerializeObject(products.First(p => p.Id == r.Id))),
//                        Similarity = r.Similarity,
//                        Store = _store
//                    };
//                });
//                results.Add(String.Join(' ', searchTermCombination), partialResultsWithNested.Take(search.MaxResults));
//            }
//            return results;
//        }

//        [HttpPost("HashSearch")]
//        public Dictionary<string, IEnumerable<SearchResult>> HashSearch(SearchQuery search)
//        {
//            var str = JsonConvert.SerializeObject(new Tuple<int, int>(5, 14));
//            var results = new Dictionary<string, IEnumerable<SearchResult>>();
//            var products = _db.Products.ToList();
//            var minHasher = new MinHasher<Guid>(search.HashSeeds);
//            var lshSearcher = new LSHSearch<Guid>(minHasher, SimilarityMeasures.Jaccard);
//            var searchTermCombinations = GetCombinations(search.SearchTerms.ToList()).Where(c => c.Count > 0);
//            foreach (var searchTermCombination in searchTermCombinations)
//            {
//                var searchTerm = String.Join(' ', searchTermCombination);
//                var partialResults = lshSearcher.GetClosest(
//                                                            products.ToDictionary(p => p.Id, p => (ILSHWeightedHashable)p),
//                                                            searchTerm,
//                                                            1000,
//                                                            search.MinimumSimilarity
//                                                            );
//                var partialResultsWithNested = partialResults.Select(r =>
//                {
//                    return new SearchResult()
//                    {
//                        Product = JsonConvert.DeserializeObject<ProductBase>(JsonConvert.SerializeObject(products.First(p => p.Id == r.Id))),
//                        Similarity = r.Similarity,
//                        Store = _store
//                    };
//                });
//                results.Add(String.Join(' ', searchTermCombination), partialResultsWithNested.Take(search.MaxResults));
//            }
//            return results;
//        }

//        // simple one word search
//        //public Dictionary<string, IEnumerable<SearchResult>> Search(SearchQuery search)
//        //{
//        //    var str = JsonConvert.SerializeObject(new Tuple<int, int>(5, 14));
//        //    var results = new Dictionary<string, IEnumerable<SearchResult>>();
//        //    var products = _db.Products.ToList();
//        //    var minHasher = new MinHasher<Guid>(search.HashSeeds.Length, search.HashSeeds);
//        //    var lshSearcher = new LSHSearch<Guid>(minHasher, SimilarityMeasures.Jaccard);
//        //    var searchTermCombinations = GetCombinations(search.SearchTerms.ToList());
//        //    foreach (var searchTerm in search.SearchTerms)
//        //    {

//        //        var partialResults = lshSearcher.GetClosest(
//        //                                                    products.ToDictionary(p => p.Id, p => (ILSHashable)p),
//        //                                                    searchTerm,
//        //                                                    search.MaxResults,
//        //                                                    search.MinimumSimilarity
//        //                                                    );

//        //        var partialResultsWithNested = partialResults.Select(r =>
//        //        {
//        //            return new SearchResult()
//        //            {
//        //                Product = products.First(p => p.Id == r.Id),
//        //                Similarity = r.Similarity
//        //            };
//        //        });
//        //        results.Add(searchTerm, partialResultsWithNested);
//        //    }
//        //    return results;
//        //}


//        // combinations and searching per word
//        //public Dictionary<string, IEnumerable<SearchResult>> Search(SearchQuery search)
//        //{
//        //    var str = JsonConvert.SerializeObject(new Tuple<int, int>(5, 14));
//        //    var results = new Dictionary<string, IEnumerable<SearchResult>>();
//        //    var products = _db.Products.ToList();
//        //    var minHasher = new MinHasher<Guid>(search.HashSeeds.Length, search.HashSeeds);
//        //    var lshSearcher = new LSHSearch<Guid>(minHasher, SimilarityMeasures.Jaccard);
//        //    var searchTermCombinations = GetCombinations(search.SearchTerms.ToList());
//        //    foreach (var searchTermCombination in searchTermCombinations)
//        //    {
//        //        Dictionary<Guid, List<double>> combinationSimilarities = new Dictionary<Guid, List<double>>();
//        //        foreach (var searchTerm in searchTermCombination)
//        //        {

//        //            var partialResults = lshSearcher.GetClosest(
//        //                                                        products.ToDictionary(p => p.Id, p => (ILSHashable)p),
//        //                                                        searchTerm,
//        //                                                        1000,
//        //                                                        search.MinimumSimilarity
//        //                                                        );
//        //            partialResults.ForEach(p =>
//        //            {
//        //                if (combinationSimilarities.ContainsKey(p.Id))
//        //                {
//        //                    combinationSimilarities[p.Id].Add(p.Similarity);
//        //                }
//        //                else
//        //                {
//        //                    combinationSimilarities.Add(p.Id, new List<double>() { p.Similarity });
//        //                }
//        //            });
//        //        }
//        //        combinationSimilarities.OrderBy(p => p.Key, Comparer<Guid>.Create((a, b) =>
//        //         {
//        //             return (combinationSimilarities[a].Sum() / search.SearchTerms.Count()).CompareTo((combinationSimilarities[b].Sum() / search.SearchTerms.Count()));
//        //         }));
//        //        var partialResultsWithNested = combinationSimilarities.Select(r =>
//        //            {
//        //                return new SearchResult()
//        //                {
//        //                    Product = products.First(p => p.Id == r.Key),
//        //                    Similarity = r.Value.Sum() / search.SearchTerms.Count()
//        //                };
//        //            });
//        //        results.Add(String.Join(' ', searchTermCombination), partialResultsWithNested.Take(search.MaxResults));
//        //    }
//        //    return results;
//        //}
//        private static List<List<string>> GetCombinations(List<string> allValues)
//        {
//            var collection = new List<List<string>>();
//            for (int counter = 0; counter < (1 << allValues.Count); ++counter)
//            {
//                List<string> combination = new List<string>();
//                for (int i = 0; i < allValues.Count; ++i)
//                {
//                    if ((counter & (1 << i)) == 0)
//                        combination.Add(allValues[i]);
//                }
//                // do something with combination
//                collection.Add(combination);
//            }
//            return collection;
//        }
//    }
//}