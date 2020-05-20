using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Model;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        WebBanHangDbContext db = new WebBanHangDbContext();

        private const string CartName = "giohang";

        private CartModel PrepareCartModel()
        {
            var sessionCart = Session[CartName] as List<GioHang>;
            if (sessionCart == null) return null;
            var model = new CartModel
            {
                Items = sessionCart,
                TotalPrice = sessionCart.Sum(sp => (sp.iPrice ?? 0) * (sp.iSoLuong ?? 0))
            };

            return model;
        }

        public ActionResult Index()
        {
            var sessionCart = Session[CartName] as List<GioHang>;

            var model = PrepareCartModel();
            return View(model);
        }

        public ActionResult MiniCart()
        {
            var sessionCart = Session[CartName] as List<GioHang>;
            if (sessionCart == null)
                return PartialView(null);

            var model = new CartModel
            {
                Items = sessionCart,
                TotalPrice = sessionCart.Sum(sp => (sp.iPrice ?? 0) * (sp.iSoLuong ?? 0))
            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult AddToCart(string id)
        {
            var sp = db.SanPhams.Where(x => x.MaSanPham == id).FirstOrDefault();
            if (sp == null)
            {
                return Json(false);
            }

            var GH = Session[CartName] as List<GioHang>;
            if (GH == null)
            {
                GH = new List<GioHang>();
                Session[CartName] = GH;
            }

            var exists = GH.FirstOrDefault(gh => gh.iId == id);
            if (exists == null)
            {
                GioHang gh = new GioHang();
                gh.iId = sp.MaSanPham;
                gh.iName = sp.TenSanPham;
                gh.iImage = sp.HinhMinhHoa;
                gh.iSoLuong = 1;
                gh.iPrice = sp.DonGia;

                GH.Add(gh);
            }
            else
            {
                exists.iSoLuong++;
            }
            var model = PrepareCartModel();
            return PartialView("MiniCart", model);
            //return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public ActionResult IncrementQuantityForCartItem(string id)
        {
            var sp = db.SanPhams.Where(x => x.MaSanPham == id).FirstOrDefault();
            if (sp == null)
            {
                return Json(false);
            }

            var GH = Session[CartName] as List<GioHang>;
            if (GH == null)
            {
                return Json(false);
            }

            var exists = GH.FirstOrDefault(gh => gh.iId == id);
            if (exists != null)
            {
                exists.iSoLuong++;
            }

            var model = PrepareCartModel();
            return PartialView("_CartDetails", model);
        }

        [HttpPost]
        public ActionResult DecrementQuantityForCartItem(string id)
        {
            var sp = db.SanPhams.Where(x => x.MaSanPham == id).FirstOrDefault();
            if (sp == null)
            {
                return Json(false);
            }

            var GH = Session[CartName] as List<GioHang>;
            if (GH == null)
            {
                return Json(false);
            }

            var exists = GH.FirstOrDefault(gh => gh.iId == id);
            if (exists != null)
            {
                exists.iSoLuong--;
                if (exists.iSoLuong == 0)
                    GH.Remove(exists);
            }

            var model = PrepareCartModel();
            return PartialView("_CartDetails", model);
        }

        [HttpPost]
        public ActionResult RemoveFromCart(string id, bool inCart = false)
        {
            var sp = db.SanPhams.Where(x => x.MaSanPham == id).FirstOrDefault();
            if (sp == null)
            {
                return Json(false);
            }

            var GH = Session[CartName] as List<GioHang>;
            if (GH == null)
            {
                return Json(false);
            }

            var exists = GH.FirstOrDefault(gh => gh.iId == id);
            if (exists != null)
            {
                GH.Remove(exists);
            }
            var model = PrepareCartModel();
            return PartialView(inCart ? "_CartDetails" : "MiniCart", model);
        }
    }
}