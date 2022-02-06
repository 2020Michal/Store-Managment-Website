using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string  Id{ get; set; }

        public string IdOfIceCream { get; set; }

        public DateTime DateTimeStamp { get; set; }

        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }

        [BsonElement("ImageUrlOfUser")]
        public string ImageUrlOfUser { get; set; }

        [BsonElement("Rating")]
        public int Rating { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }

        [BsonElement("CommentedBy")]
        public string CommentedBy { get; set; }

    }
}