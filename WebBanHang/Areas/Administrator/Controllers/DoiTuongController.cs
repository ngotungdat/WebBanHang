using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Model;

namespace WebBanHang.Areas.Administrator.Controllers
{
    public class DoiTuongController : Controller
    {
        private WebBanHangDbContext db = new WebBanHangDbContext();

        // GET: Administrator/DoiTuong
        public ActionResult Index()
        {
            return View(db.DoiTuongs.ToList());
        }

        // GET: Administrator/DoiTuong/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuong doiTuong = db.DoiTuongs.Find(id);
            if (doiTuong == null)
            {
                return HttpNotFound();
            }
            return View(doiTuong);
        }

        // GET: Administrator/DoiTuong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/DoiTuong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDoiTuong,TenDoiTuong")] DoiTuong doiTuong)
        {
            if (ModelState.IsValid)
            {
                db.DoiTuongs.Add(doiTuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doiTuong);
        }

        // GET: Administrator/DoiTuong/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuong doiTuong = db.DoiTuongs.Find(id);
            if (doiTuong == null)
            {
                return HttpNotFound();
            }
            return View(doiTuong);
        }

        // POST: Administrator/DoiTuong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDoiTuong,TenDoiTuong")] DoiTuong doiTuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doiTuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doiTuong);
        }

        // GET: Administrator/DoiTuong/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoiTuong doiTuong = db.DoiTuongs.Find(id);
            if (doiTuong == null)
            {
                return HttpNotFound();
            }
            return View(doiTuong);
        }

        // POST: Administrator/DoiTuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DoiTuong doiTuong = db.DoiTuongs.Find(id);
            db.DoiTuongs.Remove(doiTuong);
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
