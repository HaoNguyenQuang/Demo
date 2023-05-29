using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViTriAPIController : ControllerBase
    {
        QltvApiContext db = new QltvApiContext();
        [HttpGet]
        public List<ViTri> GetViTriList()
        {
            return db.ViTris.ToList();
        }
        [HttpGet("{keyword1}")]
        public List<ViTri> GetViTriListTen(string keyword1)
        {
            var vitri = db.ViTris.Where(tl => tl.MaViTri.Contains(keyword1)).ToList();
            return vitri;
        }
        [HttpPost]
        public bool ThemTheLoai(string MaViTri, string KeSach, string NganSach, string GiaSach, int ViTriTrenGia)
        {

            var vitri = new ViTri
            {
                MaViTri = MaViTri,
                KeSach = KeSach,
                NganSach = NganSach,
                GiaSach = GiaSach,
                ViTriTrenGia = ViTriTrenGia,
                
            };
            db.ViTris.AddAsync(vitri);
            db.SaveChanges();
            return true;

        }
        [HttpPut]
        public bool SuaTheLoai(string MaViTri, string KeSach, string NganSach, string GiaSach, int ViTriTrenGia)
        {
            var vitri = db.ViTris.FirstOrDefault(x => x.MaViTri == MaViTri);
            vitri.KeSach = KeSach;
            vitri.NganSach = NganSach;
            vitri.GiaSach = GiaSach;
            vitri.ViTriTrenGia = ViTriTrenGia;
            db.ViTris.Update(vitri);
            db.SaveChanges();
            return true;
        }
        [HttpDelete]
        public bool DeleteViTri(string MaViTri)
        {
            try
            {

                ViTri vitri = db.ViTris.FirstOrDefault(x => x.MaViTri == MaViTri);
                if (vitri == null) return false;
                db.ViTris.Remove(vitri);
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
