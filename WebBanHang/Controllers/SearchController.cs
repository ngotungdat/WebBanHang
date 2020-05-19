using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Model;

namespace WebBanHang.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        WebBanHangDbContext db = new WebBanHangDbContext();
        public ActionResult Search(string strSearch)
        {
            var txtSearch = from s in db.SanPhams select s;
            if (!string.IsNullOrEmpty(strSearch))
            {
                txtSearch = txtSearch.Where(x => x.TenSanPham.Contains(strSearch));
            }
            return View(txtSearch);
        }
    }
}