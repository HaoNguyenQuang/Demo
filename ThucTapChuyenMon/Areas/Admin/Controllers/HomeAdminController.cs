using ThucTapChuyenMon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThucTapChuyenMon.Models.Authentication;

namespace ThucTapChuyenMon.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QltvApiContext db = new QltvApiContext();
        [Route("")]
        [Route("index")]
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
        [Authentication]
        [Route("SachTheoTheLoai")]
        public IActionResult SachTheoTheLoai(String MaTheLoai)
        {
            var theloai = db.Saches.Find(MaTheLoai);
            //ViewBag.TenTheLoai = theloai.TenTheLoai;
            var lstSachTheoTheLoai = db.Saches.Where(x => x.MaTheLoai == MaTheLoai).ToList();
            return View(lstSachTheoTheLoai);
        }
        [Route("Split")]
        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(1, id.Length - 1);
            return int.Parse(res);
        }
        public int splitId1(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }
        public int splitId2(string id)
        {
            //KH002 
            string res = id.Substring(3, id.Length - 3);
            return int.Parse(res);
        }
        [Authentication]
        [Route("TheLoai")]
        public IActionResult TheLoai()
        {
            return View();
        }
        [Authentication]
        [Route("ThemTheLoai")]
        public IActionResult ThemTheLoai()
        {
            var lastTheLoai = db.TheLoais.ToList();
            int lastId = splitId1(lastTheLoai.OrderByDescending(x => splitId1(x.MaTheLoai)).FirstOrDefault().MaTheLoai.ToString());
            ViewBag.lastId = lastId;
            return View();
        }
        [Authentication]
        [Route("Sach")]
        public IActionResult Sach()
        {
            return View();
        }
        [Authentication]
        [Route("SuaTheLoai")]
        public IActionResult SuaTheLoai(string maTL)
        {
            var theLoai = db.TheLoais.FirstOrDefault(x => x.MaTheLoai == maTL);
            return View(theLoai);
        }
        [Authentication]
        [Route("ChiTietSach")]
        public IActionResult ChiTietSach(string maSach)
        {
            var theLoai = db.Saches.FirstOrDefault(x => x.MaSach == maSach);
            return View(theLoai);
        }
        [Authentication]
        [Route("ThemSach")]
        public IActionResult ThemSach()
        {
            var lastSach = db.Saches.ToList();
            int lastId = splitId(lastSach.OrderByDescending(x => splitId(x.MaSach)).FirstOrDefault().MaSach.ToString());
            ViewBag.lastId = lastId;
            ViewBag.MaViTri = new SelectList(db.ViTris.ToList(), "MaViTri", "MaViTri");
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList(), "MaTheLoai", "TenTheLoai");
            ViewBag.MaNxb = new SelectList(db.NhaXuatBans.ToList(), "MaNxb", "TenNxb");
            return View();
        }
        [Authentication]
        [Route("SuaSach")]
        public IActionResult SuaSach(string maSach)
        {
            var sach = db.Saches.FirstOrDefault(x => x.MaSach == maSach);
            ViewBag.MaViTri = new SelectList(db.ViTris.ToList(), "MaViTri", "MaViTri");
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList(), "MaTheLoai", "TenTheLoai");
            ViewBag.MaNxb = new SelectList(db.NhaXuatBans.ToList(), "MaNxb", "TenNxb");
            return View(sach);
        }
        [Authentication]
        [Route("SuaSachTheoTheLoai")]
        public IActionResult SuaSachTheoTheLoai(string maSach)
        {
            var sach = db.Saches.FirstOrDefault(x => x.MaSach == maSach);
            ViewBag.MaViTri = new SelectList(db.ViTris.ToList(), "MaViTri", "MaViTri");
            ViewBag.MaTheLoai = new SelectList(db.TheLoais.ToList(), "MaTheLoai", "TenTheLoai");
            ViewBag.MaNxb = new SelectList(db.NhaXuatBans.ToList(), "MaNxb", "TenNxb");
            return View(sach);
        }
        [Authentication]
        [Route("XoaSachTheoTheLoai")]
        public IActionResult DeleteSach(string MaSach)
        {

            //var sach = db.Saches.FirstOrDefault(x => x.MaSach == MaSach);
            db.Remove(db.Saches.Find(MaSach));
            db.SaveChanges();
            return RedirectToAction("Sach");
        }
        [Authentication]
        [Route("ViTri")]
        public IActionResult ViTri()
        {
            return View();
        }
        [Authentication]
        [Route("ThemViTri")]
        public IActionResult ThemViTri()
        {
            var lastViTri = db.ViTris.ToList();
            int lastId = splitId1(lastViTri.OrderByDescending(x => splitId1(x.MaViTri)).FirstOrDefault().MaViTri.ToString());
            ViewBag.lastId = lastId;
            return View();
        }
        [Authentication]
        [Route("SuaViTri")]
        public IActionResult SuaViTri(string maViTri)
        {
            var vitri = db.ViTris.FirstOrDefault(x => x.MaViTri == maViTri);
            return View(vitri);
        }
        [Authentication]
        [Route("NhaXuatBan")]
        public IActionResult NhaXuatBan(int? page)
        {
            var lstNXB = db.NhaXuatBans.ToList();
            return View(lstNXB);
        }
        [Authentication]
        [Route("SuaNXB")]
        public IActionResult SuaNXB(string MaNxb)
        {
            var nxb = db.NhaXuatBans.FirstOrDefault(x => x.MaNxb == MaNxb);
            return View(nxb);
        }
        [Authentication]
        [Route("ThemNXB")]
        public IActionResult ThemNXB()
        {
            var lastTheLoai = db.NhaXuatBans.ToList();
            int lastId = splitId2(lastTheLoai.OrderByDescending(x => splitId2(x.MaNxb)).FirstOrDefault().MaNxb.ToString());
            ViewBag.lastId = lastId;
            return View();
        }
        [Authentication]
        [Route("DocGia")]
        public IActionResult DocGia(int? page)
        {
            var lstDocGia = db.DocGia.ToList();
            return View(lstDocGia);
        }
        [Authentication]
        [Route("DangXuat")]
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
        [Authentication]
        [Route("PhieuMuon")]
        public IActionResult PhieuMuon()
        {
            return View();
        }
        [Authentication]
        [Route("SuaPhieuMuon")]
        public IActionResult SuaPhieuMuon(string maPhieuMuon)
        {
            List<string> trangthai = new List<string>();
            trangthai.Add("Đang Mượn");
            trangthai.Add("Đã Trả");
            ViewBag.TrangThai = new SelectList(trangthai);
            var pm = db.PhieuMuons.FirstOrDefault(x => x.MaPhieuMuon == maPhieuMuon);
            return View(pm);
        }
        [Authentication]
        [Route("ChiTietPhieuMuon")]
        public IActionResult ChiTietPhieuMuon(string maPM)
        {
            var phieuMuon = db.PhieuMuons.FirstOrDefault(x => x.MaPhieuMuon == maPM);
            return View(phieuMuon);
        }
        [Authentication]
        [Route("PhieuTra")]
        public IActionResult PhieuTra()
        {
            return View();
        }
        [Authentication]
        [Route("ChiTietPhieuTra")]
        public IActionResult ChiTietPhieuTra(string maPM)
        {
            var phieuMuon = db.PhieuMuons.FirstOrDefault(x => x.MaPhieuMuon == maPM);
            return View(phieuMuon);
        }
    }
}


