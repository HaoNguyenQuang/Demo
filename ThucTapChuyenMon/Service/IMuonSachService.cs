using ThucTapChuyenMon.Models.MuonSachAPI;

namespace ThucTapChuyenMon.Service
{
    public interface IMuonSachService
    {
        Task AddToCart(ChiTiet_MuonSach chiTiet_MuonSach);
        Task AddToCartExsits(ChiTietMuonSachDTO chiTietMuonSachDTO);
    }
}
