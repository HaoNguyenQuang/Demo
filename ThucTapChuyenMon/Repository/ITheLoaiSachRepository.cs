using ThucTapChuyenMon.Models;

namespace ThucTapChuyenMon.Repository
{
    public interface ITheLoaiSachRepository
    {
        TheLoai Add(TheLoai theloai);
        TheLoai Update(TheLoai theloai);
        TheLoai Delete(string matheloai);
        TheLoai GetTheLoai(string matheloai);
        IEnumerable<TheLoai> GetAllTheLoai();
    }
}
