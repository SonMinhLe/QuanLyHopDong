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
    public class Phu_LucController : Controller
    {
        private QuanLyHopDongDBContext db = new QuanLyHopDongDBContext();

        // GET: Phu_Luc
        public ActionResult Index()
        {
            var phu_Luc = db.Phu_Luc.Include(p => p.Hop_Dong);
            return View(phu_Luc.ToList());
        }

        // GET: Phu_Luc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phu_Luc phu_Luc = db.Phu_Luc.Find(id);
            if (phu_Luc == null)
            {
                return HttpNotFound();
            }
            return View(phu_Luc);
        }

        // GET: Phu_Luc/Create
        public ActionResult Create()
        {
            ViewBag.ID_Hop_Dong = new SelectList(db.Hop_Dong, "ID_Hop_Dong", "Ten_Hop_Dong");
            return View();
        }

        // POST: Phu_Luc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Phu_Luc,So_Phu_Luc,Ngay_Ky,Nguoi_Tao_Phu_Luc,Nguoi_Ky_Phu_Luc,Gia_Tri_HD_Truoc,Gia_Tri_HD_Sau,ID_Hop_Dong,FileName,FilePath")] Phu_Luc phu_Luc)
        {
            if (ModelState.IsValid)
            {
                db.Phu_Luc.Add(phu_Luc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Hop_Dong = new SelectList(db.Hop_Dong, "ID_Hop_Dong", "Ten_Hop_Dong", phu_Luc.ID_Hop_Dong);
            return View(phu_Luc);
        }

        // GET: Phu_Luc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phu_Luc phu_Luc = db.Phu_Luc.Find(id);
            if (phu_Luc == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hop_Dong = new SelectList(db.Hop_Dong, "ID_Hop_Dong", "Ten_Hop_Dong", phu_Luc.ID_Hop_Dong);
            return View(phu_Luc);
        }

        // POST: Phu_Luc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Phu_Luc,So_Phu_Luc,Ngay_Ky,Nguoi_Tao_Phu_Luc,Nguoi_Ky_Phu_Luc,Gia_Tri_HD_Truoc,Gia_Tri_HD_Sau,ID_Hop_Dong,FileName,FilePath")] Phu_Luc phu_Luc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phu_Luc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Hop_Dong = new SelectList(db.Hop_Dong, "ID_Hop_Dong", "Ten_Hop_Dong", phu_Luc.ID_Hop_Dong);
            return View(phu_Luc);
        }

        // GET: Phu_Luc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phu_Luc phu_Luc = db.Phu_Luc.Find(id);
            if (phu_Luc == null)
            {
                return HttpNotFound();
            }
            return View(phu_Luc);
        }

        // POST: Phu_Luc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phu_Luc phu_Luc = db.Phu_Luc.Find(id);
            db.Phu_Luc.Remove(phu_Luc);
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
