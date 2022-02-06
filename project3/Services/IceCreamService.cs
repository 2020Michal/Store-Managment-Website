using project3.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace project3.Services
{
    public class IceCreamService
    {
        private readonly IMongoCollection<IceCream> _iceCreams;
         private readonly ReviewService _reviewService;

        //Ctor
        public IceCreamService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("lustig");
            _iceCreams = database.GetCollection<IceCream>("icecreams");
            _reviewService = new ReviewService();
        }

        //Return All Icecreams
        public List<IceCream> Get()
        {
            return _iceCreams.Find<IceCream>(iceCream => true).ToList();
        }

        public IceCream Get(string id)
        {
            IceCream iceCreamResult = _iceCreams.Find<IceCream>(iceCream => iceCream.Id == id).FirstOrDefault();
            var reviews = _reviewService.Get(id);
            iceCreamResult.Rating = AverageRating(reviews);
            Update(iceCreamResult.Id, iceCreamResult);
            reviews.Sort((x, y) => DateTime.Compare(y.DateTimeStamp, x.DateTimeStamp));
            iceCreamResult.IceReview = reviews;
            return iceCreamResult;
        }

        //Search Filters In Home Page
        public List<IceCream> Get(SearchIceCream searchIceCream)
        {
            var desc = searchIceCream.Description;
            var name = searchIceCream.Name;
            var minRate = searchIceCream.MinRating;
            var maxRate = searchIceCream.MaxRating;
            var protein = searchIceCream.Protein ==0? 30.0: searchIceCream.Protein;
            var energy = searchIceCream.Energy ==0? 1000.0 : searchIceCream.Energy;
            var fats = searchIceCream.Fats == 0 ? 30.0 : searchIceCream.Fats;
            desc = desc ?? "";
            name = name ?? "";
            var iceCreamList= _iceCreams.Find<IceCream>(iceCream => iceCream.Name.Contains(name) && iceCream.Description.Contains(desc) &&
            iceCream.Rating >= minRate && iceCream.Rating <= maxRate && iceCream.Energy <= energy && iceCream.Fats <= fats
            && iceCream.Protein <= protein).ToList();
            return iceCreamList;
        }

        public IceCream Create(IceCream ice)
        {
            _iceCreams.InsertOne(ice);
            return ice;
        }

        public double AverageRating(List<Review> reviews)
        {
            var sum = 0.0;
            if (reviews.Count != 0)
            {
                foreach (Review item in reviews)
                {
                    sum += item.Rating;
                }
                sum = (sum / reviews.Count);
                var result = Math.Round(sum, 2, MidpointRounding.AwayFromZero);
                return result;
            }
            else
            {
                return 0.0;
            }
        }

        public void Update(string id, IceCream ice)
        {
            _iceCreams.ReplaceOne(iceCream => iceCream.Id == id, ice);
        }

    }
}
