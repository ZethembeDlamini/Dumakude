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
    public class TextsController : Controller
    {
        private dumakudeDBEntities1 db = new dumakudeDBEntities1();

        // GET: Texts
        public ActionResult Index()
        {
            return View(db.Texts.ToList());
        }

        // GET: Texts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Texts.Find(id);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // GET: Texts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Texts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,text1,text2,text3,text4,text5,text6,text7")] Text text)
        {
            if (ModelState.IsValid)
            {
                db.Texts.Add(text);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(text);
        }

        // GET: Texts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Texts.Find(id);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // POST: Texts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,text1,text2,text3,text4,text5,text6,text7")] Text text)
        {
            if (ModelState.IsValid)
            {
                db.Entry(text).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(text);
        }

        // GET: Texts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Text text = db.Texts.Find(id);
            if (text == null)
            {
                return HttpNotFound();
            }
            return View(text);
        }

        // POST: Texts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Text text = db.Texts.Find(id);
            db.Texts.Remove(text);
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
