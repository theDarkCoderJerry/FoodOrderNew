using Hangfire;
using OnlineFoodBooking.Application.Abstraction;

using OnlineFoodBooking.Models;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodBooking.Controllers
{
    public class FoodMenuController : Controller
    {
        private IFoodMenuApplicationMethods foodMenuApplicationMethods;
        private FoodMenuApplicationModel foodMenuApplicationModel;
        public FoodMenuController(IFoodMenuApplicationMethods _foodMenuApplicationMethods )
        {
            foodMenuApplicationMethods = _foodMenuApplicationMethods;
        
        }
        public ActionResult GetFoodMenu()
        {
            return View(foodMenuApplicationMethods.GetFoodMenu());
        }
        public ActionResult PostNewFoodItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostNewFoodItem(FoodMenuApplicationModel foodMenuPresentationModel)
        {
            //foodMenuApplicationModel.FoodItem = foodMenuPresentationModel.FoodItem;
            //foodMenuApplicationModel.Price = foodMenuPresentationModel.Price;
            foodMenuApplicationMethods.PostNewFoodItem(foodMenuPresentationModel);
            BackgroundJob.Enqueue(() => foodMenuApplicationMethods.TransferToMongo());
            return RedirectToAction("GetFoodMenu");
        }

        public ActionResult  GetDataFromMongo()
        {
            return View(foodMenuApplicationMethods.GetDataFromMongo());
        }
    }
}