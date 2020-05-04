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
    public class SanPhamController : Controller
    {
        private WebBanHangDbContext db = new WebBanHangDbContext();

        // GET: Administrator/SanPham
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.ChatLieu).Include(s => s.DoiTuong).Include(s => s.KichCo).Include(s => s.NhaSanXuat).Include(s => s.TheLoai);
            return View(sanPhams.ToList());
        }

        // GET: Administrator/SanPham/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Administrator/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaChatLieu = new SelectList(db.ChatLieux, "MaChatLieu", "TenChatLieu");
            ViewBag.MaDoiTuong = new SelectList(db.DoiTuongs, "MaDoiTuong", "TenDoiTuong");
            ViewBag.MaKichCo = new SelectList(db.KichCoes, "MaKichCo", "TenKichCo");
            ViewBag.MaNhaSanXuat = new SelectList(db.NhaSanXuats, "MaNhaSanXuat", "TenNhaSanXuat");
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai");
            return View();
        }

        // POST: Administrator/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,MaDoiTuong,MaTheLoai,MaKichCo,MaChatLieu,MaNhaSanXuat,DonViTinh,SoLuong,SoLuongBan,DonGia,MoTa,NgayCapNhat,HinhMinhHoa")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChatLieu = new SelectList(db.ChatLieux, "MaChatLieu", "TenChatLieu", sanPham.MaChatLieu);
            ViewBag.MaDoiTuong = new SelectList(db.DoiTuongs, "MaDoiTuong", "TenDoiTuong", sanPham.MaDoiTuong);
            ViewBag.MaKichCo = new SelectList(db.KichCoes, "MaKichCo", "TenKichCo", sanPham.MaKichCo);
            ViewBag.MaNhaSanXuat = new SelectList(db.NhaSanXuats, "MaNhaSanXuat", "TenNhaSanXuat", sanPham.MaNhaSanXuat);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", sanPham.MaTheLoai);
            return View(sanPham);
        }

        // GET: Administrator/SanPham/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChatLieu = new SelectList(db.ChatLieux, "MaChatLieu", "TenChatLieu", sanPham.MaChatLieu);
            ViewBag.MaDoiTuong = new SelectList(db.DoiTuongs, "MaDoiTuong", "TenDoiTuong", sanPham.MaDoiTuong);
            ViewBag.MaKichCo = new SelectList(db.KichCoes, "MaKichCo", "TenKichCo", sanPham.MaKichCo);
            ViewBag.MaNhaSanXuat = new SelectList(db.NhaSanXuats, "MaNhaSanXuat", "TenNhaSanXuat", sanPham.MaNhaSanXuat);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", sanPham.MaTheLoai);
            return View(sanPham);
        }

        // POST: Administrator/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,MaDoiTuong,MaTheLoai,MaKichCo,MaChatLieu,MaNhaSanXuat,DonViTinh,SoLuong,SoLuongBan,DonGia,MoTa,NgayCapNhat,HinhMinhHoa")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChatLieu = new SelectList(db.ChatLieux, "MaChatLieu", "TenChatLieu", sanPham.MaChatLieu);
            ViewBag.MaDoiTuong = new SelectList(db.DoiTuongs, "MaDoiTuong", "TenDoiTuong", sanPham.MaDoiTuong);
            ViewBag.MaKichCo = new SelectList(db.KichCoes, "MaKichCo", "TenKichCo", sanPham.MaKichCo);
            ViewBag.MaNhaSanXuat = new SelectList(db.NhaSanXuats, "MaNhaSanXuat", "TenNhaSanXuat", sanPham.MaNhaSanXuat);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", sanPham.MaTheLoai);
            return View(sanPham);
        }

        // GET: Administrator/SanPham/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Administrator/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
