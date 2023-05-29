using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiAPIController : ControllerBase
    {
        QltvApiContext db = new QltvApiContext();
        [HttpGet]
        public List<TheLoai> GetTheLoaiList()
        {
            return db.TheLoais.ToList();
        }
        [HttpGet("{keyword}")]
        public List<TheLoai> GetTheLoaiListTen(string keyword)
        {
            var theloais = db.TheLoais.Where(tl => tl.TenTheLoai.Contains(keyword)).ToList();
            return theloais;
        }


        [HttpPost]
        public bool ThemTheLoai(string MaTheLoai, string TenTheLoai)
        {

            var theloai = new TheLoai
            {
                MaTheLoai = MaTheLoai,
                TenTheLoai = TenTheLoai,
            };
            db.TheLoais.AddAsync(theloai);
            db.SaveChanges();
            return true;

        }
        [HttpPut]
        public bool SuaTheLoai(string MaTheLoai, string TenTheLoai)
        {
            var theloai = db.TheLoais.FirstOrDefault(x=>x.MaTheLoai== MaTheLoai);
            theloai.TenTheLoai = TenTheLoai;
            db.TheLoais.Update(theloai);
            db.SaveChanges();
            return true;
        }
        [HttpDelete]
        public bool DeleteTheLoai(string MaTheLoai)
        {
            try
            {

                TheLoai theloai = db.TheLoais.FirstOrDefault(x => x.MaTheLoai == MaTheLoai);
                if (theloai == null) return false;
                db.TheLoais.Remove(theloai);
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
