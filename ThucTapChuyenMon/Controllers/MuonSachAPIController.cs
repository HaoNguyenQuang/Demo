using ThucTapChuyenMon.Models;
using ThucTapChuyenMon.Models.MuonSachAPI;
using ThucTapChuyenMon.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThucTapChuyenMon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuonSachAPIController : ControllerBase
    {
        private readonly IMuonSachService _muonSachService;
        QltvApiContext db = new QltvApiContext();
        public MuonSachAPIController(IMuonSachService gioHangService, QltvApiContext db)
        {
            _muonSachService = gioHangService;
            this.db = db;
        }
        [HttpGet("{maPhieuMuon}")]
        public async Task<IActionResult> getProduct(string maPhieuMuon)
        {
            var query = from product in db.Saches
                        join invoiceDetail in db.ChiTietPhieuMuons on product.MaSach equals invoiceDetail.MaSach
                        join invoice in db.PhieuMuons on invoiceDetail.MaPhieuMuon equals invoice.MaPhieuMuon
                        where invoice.MaPhieuMuon == maPhieuMuon
                        select new
                        {
                            product.MaSach,
                            product.TenSach,
                            product.AnhDaiDien,
                        };
            return Ok(query);
        }
        //Add thẳng vào hóa đơn
        [Route("invoiceDetailExsits")]
        [HttpPost]
        public async Task<IActionResult> AddToCartExsits([FromBody] ChiTietMuonSachDTO chiTietMuonSach)
        {
            try
            {
                await _muonSachService.AddToCartExsits(chiTietMuonSach);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //Add 1 lúc 2 đối tượng: hóa đơn và chi tiết hóa đơn
        [Route("invoiceDetail")]
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] ChiTiet_MuonSach chiTiet_MuonSach)
        {
            try
            {
                await _muonSachService.AddToCart(chiTiet_MuonSach);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //Xóa chi tiết phiếu mượn
        [HttpDelete("{maPhieuMuon}")]
        public async Task<IActionResult> deleteInvoice(string maPhieuMuon)
        {
            var invoiceDetail = db.ChiTietPhieuMuons.Where(x => x.MaPhieuMuon == maPhieuMuon).ToList();
            db.ChiTietPhieuMuons.RemoveRange(invoiceDetail);
            await db.SaveChangesAsync();
            return Ok(123);
        }

		//Update chi tiết phiếu mượn
		[HttpPut("{maPhieuMuon}")]
		public async Task<IActionResult> updateInvoice(string maPhieuMuon)
		{
			var invoice = db.PhieuMuons.FirstOrDefault(x => x.MaPhieuMuon == maPhieuMuon);
            invoice.TinhTrangPhieuMuon = "Đang mượn";
            db.PhieuMuons.Update(invoice);
			await db.SaveChangesAsync();
			return Ok(123);
		}
        
    }
}
