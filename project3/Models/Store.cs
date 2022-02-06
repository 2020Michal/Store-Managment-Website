using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class Store
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }

        [BsonElement("PhoneNum")]
        public string PhoneNum { get; set; }

        [BsonElement("Lat")]
        public string Lat { get; set; }

        [BsonElement("Lang")]
        public string Lang { get; set; }

        [BsonElement("ListOfIce")]
        public List<IceCream> ListOfIce { get; set; }
    }
}