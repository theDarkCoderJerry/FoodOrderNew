using MongoDB.Driver;
using OnlineFoodBooking.DataAccess.Abstraction;
using OnlineFoodBooking.DataAccess.Mongo.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAccess.Mongo
{
   public class MongoContextClass  
    {
        IMongoDatabase Database;
        public  MongoContextClass()
        {
            var Connectionstring = Settings.Default.connectionstring;
            var settings = MongoClientSettings.FromUrl(new MongoUrl(Connectionstring));
            var client = new MongoClient(settings);
            Database = client.GetDatabase(Settings.Default.database);
        }

        public IMongoCollection<MongoModel> GetMongoData => Database.GetCollection<MongoModel>("OnlineFoodBooking");
    }
}
