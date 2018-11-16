using OnlineFoodBooking.DataAccess.Abstraction;
using OnlineFoodBooking.Domain_Layer.Abstraction;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.Domain_Layer
{
   public class FoodMenuDomainMethods : IFoodMenuDomainMethods
    {
        private IDataAccessRespository dataAccessRespository;
        // private IMongoModel mongoModel;
        private IMongoDataRepository mongoDataRepository;
       
        public FoodMenuDomainMethods(IDataAccessRespository _dataAccessRespository ,IMongoDataRepository _mongoDataRepository )
        {
            dataAccessRespository = _dataAccessRespository;
            mongoDataRepository = _mongoDataRepository;



        }

        public List<FoodMenuDomainModels> GetFoodMenu()
        {
          List<FoodMenuDomainModels>foodMenuDomainModels = dataAccessRespository.GetFoodMenu().ToList();

            //List<FoodMenuDomainModels> foodMenuDomainModels = new List<FoodMenuDomainModels>();

            //foreach (var item in returnedFoodMenu)
            //{
            //    foodMenuDomainModels.Add(new FoodMenuDomainModels
            //    {
            //        FoodId = item.FoodId,
            //        FoodItem = item.FoodItem,
            //        Price = item.Price,
            //        Sync = item.Sync   
            //    } );
            //}

            return foodMenuDomainModels;
        }

        public void PostNewFoodItem(FoodMenuDomainModels foodMenuDomainModels)
        {
            //tempFoodMenuDomain.FoodItem = foodMenuDomainModels.FoodItem;
            //tempFoodMenuDomain.Price = foodMenuDomainModels.Price;
            //tempFoodMenuDomain.Sync = false; 
            dataAccessRespository.PostNewFoodItem(foodMenuDomainModels);
        }

        public void TransferToMongo()
        {
            List<FoodMenuDomainModels> foodMenuDomainModels = dataAccessRespository.GetFoodMenu().ToList();

            mongoDataRepository.TransferToMongo(foodMenuDomainModels);

        }

        public List<FoodMenuApplicationModel> GetDataFromMongo()
        {
            return mongoDataRepository.GetDataFromMongo();
        }
    }
}
