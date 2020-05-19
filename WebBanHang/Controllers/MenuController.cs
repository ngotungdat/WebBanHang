using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Model;

namespace WebBanHang.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        WebBanHangDbContext db = new WebBanHangDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuPartial()
        {
            var listSP = db.SanPhams;
            return PartialView(listSP);
        }      
    }
}