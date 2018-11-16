using OnlineFoodBooking.Connector;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFoodBooking.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        private readonly ConnectionToEs _connectionToEs;
        public SearchController()
        {
            _connectionToEs = new ConnectionToEs();
        }

        public ActionResult Search()
        {
            return View("Search");
        }

        public JsonResult DataSearch(string FoodItem)
        {
            var responsedata = _connectionToEs.EsClient().Search<FoodMenuApplicationModel>(s => s
                                    .Index("onlinefoodbooking")
                                    .Type("foodmenu")
                                    .Size(50)
                                    .Query(q => q
                                        .Match(m => m
                                            .Field(f => f.FoodItem)
                                            .Query(FoodItem)
                                        )
                                    )
                                );

            var datasend = (from hits in responsedata.Hits
                            select hits.Source).ToList();

            return Json(new { datasend, responsedata.Took }, behavior: JsonRequestBehavior.AllowGet);
        }

    }
}
