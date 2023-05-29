using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NXBAPIController : ControllerBase
    {
        //1. Lấy thông tin của toàn bộ NXB
        QltvApiContext db = new QltvApiContext();


        [HttpGet]
        public List<NhaXuatBan> GetNXBLists()
        {
            List<NhaXuatBan> nxbapi = db.NhaXuatBans.ToList();
            return nxbapi;
        }
        [HttpGet("{keyword2}")]
        public List<NhaXuatBan> GetTheLoaiListTen(string keyword2)
        {
            var nxb = db.NhaXuatBans.Where(tl => tl.TenNxb.Contains(keyword2)).ToList();
            return nxb;
        }
        [HttpPost]
        public bool ThemNXB(string maNxb, string diaChi,
        string tenNxb)
        {
            try
            {
                NhaXuatBan nhaXuatBan = new NhaXuatBan();
                nhaXuatBan.MaNxb = maNxb;
                nhaXuatBan.DiaChi = diaChi;
                nhaXuatBan.TenNxb = tenNxb;

                db.NhaXuatBans.AddAsync(nhaXuatBan);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        public bool SuaTheLoai(string maNxb, string diaChi,
        string tenNxb)
        {
            var nhaXuatBan = db.NhaXuatBans.FirstOrDefault(x => x.MaNxb == maNxb);
            nhaXuatBan.DiaChi = diaChi;
            nhaXuatBan.TenNxb = tenNxb;
            db.NhaXuatBans.Update(nhaXuatBan);
            db.SaveChanges();
            return true;
        }
        [HttpDelete]
        public bool DeleteNXB(string id)
        {
            try
            {
                //Lấy mã NXB
                NhaXuatBan nxb = db.NhaXuatBans.FirstOrDefault(x => x.MaNxb == id);
                if (nxb == null)
                    return false;
                db.NhaXuatBans.Remove(nxb);
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
