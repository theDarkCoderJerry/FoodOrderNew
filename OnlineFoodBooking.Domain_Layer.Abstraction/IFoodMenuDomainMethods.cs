using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.Domain_Layer.Abstraction
{
    public interface IFoodMenuDomainMethods
    {
        List<FoodMenuDomainModels> GetFoodMenu();
        void PostNewFoodItem(FoodMenuDomainModels foodMenuDomainModels);
        void TransferToMongo();
        List<FoodMenuApplicationModel> GetDataFromMongo();
    }
}
