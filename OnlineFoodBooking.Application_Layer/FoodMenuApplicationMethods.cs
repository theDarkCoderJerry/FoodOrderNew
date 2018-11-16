using OnlineFoodBooking.Application.Abstraction;
using OnlineFoodBooking.Domain_Layer.Abstraction;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.Application_Layer
{
    public class FoodMenuApplicationMethods : IFoodMenuApplicationMethods
    {
        private IFoodMenuDomainMethods foodMenuDomainMethods;
       private FoodMenuDomainModels foodMenuDomainModels;
        public FoodMenuDomainModels tempFoodMenuDomain = new FoodMenuDomainModels();
        private List<FoodMenuApplicationModel> foodMenuApplicationModel = new List<FoodMenuApplicationModel>();
        public FoodMenuApplicationMethods(IFoodMenuDomainMethods _foodMenuDomainMethods)
        {
            foodMenuDomainMethods = _foodMenuDomainMethods;
        
        }

        public List<FoodMenuApplicationModel>GetFoodMenu()
        {
            var returnedFoodMenu = foodMenuDomainMethods.GetFoodMenu();

            foreach (var item in returnedFoodMenu)
            {
                foodMenuApplicationModel.Add(new FoodMenuApplicationModel
                    {
                    FoodId = item.FoodId,
                    FoodItem = item.FoodItem,
                    Price = item.Price
                    
                   });
            }

            return foodMenuApplicationModel;
        }

       public void  PostNewFoodItem(FoodMenuApplicationModel foodMenuApplicationModel)
        {
            tempFoodMenuDomain.FoodItem = foodMenuApplicationModel.FoodItem;
            tempFoodMenuDomain.Price = foodMenuApplicationModel.Price;
            tempFoodMenuDomain.Sync = false;
            foodMenuDomainMethods.PostNewFoodItem(tempFoodMenuDomain);
        }

        public void TransferToMongo()
        {
            foodMenuDomainMethods.TransferToMongo();
            
        }

        public List<FoodMenuApplicationModel> GetDataFromMongo()
        {
            return foodMenuDomainMethods.GetDataFromMongo();
        }
    }
}
