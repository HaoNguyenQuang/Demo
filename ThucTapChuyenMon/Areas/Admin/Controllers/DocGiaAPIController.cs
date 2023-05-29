using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ThucTapChuyenMon.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocGiaAPIController : ControllerBase
    {
        //1. Lấy thông tin của toàn bộ Độc Giả
        QltvApiContext db = new QltvApiContext();


        [HttpGet]
        public List<DocGia> GetDocGiaLists()
        {
            List<DocGia> docgiaapi = db.DocGia.ToList();
            return docgiaapi;
        }

        [HttpGet("{keyword3}")]
        public List<DocGia> GetTheLoaiListTen(string keyword3)
        {
            var docgia = db.DocGia.Where(tl => tl.TenDocGia.Contains(keyword3)).ToList();
            return docgia;
        }

        [HttpDelete]
        public bool DeleteDocGia(string id)
        {
            try
            {
                //Lấy mã độc giả
                DocGia customer = db.DocGia.FirstOrDefault(x => x.MaDocGia == id);
                if (customer == null)
                    return false;
                db.DocGia.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
