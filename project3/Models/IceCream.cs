using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace project3.Models
{
    public class IceCream
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("StoreId")]
        public string StoreId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        public double Price { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }

        [BsonElement("Rating")]
        public double Rating { get; set; }

        [BsonElement("NutritionId")]
        public int NutritionId { get; set; }

        [BsonElement("Fats")]
        public double Fats { get; set; }

        [BsonElement("Energy")]
        public double Energy { get; set; }

        [BsonElement("Protein")]
        public double Protein { get; set; }

        [BsonElement("IceReview")]
        public List<Review> IceReview { get; set; }

    }
   
}
