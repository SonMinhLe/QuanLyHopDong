using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyHopDong.Models;

namespace QuanLyHopDong.Controllers
{
    public class Loai_Hop_DongController : Controller
    {
        private QuanLyHopDongDBContext db = new QuanLyHopDongDBContext();

        // GET: Loai_Hop_Dong
        public ActionResult Index()
        {
            return View(db.Loai_Hop_Dong.ToList());
        }

        // GET: Loai_Hop_Dong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_Hop_Dong loai_Hop_Dong = db.Loai_Hop_Dong.Find(id);
            if (loai_Hop_Dong == null)
            {
                return HttpNotFound();
            }
            return View(loai_Hop_Dong);
        }

        // GET: Loai_Hop_Dong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loai_Hop_Dong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Loai_Hop_Dong,Ten_Loai_Hop_Dong")] Loai_Hop_Dong loai_Hop_Dong)
        {
            if (ModelState.IsValid)
            {
                db.Loai_Hop_Dong.Add(loai_Hop_Dong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loai_Hop_Dong);
        }

        // GET: Loai_Hop_Dong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_Hop_Dong loai_Hop_Dong = db.Loai_Hop_Dong.Find(id);
            if (loai_Hop_Dong == null)
            {
                return HttpNotFound();
            }
            return View(loai_Hop_Dong);
        }

        // POST: Loai_Hop_Dong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Loai_Hop_Dong,Ten_Loai_Hop_Dong")] Loai_Hop_Dong loai_Hop_Dong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai_Hop_Dong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loai_Hop_Dong);
        }

        // GET: Loai_Hop_Dong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_Hop_Dong loai_Hop_Dong = db.Loai_Hop_Dong.Find(id);
            if (loai_Hop_Dong == null)
            {
                return HttpNotFound();
            }
            return View(loai_Hop_Dong);
        }

        // POST: Loai_Hop_Dong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loai_Hop_Dong loai_Hop_Dong = db.Loai_Hop_Dong.Find(id);
            db.Loai_Hop_Dong.Remove(loai_Hop_Dong);
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
