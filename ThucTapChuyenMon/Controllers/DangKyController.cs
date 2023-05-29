using Microsoft.AspNetCore.Mvc;
using ThucTapChuyenMon.Models;
using ThucTapChuyenMon.Models.Authentication;

namespace ThucTapChuyenMon.Controllers
{
    public class DangKyController : Controller
    {
        QltvApiContext db = new QltvApiContext();
        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }

        public IActionResult DangKy()
        {
            var lastCustomer = db.DocGia.ToList();
            int lastId = splitId(lastCustomer.OrderByDescending(x => splitId(x.MaDocGia)).FirstOrDefault().MaDocGia.ToString());
            ViewBag.lastId = lastId;
            return View(lastId);
        }
    }
}
