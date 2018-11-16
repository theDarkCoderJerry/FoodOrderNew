using MongoDB.Driver;
using OnlineFoodBooking.DataAccess.Abstraction;
using OnlineFoodBooking.DataAccess.Mongo;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAcess.Mongo
{
    public class MongoDataRepository : IMongoDataRepository
    {
        MongoContextClass mongoContextClass = new MongoContextClass();
        List<MongoModel> mongomodel = new List<MongoModel>();
        List<FoodMenuApplicationModel> foodMenuApplicationModel = new List<FoodMenuApplicationModel>();


        public void TransferToMongo(List<FoodMenuDomainModels> foodMenuDomainModels)
        {
            foreach (var item in foodMenuDomainModels)
            {
                if (item.Sync == false)
                {
                    mongomodel.Add(new MongoModel
                    {
                        FoodId = item.FoodId,
                        FoodItem = item.FoodItem,
                        Price = item.Price


                    });
                    //item.Sync = true;
                   
                }
                else
                    break;
               
            }

            mongoContextClass.GetMongoData.InsertMany(mongomodel);
        }

        public List<FoodMenuApplicationModel> GetDataFromMongo()
        {
           mongomodel = mongoContextClass.GetMongoData.AsQueryable().ToList();
            foreach (var item in mongomodel)
            {
                
                foodMenuApplicationModel.Add(new FoodMenuApplicationModel
                {
                    FoodId = item.FoodId,
                    FoodItem = item.FoodItem,
                    Price = item.Price
                });
            }
            return foodMenuApplicationModel.ToList();
          
        }

    }
}
