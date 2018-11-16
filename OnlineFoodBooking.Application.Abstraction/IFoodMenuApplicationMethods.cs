
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.Application.Abstraction
{
    public interface IFoodMenuApplicationMethods
    {
        List<FoodMenuApplicationModel> GetFoodMenu();
        void PostNewFoodItem(FoodMenuApplicationModel foodMenuApplicationModel);
        void TransferToMongo();
        List<FoodMenuApplicationModel> GetDataFromMongo();
    }
}
