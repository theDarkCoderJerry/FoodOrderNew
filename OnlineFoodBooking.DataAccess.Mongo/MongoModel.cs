using MongoDB.Bson.Serialization.Attributes;
using OnlineFoodBooking.DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAccess.Mongo
{
    public class MongoModel 
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int FoodId { get; set; }
        public string FoodItem { get; set; }
        public int Price { get; set; }
    }
}
