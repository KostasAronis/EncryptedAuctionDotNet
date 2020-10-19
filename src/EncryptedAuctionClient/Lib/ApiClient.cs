using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EncryptedAuctionDatatypes;
using Newtonsoft.Json;
using OrderPreservingEncryptionDotNet;
using RestSharp;

namespace EncryptedAuctionClient.Lib
{
    public class ApiClient
    {
        private static readonly Dictionary<string, string> _paths = new Dictionary<string, string>()
        {
            { "products", "/api/Product" },
            { "search", "/api/Search" },
            { "offer", "/api/Offer" }
        };
        private string _aggregatorUrl;

        public ApiClient(string aggregatorUrl)
        {
            _aggregatorUrl = aggregatorUrl;
        }

        public async Task<int[][]> GetHashSeed()
        {
            var client = new RestClient(_aggregatorUrl);
            var request = new RestRequest(_paths["search"]);
            request.Method = Method.GET;
            var response = await client.ExecuteAsync<int[][]>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var seed = JsonConvert.DeserializeObject<int[][]>(response.Content);
                return seed;
            }
            else
            {
                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
        }

        public async Task<IEnumerable<SearchResult>> HashedSearch(HashedSearchQuery query)
        {
            var client = new RestClient(_aggregatorUrl);
            var request = new RestRequest(_paths["search"]);
            request.AddJsonBody(query);
            request.Method = Method.POST;
            var response = await client.ExecuteAsync<IEnumerable<SearchResult>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
        }

        public async Task<IEnumerable<ProductBase>> GetProducts(StoreBase store, List<Guid> guids)
        {
            var client = new RestClient(store.ApiUrl);
            var request = new RestRequest(_paths["products"]);
            request.AddJsonBody(guids);
            request.Method = Method.POST;
            var response = await client.ExecuteAsync<IEnumerable<ProductBase>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }
                else
                {
                    throw new Exception(response.StatusDescription);
                }
            }
        }

        public static async Task<List<OfferViewModel>> GetOffers(List<OfferViewModel> offersToGet)
        {
            var taskDictionary = new Dictionary<Guid, Task<IRestResponse<long>>>();
            var OPEKey = OPE.CreateKeyString();
            var ope = new OPE(OPEKey);
            foreach (var offer in offersToGet)
            {
                var query = new OfferQuery()
                {
                    Id = offer.ProductId,
                    Key = OPEKey
                };
                var client = new RestClient(offer.StoreApiUrl);
                var request = new RestRequest(_paths["offer"]);
                request.AddJsonBody(query);
                request.Method = Method.POST;
                var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                var task = client.ExecuteAsync<long>(request, cancellationTokenSource.Token);
                taskDictionary.Add(offer.ProductId, task);
            }
            await Task.WhenAll(taskDictionary.Values);

            taskDictionary
            .Where(t => !t.Value.IsFaulted && t.Value.Result.StatusCode == System.Net.HttpStatusCode.OK)
            .ToList()
            .ForEach(t =>
            {
                offersToGet.First(o => o.ProductId == t.Key).EncryptedPrice = t.Value.Result.Data;
                offersToGet.First(o => o.ProductId == t.Key).RealPrice = ope.Decrypt(t.Value.Result.Data);
            });
            return offersToGet;
        }

        public Dictionary<string, List<SearchResult>> SearchStore(StoreBase store, List<string> searchTerms)
        {
            var results = new Dictionary<string, List<SearchResult>>();

            return results;
        }
    }
}
