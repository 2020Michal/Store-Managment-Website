using MongoDB.Driver;
using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.Services
{
    public class ReviewService
    {
        private readonly IMongoCollection<Review> _reviews;

        //Ctor
        public ReviewService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("lustig");
            _reviews = database.GetCollection<Review>("reviews");
        }

        //Return All Reviews
        public List<Review> Get()
        {
            return _reviews.Find(review => true).ToList();
        }

        public List<Review> Get(string id)
        {
            return  _reviews.Find<Review>(review => review.IdOfIceCream == id).ToList();
            
        }

        public Review Create(Review review)
        {
            review.DateTimeStamp = DateTime.Now.AddHours(2);
            _reviews.InsertOne(review);
            return review;
        }
    }
}