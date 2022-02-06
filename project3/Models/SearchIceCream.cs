using MongoDB.Bson.Serialization.Attributes;

namespace project3.Models
{
    public class SearchIceCream
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("MinRating")]
        public int MinRating { get; set; }

        [BsonElement("MaxRating")]
        public int MaxRating { get; set; }

        [BsonElement("Fats")]
        public double Fats { get; set; }

        [BsonElement("Energy")]
        public double Energy { get; set; }

        [BsonElement("Protein")]
        public double Protein { get; set; }

    }
}