using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThucTapChuyenMon.Models;

public partial class QltvApiContext : DbContext
{
    public QltvApiContext()
    {
    }

    public QltvApiContext(DbContextOptions<QltvApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }

    public virtual DbSet<ChiTietPhieuTra> ChiTietPhieuTras { get; set; }

    public virtual DbSet<DocGia> DocGia { get; set; }

    public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }

    public virtual DbSet<PhieuTra> PhieuTras { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TRole> TRoles { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TheLoai> TheLoais { get; set; }

    public virtual DbSet<ViTri> ViTris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UO2968G\\SQLEXPRESS;Initial Catalog=QLTV_API;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietPhieuMuon>(entity =>
        {
            entity.HasKey(e => new { e.MaPhieuMuon, e.MaSach }).HasName("PK__ChiTietP__0FEB756028FF59DE");

            entity.ToTable("ChiTietPhieuMuon");

            entity.Property(e => e.MaPhieuMuon).HasMaxLength(255);
            entity.Property(e => e.MaSach).HasMaxLength(255);

            entity.HasOne(d => d.MaPhieuMuonNavigation).WithMany(p => p.ChiTietPhieuMuons)
                .HasForeignKey(d => d.MaPhieuMuon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__4F7CD00D");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietPhieuMuons)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaSac__5070F446");
        });

        modelBuilder.Entity<ChiTietPhieuTra>(entity =>
        {
            entity.HasKey(e => new { e.MaPhieuTra, e.MaSach }).HasName("PK__ChiTietP__D6AB5D0430BFA718");

            entity.ToTable("ChiTietPhieuTra");

            entity.Property(e => e.MaPhieuTra).HasMaxLength(255);
            entity.Property(e => e.MaSach).HasMaxLength(255);
            entity.Property(e => e.NhaXuatBan).HasMaxLength(255);
            entity.Property(e => e.TenSach).HasMaxLength(255);
            entity.Property(e => e.TinhTrangSach).HasMaxLength(255);

            entity.HasOne(d => d.MaPhieuTraNavigation).WithMany(p => p.ChiTietPhieuTras)
                .HasForeignKey(d => d.MaPhieuTra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__5535A963");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietPhieuTras)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaSac__5629CD9C");
        });

        modelBuilder.Entity<DocGia>(entity =>
        {
            entity.HasKey(e => e.MaDocGia).HasName("PK__DocGia__F165F94587BCAC7A");

            entity.Property(e => e.MaDocGia).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.TaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenDocGia).HasMaxLength(255);

            entity.HasOne(d => d.TaiKhoanNavigation).WithMany(p => p.DocGia)
                .HasForeignKey(d => d.TaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocGia__TaiKhoan__45F365D3");
        });

        modelBuilder.Entity<NhaXuatBan>(entity =>
        {
            entity.HasKey(e => e.MaNxb).HasName("PK__NhaXuatB__3A19482C76EBE190");

            entity.ToTable("NhaXuatBan");

            entity.Property(e => e.MaNxb)
                .HasMaxLength(255)
                .HasColumnName("MaNXB");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.TenNxb)
                .HasMaxLength(255)
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA4793857A91");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.TaiKhoan).HasMaxLength(255);

            entity.HasOne(d => d.TaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.TaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__TaiKho__48CFD27E");
        });

        modelBuilder.Entity<PhieuMuon>(entity =>
        {
            entity.HasKey(e => e.MaPhieuMuon).HasName("PK__PhieuMuo__C4C82222AF6071F2");

            entity.ToTable("PhieuMuon");

            entity.Property(e => e.MaPhieuMuon).HasMaxLength(255);
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaDocGia).HasMaxLength(255);
            entity.Property(e => e.MaNhanVien).HasMaxLength(255);
            entity.Property(e => e.NgayMuon).HasColumnType("date");
            entity.Property(e => e.NgayTra).HasColumnType("date");
            entity.Property(e => e.NgayTraThucTe).HasColumnType("date");
            entity.Property(e => e.TinhTrangPhieuMuon).HasMaxLength(255);

            entity.HasOne(d => d.MaDocGiaNavigation).WithMany(p => p.PhieuMuons)
                .HasForeignKey(d => d.MaDocGia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuMuon__MaDoc__4CA06362");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.PhieuMuons)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuMuon__MaNha__4BAC3F29");
        });

        modelBuilder.Entity<PhieuTra>(entity =>
        {
            entity.HasKey(e => e.MaPhieuTra).HasName("PK__PhieuTra__1D880A46301E6B89");

            entity.ToTable("PhieuTra");

            entity.Property(e => e.MaPhieuTra).HasMaxLength(255);
            entity.Property(e => e.MaPhieuMuon).HasMaxLength(255);
            entity.Property(e => e.NgayTra).HasColumnType("date");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__Sach__B235742D1FAAEFCD");

            entity.ToTable("Sach");

            entity.Property(e => e.MaSach).HasMaxLength(255);
            entity.Property(e => e.AnhDaiDien).HasMaxLength(255);
            entity.Property(e => e.MaNxb)
                .HasMaxLength(255)
                .HasColumnName("MaNXB");
            entity.Property(e => e.MaTheLoai).HasMaxLength(255);
            entity.Property(e => e.MaViTri).HasMaxLength(255);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenSach).HasMaxLength(255);
            entity.Property(e => e.TenTacGia).HasMaxLength(255);
            entity.Property(e => e.TinhTrangSach).HasMaxLength(255);

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sach__MaNXB__403A8C7D");

            entity.HasOne(d => d.MaTheLoaiNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTheLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sach__MaTheLoai__3F466844");

            entity.HasOne(d => d.MaViTriNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaViTri)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sach__MaViTri__3E52440B");
        });

        modelBuilder.Entity<TRole>(entity =>
        {
            entity.HasKey(e => e.MaRole).HasName("PK__tRole__0639A0FD59BFAF5B");

            entity.ToTable("tRole");

            entity.Property(e => e.MaRole).HasMaxLength(255);
            entity.Property(e => e.TenRole).HasMaxLength(255);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.TaiKhoan1).HasName("PK__TaiKhoan__D5B8C7F1FBE3D8FB");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.TaiKhoan1)
                .HasMaxLength(255)
                .HasColumnName("TaiKhoan");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.MaRole).HasMaxLength(255);
            entity.Property(e => e.MatKhau).HasMaxLength(255);

            entity.HasOne(d => d.MaRoleNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__MaRole__4316F928");
        });

        modelBuilder.Entity<TheLoai>(entity =>
        {
            entity.HasKey(e => e.MaTheLoai).HasName("PK__TheLoai__D73FF34A9FBC2254");

            entity.ToTable("TheLoai");

            entity.Property(e => e.MaTheLoai).HasMaxLength(255);
            entity.Property(e => e.TenTheLoai).HasMaxLength(255);
        });

        modelBuilder.Entity<ViTri>(entity =>
        {
            entity.HasKey(e => e.MaViTri).HasName("PK__ViTri__B08B247F34DE0D4A");

            entity.ToTable("ViTri");

            entity.Property(e => e.MaViTri).HasMaxLength(255);
            entity.Property(e => e.GiaSach).HasMaxLength(255);
            entity.Property(e => e.KeSach).HasMaxLength(255);
            entity.Property(e => e.NganSach).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
