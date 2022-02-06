using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class Users
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("UserName")]
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
    
        [BsonElement("Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}