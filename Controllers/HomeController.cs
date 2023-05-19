using guestHouse.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Drawing.Imaging;

namespace guestHouse.Controllers
{
    public class HomeController : Controller
    {
        private dumakudeDBEntities1 db = new dumakudeDBEntities1();
        public ActionResult Index()
        {
            Text text = db.Texts.Find(1);
            ViewBag.text1 = text.text1;
            ViewBag.text2 = text.text2;
            ViewBag.text3 = text.text3;
            ViewBag.text4 = text.text4;
            ViewBag.text5 = text.text5;
            ViewBag.text6 = text.text6;
            ViewBag.text7 = text.text7;
            ViewBag.roomsList = db.Rooms.ToList();
            
            return View(db.Testimonials.ToList());
        }

        public ActionResult Gallery()
        {
            
            return View(db.Galleries.ToList());
        }

        public ActionResult Contact()
        {

            return View();
        }
        [Authorize]
        public ActionResult Admin()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Contact([Bind(Include = "Id,name,email,message,subject")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
            
        }

        public ActionResult Success()
        {
           
            return View();
        }
        public ActionResult Form(string checkIn, string checkOut, int roomId, int price)
        {
            AddMeals addMeals = new AddMeals();
            ViewBag.checkIn = checkIn;
            ViewBag.checkOut = checkOut;
            ViewBag.roomId = roomId;
            ViewBag.price = price;
            return View(addMeals);
        }

      

        [HttpPost]

        public ActionResult CheckAvailability(string checkIn, int noInParty, string checkOut)
        {
            
            ViewBag.roomsList = db.Rooms.ToList();
            ViewBag.bookList = db.roomBooks.ToList();
            ViewBag.checkIn = checkIn;
            ViewBag.checkOut = checkOut;
            ViewBag.noInParty = noInParty;
            
            return View();
        }

        public ActionResult Booking2(string checkIn, string checkOut)
        {
            using (var db = new dumakudeDBEntities1()) // replace with your database context
            {
                
                ViewBag.checkIn = checkIn;
                ViewBag.checkOut = checkOut;
                ViewBag.roomsList = db.Rooms.ToList();
                var bookings = db.roomBooks.ToList();

                var availableRooms = new List<int>();

                foreach (var room in db.Rooms)
                {
                    bool isAvailable = true;

                    foreach (var booking in bookings)
                    {
                        if (booking.RoomID == room.Id &&
                            DateTime.Parse(checkIn) < DateTime.Parse(booking.checkOut) && DateTime.Parse(checkOut) > DateTime.Parse(booking.checkIn))
                        {
                            isAvailable = false;
                            break;
                        }
                    }

                    if (isAvailable)
                    {
                        availableRooms.Add(room.Id);
                    }
                }

                return View(availableRooms);
            }
        }


        public ActionResult roomBooking([Bind(Include = "Id,name,email,phoneNumber,checkIn,checkOut,comments,RoomID,price")] roomBook roomBook, AddMeals addMeals)
        {
            bool addBreakFast = addMeals.addBreakFast;
            bool addSupper = addMeals.addSupper;
            int meals = 0;
            if (ModelState.IsValid)
            {

                if (addBreakFast)
                {
                    roomBook.comments = "Plus BreakFast     ";
                    meals += 150;
                }
                if (addSupper)
                {
                    roomBook.comments += "Plus Supper";
                    meals += 150;
                }
                db.roomBooks.Add(roomBook);
                db.SaveChanges();
                return RedirectToAction("Index", "Invoice", new { name = roomBook.name, email = roomBook.email, checkin = roomBook.checkIn, checkOut = roomBook.checkOut, price = roomBook.price,meals = meals });
            }

            
            return RedirectToAction("Index","Invoice");
        }


        

    }
}