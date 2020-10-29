using EncryptedAuctionDatatypes;
using EncryptedAuctionStore.Database.DBModels;
using LSHDotNet;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptedAuctionStore
{
public class Registrator
{
    private StoreBase storeObj;
    private RestClient _client;
    IConfiguration configuration { get; set; }
    public Registrator(IConfiguration conf, StoreBase storeObj)
    {
        this.configuration = conf;
        var aggregatorUrl = conf.GetValue<string>("aggregatorUrl");
        this.storeObj = storeObj;
        _client = new RestClient(aggregatorUrl);
    }
    private int[][] TryRegister()
    {
        var req = new RestRequest($"/api/stores/TryRegister/{storeObj.Id}");
        try
        {
            var res = _client.Get<int[][]>(req);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var seed = JsonConvert.DeserializeObject<int[][]>(res.Content);
                return seed;
            }
            else
            {
                if (res.ErrorException != null)
                {
                    throw res.ErrorException;
                }
                throw new Exception(res.StatusDescription);
            }
        }
        catch
        {
            throw;
        }
    }
    public void Register(List<Product> products)
    {
        try
        {
            var hashSeed = TryRegister();
            var minHasher = new MinHasher<Guid>(hashSeed);
            var hashedProducts = new List<HashedProductBase>();

            foreach (var product in products)
            {
                var id = product.Id;
                var hashedProduct = new HashedProductBase()
                {
                    Id = id
                };
                var weightsL = new List<double>();
                var hashL = new List<int[]>();
                var toHash = product.GetWeightedStringsToHash();
                foreach(var sth in toHash)
                {
                    var weight = sth.Item2;
                    var str = sth.Item1;
                    var hash = minHasher.GetMinHashSignature(str);
                    weightsL.Add(weight);
                    hashL.Add(hash);
                    hashedProduct.Hashes = hashL.ToArray();
                    hashedProduct.Weights = weightsL.ToArray();
                }
                hashedProducts.Add(hashedProduct);
            }
            var req = new RestRequest($"/api/stores/Register/{storeObj.Id}");
            req.AddJsonBody(hashedProducts);
            var res = _client.Post(req);
            if(res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return;
            }
            else
            {
                throw new Exception(res.StatusDescription);
            }
        }
        catch
        {
            throw;
        }
    }
}
}
