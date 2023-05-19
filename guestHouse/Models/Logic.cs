using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace guestHouse.Models
{
    public class Logic
    {

       public static bool checkAvailability(int roomNumber,DateTime checkInDate, DateTime checkOutDate) 
        {
            using (var db = new dumakudeDBEntities1()) // replace with your database context
            {
                var bookings = db.roomBooks.Where(b => b.RoomID == roomNumber).ToList();

                foreach (var booking in bookings)
                {

                        if (checkInDate < DateTime.Parse(booking.checkIn) && checkOutDate > DateTime.Parse(booking.checkOut))
                        {
                        return false;
                    }
                }

                return true;
            }
        }

        public class invoice
        {
            public string name { get; set; }
            public int price { get; set; }
            public string email { get; set; }
            public string  checkIn { get; set; }
            public string checkOut { get; set; }
            public int meals { get; set; }


            public  invoice(string name2, string email2, string checkIn2, string checkOut2, int price2, int meals2)
            {
                price = price2;
                name = name2;
                email = email2;
                checkIn = checkIn2;
                checkOut = checkOut2;
                meals = meals2;
            }
        }

    }

    public class AddMeals
    {
        [DisplayName("BreakFast")]
        public bool addBreakFast { get; set; }
        [DisplayName("Supper")]
        public bool addSupper { get; set; }
    }
}
