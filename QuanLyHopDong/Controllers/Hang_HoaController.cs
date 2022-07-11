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
    public class Hang_HoaController : Controller
    {
        private QuanLyHopDongDBContext db = new QuanLyHopDongDBContext();

        // GET: Hang_Hoa
        public ActionResult Index()
        {
            var hang_Hoa = db.Hang_Hoa.Include(h => h.Loai_Hang);
            return View(hang_Hoa.ToList());
        }

        // GET: Hang_Hoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang_Hoa hang_Hoa = db.Hang_Hoa.Find(id);
            if (hang_Hoa == null)
            {
                return HttpNotFound();
            }
            return View(hang_Hoa);
        }

        // GET: Hang_Hoa/Create
        public ActionResult Create()
        {
            ViewBag.ID_Loai_Hang_Hoa = new SelectList(db.Loai_Hang, "ID_Loai_Hàng", "Ten_Loai_Hang");
            return View();
        }

        // POST: Hang_Hoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Hang_Hoa,Ten_Hang_Hoa,ID_Loai_Hang_Hoa,Don_Vi_Tinh,Hang_San_Xuat")] Hang_Hoa hang_Hoa)
        {
            if (ModelState.IsValid)
            {
                db.Hang_Hoa.Add(hang_Hoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Loai_Hang_Hoa = new SelectList(db.Loai_Hang, "ID_Loai_Hàng", "Ten_Loai_Hang", hang_Hoa.ID_Loai_Hang_Hoa);
            return View(hang_Hoa);
        }

        // GET: Hang_Hoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang_Hoa hang_Hoa = db.Hang_Hoa.Find(id);
            if (hang_Hoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Loai_Hang_Hoa = new SelectList(db.Loai_Hang, "ID_Loai_Hàng", "Ten_Loai_Hang", hang_Hoa.ID_Loai_Hang_Hoa);
            return View(hang_Hoa);
        }

        // POST: Hang_Hoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Hang_Hoa,Ten_Hang_Hoa,ID_Loai_Hang_Hoa,Don_Vi_Tinh,Hang_San_Xuat")] Hang_Hoa hang_Hoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hang_Hoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Loai_Hang_Hoa = new SelectList(db.Loai_Hang, "ID_Loai_Hàng", "Ten_Loai_Hang", hang_Hoa.ID_Loai_Hang_Hoa);
            return View(hang_Hoa);
        }

        // GET: Hang_Hoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hang_Hoa hang_Hoa = db.Hang_Hoa.Find(id);
            if (hang_Hoa == null)
            {
                return HttpNotFound();
            }
            return View(hang_Hoa);
        }

        // POST: Hang_Hoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hang_Hoa hang_Hoa = db.Hang_Hoa.Find(id);
            db.Hang_Hoa.Remove(hang_Hoa);
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
