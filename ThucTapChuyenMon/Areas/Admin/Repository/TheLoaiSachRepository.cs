using ThucTapChuyenMon.Models;

namespace ThucTapChuyenMon.Areas.Admin.Repository
{
    public class TheLoaiSachRepository : ITheLoaiSachRepository
    {
        private readonly QltvApiContext _context;

        public TheLoaiSachRepository(QltvApiContext context)
        {
            _context = context;
        }
        public TheLoai Add(TheLoai theloai)
        {
            _context.Add(theloai);
            _context.SaveChanges();
            return theloai;
        }

        public TheLoai Delete(string matheloai)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TheLoai> GetAllTheLoai()
        {
            return _context.TheLoais;
        }

        public TheLoai GetTheLoai(string matheloai)
        {
            return _context.TheLoais.Find(matheloai);
        }

        public TheLoai Update(TheLoai theloai)
        {
            _context.Update(theloai);
            _context.SaveChanges();
            return theloai;
        }
    }
}
