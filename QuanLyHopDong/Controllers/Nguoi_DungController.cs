using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyHopDong.Models;

namespace QuanLyHopDong.Controllers
{
    public class Nguoi_DungController : Controller
    {
        private QuanLyHopDongDBContext db = new QuanLyHopDongDBContext();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Nguoi_Dung
        public ActionResult Index()
        {
            return View(db.Nguoi_Dung.ToList());
        }

        // GET: Nguoi_Dung/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoi_Dung nguoi_Dung = db.Nguoi_Dung.Find(id);
            if (nguoi_Dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_Dung);
        }

        // GET: Nguoi_Dung/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nguoi_Dung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Nguoi_Dung,Ten_Dang_Nhap,Mat_Khau,Ho_Ten,Ngay_Sinh")] Nguoi_Dung nguoi_Dung)
        {
            if (ModelState.IsValid)
            {
                db.Nguoi_Dung.Add(nguoi_Dung);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(nguoi_Dung);
        }

        // GET: Nguoi_Dung/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoi_Dung nguoi_Dung = db.Nguoi_Dung.Find(id);
            if (nguoi_Dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_Dung);
        }

        // POST: Nguoi_Dung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Nguoi_Dung,Ten_Dang_Nhap,Mat_Khau,Ho_Ten,Ngay_Sinh")] Nguoi_Dung nguoi_Dung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguoi_Dung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nguoi_Dung);
        }

        // GET: Nguoi_Dung/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nguoi_Dung nguoi_Dung = db.Nguoi_Dung.Find(id);
            if (nguoi_Dung == null)
            {
                return HttpNotFound();
            }
            return View(nguoi_Dung);
        }

        // POST: Nguoi_Dung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nguoi_Dung nguoi_Dung = db.Nguoi_Dung.Find(id);
            db.Nguoi_Dung.Remove(nguoi_Dung);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectiontoString()
        {
            con.ConnectionString = "Data Source=DESKTOP-F5SMNE4;Initial Catalog=QuanLyHopDong;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Nguoi_Dung acc)
        {
            connectiontoString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Nguoi_Dung where Ten_Dang_Nhap ='" + acc.Ten_Dang_Nhap + "' and Mat_Khau = '" + acc.Mat_Khau + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                FormsAuthentication.SetAuthCookie(acc.Ten_Dang_Nhap,true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                con.Close();

                return RedirectToAction("Error", "Nguoi_Dung");
            }

        }
        public ActionResult Error()
        {
            return View();
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
