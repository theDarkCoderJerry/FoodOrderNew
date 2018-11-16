
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBookingModels
{
   public class FoodMenuDomainModels 
    {
        public int FoodId { get; set; }
        public string FoodItem { get; set; }
        public int Price { get; set; }
        public bool Sync { get; set; }
    }
}
