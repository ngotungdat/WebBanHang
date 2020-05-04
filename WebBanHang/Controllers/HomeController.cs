using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Model;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        WebBanHangDbContext db = new WebBanHangDbContext();
        public ActionResult Index()
        {
            ViewBag.SanPhamMoi = db.SanPhams.OrderByDescending(x => x.NgayCapNhat).Take(4).ToList();
            ViewBag.SanPhamBanChay = db.SanPhams.OrderByDescending(x => x.SoLuongBan).Take(4).ToList();
            return View();
        }

        public ActionResult Detailes(string id)
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
    }
}