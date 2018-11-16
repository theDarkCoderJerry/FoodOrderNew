using Hangfire;
using OnlineFoodBooking.Application.Abstraction;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineFoodBooking.Controllers
{
    public class OnlineFoodController : ApiController
    {
        private IFoodMenuApplicationMethods foodMenuApplicationMethods;
        private FoodMenuApplicationModel foodMenuApplicationModel;
        public OnlineFoodController(IFoodMenuApplicationMethods _foodMenuApplicationMethods)
        {
            foodMenuApplicationMethods = _foodMenuApplicationMethods;

        }
        public IHttpActionResult GetFoodMenuapi()
        {
            return Ok(foodMenuApplicationMethods.GetFoodMenu());
        }
        public IHttpActionResult PostNewFoodItemapi()
        {
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult PostNewFoodItemapi(FoodMenuApplicationModel foodMenuPresentationModel)
        {
            //foodMenuApplicationModel.FoodItem = foodMenuPresentationModel.FoodItem;
            //foodMenuApplicationModel.Price = foodMenuPresentationModel.Price;
            foodMenuApplicationMethods.PostNewFoodItem(foodMenuPresentationModel);
            BackgroundJob.Enqueue(() => foodMenuApplicationMethods.TransferToMongo());
            return Ok();
        }

        public IHttpActionResult GetDataFromMongoapi()
        {
            return Ok(foodMenuApplicationMethods.GetDataFromMongo());
        }
    }
}
