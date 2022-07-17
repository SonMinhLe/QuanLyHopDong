using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyHopDong.Models;

namespace QuanLyHopDong.Controllers
{
    public class Hop_DongController : Controller
    {
        private QuanLyHopDongDBContext db = new QuanLyHopDongDBContext();

        // GET: Hop_Dong
        public ActionResult Index()
        {
            var hop_Dong = db.Hop_Dong.Include(h => h.Hang_Hoa).Include(h => h.Loai_Hop_Dong);
            return View(hop_Dong.ToList());
        }

        // GET: Hop_Dong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hop_Dong hop_Dong = db.Hop_Dong.Find(id);
            if (hop_Dong == null)
            {
                return HttpNotFound();
            }
            return View(hop_Dong);
        }

        // GET: Hop_Dong/Create
        public ActionResult Create()
        {
            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa");
            ViewBag.ID_Loai_Hop_Dong = new SelectList(db.Loai_Hop_Dong, "ID_Loai_Hop_Dong", "Ten_Loai_Hop_Dong");
            return View();
        }

        // POST: Hop_Dong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Hop_Dong,Ten_Hop_Dong,ID_Loai_Hop_Dong,Ten_Cong_Ty,Ngay_Ky_Hop_Dong,Ngay_Ket_Thuc,ID_Hang_Hoa,So_Luong,Don_Gia,Thanh_Tien,Trang_Thai,Nguoi_Tao_HD,Ngay_Tao_HD,Nguoi_Cap_Nhat,Ngay_Cap_Nhat,FilePath,FileName")] Hop_Dong hop_Dong)
        {
            if (ModelState.IsValid)
            {
                hop_Dong.Trang_Thai = "Khởi tạo";
                hop_Dong.Thanh_Tien = hop_Dong.Don_Gia * hop_Dong.So_Luong;
                db.Hop_Dong.Add(hop_Dong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa", hop_Dong.ID_Hang_Hoa);
            ViewBag.ID_Loai_Hop_Dong = new SelectList(db.Loai_Hop_Dong, "ID_Loai_Hop_Dong", "Ten_Loai_Hop_Dong", hop_Dong.ID_Loai_Hop_Dong);
            return View(hop_Dong);
        }

        // GET: Hop_Dong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hop_Dong hop_Dong = db.Hop_Dong.Find(id);
            if (hop_Dong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa", hop_Dong.ID_Hang_Hoa);
            ViewBag.ID_Loai_Hop_Dong = new SelectList(db.Loai_Hop_Dong, "ID_Loai_Hop_Dong", "Ten_Loai_Hop_Dong", hop_Dong.ID_Loai_Hop_Dong);
            return View(hop_Dong);
        }

        // POST: Hop_Dong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Hop_Dong,Ten_Hop_Dong,ID_Loai_Hop_Dong,Ten_Cong_Ty,Ngay_Ky_Hop_Dong,Ngay_Ket_Thuc,ID_Hang_Hoa,So_Luong,Don_Gia,Thanh_Tien,Trang_Thai,Nguoi_Tao_HD,Ngay_Tao_HD,Nguoi_Cap_Nhat,Ngay_Cap_Nhat,FilePath,FileName")] Hop_Dong hop_Dong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hop_Dong).State = EntityState.Modified;
                hop_Dong.Thanh_Tien = hop_Dong.Don_Gia * hop_Dong.So_Luong;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa", hop_Dong.ID_Hang_Hoa);
            ViewBag.ID_Loai_Hop_Dong = new SelectList(db.Loai_Hop_Dong, "ID_Loai_Hop_Dong", "Ten_Loai_Hop_Dong", hop_Dong.ID_Loai_Hop_Dong);
            return View(hop_Dong);
        }

        // GET: Hop_Dong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hop_Dong hop_Dong = db.Hop_Dong.Find(id);
            if (hop_Dong == null)
            {
                return HttpNotFound();
            }
            return View(hop_Dong);
        }

        // POST: Hop_Dong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hop_Dong hop_Dong = db.Hop_Dong.Find(id);
            db.Hop_Dong.Remove(hop_Dong);
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

        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hop_Dong hop_Dong = db.Hop_Dong.Find(id);
            if (hop_Dong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Hang_Hoa = new SelectList(db.Hang_Hoa, "ID_Hang_Hoa", "Ten_Hang_Hoa", hop_Dong.ID_Hang_Hoa);
            ViewBag.ID_Loai_Hop_Dong = new SelectList(db.Loai_Hop_Dong, "ID_Loai_Hop_Dong", "Ten_Loai_Hop_Dong", hop_Dong.ID_Loai_Hop_Dong);
            return View(hop_Dong);
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, Hop_Dong hop_Dong)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    Hop_Dong hop_Dong2 = db.Hop_Dong.Find(hop_Dong.ID_Hop_Dong);
                    hop_Dong2.FileName = _FileName;
                    hop_Dong2.FilePath = _path;
                    db.SaveChanges();
                }
                ViewBag.Message = "Tải tệp tin thành công!!";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Có lỗi trong quá trình tải t!!";
                return View();
            }
        }
    }
}
