using System.Web.Mvc;
using WebBanHang.Model;
using System.Linq;

namespace WebBanHang.Controllers
{
    public class CategoryController : Controller
    {
        WebBanHangDbContext db = new WebBanHangDbContext();

        public ActionResult Index(string categoryId)
        {
            var catQuery = from cat in db.TheLoais
                           where cat.MaTheLoai == categoryId
                           select cat;
            var category = catQuery.FirstOrDefault();

            if (category == null)
                return RedirectToAction("Index", "Home");

            var query = from sp in db.SanPhams
                        let cat = sp.TheLoai
                        where cat.MaTheLoai == categoryId
                        select sp;
            var products = query.ToList();

            ViewBag.CategoryName = category.TenTheLoai;

            return View(products);
        }
    }
}