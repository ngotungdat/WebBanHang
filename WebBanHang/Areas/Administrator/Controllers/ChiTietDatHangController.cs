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
    public class ChiTietDatHangController : Controller
    {
        private WebBanHangDbContext db = new WebBanHangDbContext();

        // GET: Administrator/ChiTietDatHang
        public ActionResult Index()
        {
            var chiTietDatHangs = db.ChiTietDatHangs.Include(c => c.KhachHang).Include(c => c.SanPham);
            return View(chiTietDatHangs.ToList());
        }

        // GET: Administrator/ChiTietDatHang/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDatHang);
        }

        // GET: Administrator/ChiTietDatHang/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang");
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: Administrator/ChiTietDatHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoHoaDon,MaSanPham,MaKhachHang,SoLuong,DonGia,ThanhTien,NgayDatHang,NgayGiaoHang")] ChiTietDatHang chiTietDatHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDatHangs.Add(chiTietDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", chiTietDatHang.MaKhachHang);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
            return View(chiTietDatHang);
        }

        // GET: Administrator/ChiTietDatHang/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", chiTietDatHang.MaKhachHang);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
            return View(chiTietDatHang);
        }

        // POST: Administrator/ChiTietDatHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoHoaDon,MaSanPham,MaKhachHang,SoLuong,DonGia,ThanhTien,NgayDatHang,NgayGiaoHang")] ChiTietDatHang chiTietDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", chiTietDatHang.MaKhachHang);
            ViewBag.MaSanPham = new SelectList(db.SanPhams, "MaSanPham", "TenSanPham", chiTietDatHang.MaSanPham);
            return View(chiTietDatHang);
        }

        // GET: Administrator/ChiTietDatHang/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
            if (chiTietDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDatHang);
        }

        // POST: Administrator/ChiTietDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietDatHang chiTietDatHang = db.ChiTietDatHangs.Find(id);
            db.ChiTietDatHangs.Remove(chiTietDatHang);
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
