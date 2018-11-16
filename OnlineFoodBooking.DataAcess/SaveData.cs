using OnlineFoodBooking.DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAcess
{
   public class SaveData : ISaveData
    {
        OnlineFoodBookingEntities db = new OnlineFoodBookingEntities();
        public void ReturnSavedDb()
        {
            db.SaveChanges();
        }
    }
}
