using System;
using System.IO;
using System.Net;
using project3.Models;
using MongoDB.Driver;
using System.Linq;

namespace project3.Services
{
    public class ApiService
    {
        private readonly IMongoCollection<Users> _users;

        //Ctor
        public ApiService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("lustig");
            _users = database.GetCollection<Users>("users");
        }

        // GET: Products
        public string get(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            // json-formatted string from maps api
            var responseFromServer = reader.ReadToEnd();
            response.Close();
            return responseFromServer;
        }
        
        //Check In Login
        public Boolean userValidation(Users user)
        {
            var usersList = _users.Find<Users>(tempUser => tempUser.UserName == user.UserName && tempUser.Password == user.Password).ToList();
            return usersList.Count > 0;
        }

        //Check In Sign Up 
        public Boolean isExist(Users user)
        {
            var count= _users.Find<Users>(tempUser => tempUser.UserName == user.UserName && tempUser.Password == user.Password).ToList().Count();
            if (count > 0)
            {
              return true;
            }
            return false;
        }

        //Register New User
        public Users Create(Users user)
        {
            _users.InsertOne(user);
            return user;
        }
    }
}
