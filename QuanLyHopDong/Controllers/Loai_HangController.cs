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
    public class Loai_HangController : Controller
    {
        private QuanLyHopDongDBContext db = new QuanLyHopDongDBContext();

        // GET: Loai_Hang
        public ActionResult Index()
        {
            return View(db.Loai_Hang.ToList());
        }

        // GET: Loai_Hang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_Hang loai_Hang = db.Loai_Hang.Find(id);
            if (loai_Hang == null)
            {
                return HttpNotFound();
            }
            return View(loai_Hang);
        }

        // GET: Loai_Hang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loai_Hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Loai_Hàng,Ten_Loai_Hang")] Loai_Hang loai_Hang)
        {
            if (ModelState.IsValid)
            {
                db.Loai_Hang.Add(loai_Hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loai_Hang);
        }

        // GET: Loai_Hang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_Hang loai_Hang = db.Loai_Hang.Find(id);
            if (loai_Hang == null)
            {
                return HttpNotFound();
            }
            return View(loai_Hang);
        }

        // POST: Loai_Hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Loai_Hàng,Ten_Loai_Hang")] Loai_Hang loai_Hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai_Hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loai_Hang);
        }

        // GET: Loai_Hang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_Hang loai_Hang = db.Loai_Hang.Find(id);
            if (loai_Hang == null)
            {
                return HttpNotFound();
            }
            return View(loai_Hang);
        }

        // POST: Loai_Hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loai_Hang loai_Hang = db.Loai_Hang.Find(id);
            db.Loai_Hang.Remove(loai_Hang);
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
