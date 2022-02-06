using MongoDB.Driver;
using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.Services
{
    public class StoreService
    {
        private readonly IMongoCollection<Store> _stores;
        private readonly IMongoCollection<IceCream> _iceCreams;
        private readonly IceCreamService _iceCreamService;
       
        //Ctor
        public StoreService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("lustig");
            _stores = database.GetCollection<Store>("store_icecream");
            _iceCreams = database.GetCollection<IceCream>("icecreams");
            _iceCreamService = new IceCreamService();
        }

        //Return All Stores
        public List<Store> Get()
        {
           return _stores.Find(store => true).ToList();
        }

        //Return All Icecreams Of A Store
        public List<IceCream> GetProductsOfStore(string id)
        {
            return _iceCreams.Find<IceCream>(iceCream => iceCream.StoreId == id).ToList();
        }

        public Store Get(string id)
        {
            return _stores.Find<Store>(storeiceCream => storeiceCream.Id == id).FirstOrDefault();
        }

        public Store Create(Store store)
        {
            _stores.InsertOne(store);
            return store;
        }
    }
}