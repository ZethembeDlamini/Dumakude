using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using guestHouse;

namespace guestHouse.Controllers
{
    [Authorize]
    public class roomBooksController : Controller
    {
        private dumakudeDBEntities1 db = new dumakudeDBEntities1();

        // GET: roomBooks
        public ActionResult Index()
        {
            var roomBooks = db.roomBooks.Include(r => r.Room);
            return View(roomBooks.ToList());
        }

        // GET: roomBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roomBook roomBook = db.roomBooks.Find(id);
            if (roomBook == null)
            {
                return HttpNotFound();
            }
            return View(roomBook);
        }

        // GET: roomBooks/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.RoomID = new SelectList(db.Rooms, "Id", "roomType");
            return View();
        }

        // POST: roomBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,email,phoneNumber,checkIn,checkOut,numberOfPeople,comments,RoomID")] roomBook roomBook)
        {
            if (ModelState.IsValid)
            {
                db.roomBooks.Add(roomBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomID = new SelectList(db.Rooms, "Id", "roomType", roomBook.RoomID);
            return View(roomBook);
        }

        // GET: roomBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roomBook roomBook = db.roomBooks.Find(id);
            if (roomBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomID = new SelectList(db.Rooms, "Id", "roomType", roomBook.RoomID);
            return View(roomBook);
        }

        // POST: roomBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,email,phoneNumber,checkIn,checkOut,numberOfPeople,comments,RoomID")] roomBook roomBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomID = new SelectList(db.Rooms, "Id", "roomType", roomBook.RoomID);
            return View(roomBook);
        }

        // GET: roomBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roomBook roomBook = db.roomBooks.Find(id);
            if (roomBook == null)
            {
                return HttpNotFound();
            }
            return View(roomBook);
        }

        // POST: roomBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            roomBook roomBook = db.roomBooks.Find(id);
            db.roomBooks.Remove(roomBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
