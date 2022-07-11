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
    public class Nghiem_ThuController : Controller
    {
        private QuanLyHopDongDBContext db = new QuanLyHopDongDBContext();

        // GET: Nghiem_Thu
        public ActionResult Index()
        {
            var nghiem_Thu = db.Nghiem_Thu.Include(n => n.Hang_Hoa).Include(n => n.Hop_Dong).Include(n => n.Nguoi_Dung);
            return View(nghiem_Thu.ToList());
        }

        // GET: Nghiem_Thu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nghiem_Thu nghiem_Thu = db.Nghiem_Thu.Find(id);
            if (nghiem_Thu == null)
            {
                return HttpNotFound();
            }
            return View(nghiem_Thu);
        }

        // GET: Nghiem_Thu/Create
        public ActionResult Create()
        {
            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa");
            ViewBag.ID_Hop_dong = new SelectList(db.Hop_Dong.Where(x => x.Trang_Thai != "Đã nghiệm thu"), "ID_Hop_Dong", "Ten_Hop_Dong");
            ViewBag.Nguoi_Nghiem_Thu = new SelectList(db.Nguoi_Dung, "ID_Nguoi_Dung", "Ten_Dang_Nhap");
            return View();
        }

        // POST: Nghiem_Thu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Ngiem_Thu,Nguoi_Nghiem_Thu,Ngay_Nghiem_Thu,ID_Hang_Hoa,ID_Hop_dong,Trang_Thai")] Nghiem_Thu nghiem_Thu)
        {
            if (ModelState.IsValid)
            {
                db.Nghiem_Thu.Add(nghiem_Thu);
                nghiem_Thu.Trang_Thai = "Đã nghiệm thu";
                Hop_Dong hop_Dong = db.Hop_Dong.Find(nghiem_Thu.ID_Hop_dong);
                hop_Dong.Trang_Thai = "Đã nghiệm thu";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa", nghiem_Thu.ID_Hang_Hoa);
            ViewBag.ID_Hop_dong = new SelectList(db.Hop_Dong, "ID_Hop_Dong", "Ten_Hop_Dong", nghiem_Thu.ID_Hop_dong);
            ViewBag.Nguoi_Nghiem_Thu = new SelectList(db.Nguoi_Dung, "ID_Nguoi_Dung", "Ten_Dang_Nhap", nghiem_Thu.Nguoi_Nghiem_Thu);
            return View(nghiem_Thu);
        }

        // GET: Nghiem_Thu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nghiem_Thu nghiem_Thu = db.Nghiem_Thu.Find(id);
            if (nghiem_Thu == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa", nghiem_Thu.ID_Hang_Hoa);
            ViewBag.ID_Hop_dong = new SelectList(db.Hop_Dong, "ID_Hop_Dong", "Ten_Hop_Dong", nghiem_Thu.ID_Hop_dong);
            ViewBag.Nguoi_Nghiem_Thu = new SelectList(db.Nguoi_Dung, "ID_Nguoi_Dung", "Ten_Dang_Nhap", nghiem_Thu.Nguoi_Nghiem_Thu);
            return View(nghiem_Thu);
        }

        // POST: Nghiem_Thu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ngiem_Thu,Nguoi_Nghiem_Thu,Ngay_Nghiem_Thu,ID_Hang_Hoa,ID_Hop_dong,Trang_Thai")] Nghiem_Thu nghiem_Thu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nghiem_Thu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa", nghiem_Thu.ID_Hang_Hoa);
            ViewBag.ID_Hop_dong = new SelectList(db.Hop_Dong, "ID_Hop_Dong", "Ten_Hop_Dong", nghiem_Thu.ID_Hop_dong);
            ViewBag.Nguoi_Nghiem_Thu = new SelectList(db.Nguoi_Dung, "ID_Nguoi_Dung", "Ten_Dang_Nhap", nghiem_Thu.Nguoi_Nghiem_Thu);
            return View(nghiem_Thu);
        }

        // GET: Nghiem_Thu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nghiem_Thu nghiem_Thu = db.Nghiem_Thu.Find(id);
            if (nghiem_Thu == null)
            {
                return HttpNotFound();
            }
            return View(nghiem_Thu);
        }

        // POST: Nghiem_Thu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nghiem_Thu nghiem_Thu = db.Nghiem_Thu.Find(id);
            Hop_Dong hop_Dong = db.Hop_Dong.Find(nghiem_Thu.ID_Hop_dong);
            hop_Dong.Trang_Thai = "Đã xóa nghiệm thu";
            db.Nghiem_Thu.Remove(nghiem_Thu);
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
