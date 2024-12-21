using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MisteryBook.Models;

public partial class WebsiteBanSachContext : DbContext
{
    public WebsiteBanSachContext()
    {
    }

    public WebsiteBanSachContext(DbContextOptions<WebsiteBanSachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<ChiTietDonNhap> ChiTietDonNhaps { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<DonNhap> DonNhaps { get; set; }

    public virtual DbSet<LoaiSach> LoaiSaches { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TacGium> TacGias { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => new { e.MaSach, e.SoDonHang }).HasName("PK__ChiTietD__76975F578B8AB576");

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.GiaBan).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDo__MaSac__5165187F");

            entity.HasOne(d => d.SoDonHangNavigation).WithMany(p => p.ChiTietDonHangs)
                .HasForeignKey(d => d.SoDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDo__SoDon__52593CB8");
        });

        modelBuilder.Entity<ChiTietDonNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaSach, e.SoDonNhap }).HasName("PK__ChiTietD__FBB4DE060376EA31");

            entity.ToTable("ChiTietDonNhap");

            entity.Property(e => e.GiaNhap).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietDonNhaps)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDo__MaSac__5DCAEF64");

            entity.HasOne(d => d.SoDonNhapNavigation).WithMany(p => p.ChiTietDonNhaps)
                .HasForeignKey(d => d.SoDonNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDo__SoDon__5EBF139D");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.SoDonHang).HasName("PK__DonHang__4A22B7AD8EA8DE86");

            entity.ToTable("DonHang");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayLap).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TongSoLuong).HasDefaultValue(0);
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Chờ xử lý");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DonHangMaKhNavigations)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DonHang__MaKH__4D94879B");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.DonHangMaNvNavigations)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__DonHang__MaNV__4E88ABD4");
        });

        modelBuilder.Entity<DonNhap>(entity =>
        {
            entity.HasKey(e => e.SoDonNhap).HasName("PK__DonNhap__981AA2B52CA51FED");

            entity.ToTable("DonNhap");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.NgayNhap).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TongSoLuong).HasDefaultValue(0);
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.DonNhaps)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DonNhap__MaNCC__5AEE82B9");
        });

        modelBuilder.Entity<LoaiSach>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiSach__730A575943DCF775");

            entity.ToTable("LoaiSach");

            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEB793A7D62");

            entity.ToTable("NhaCungCap");

            entity.HasIndex(e => e.Email, "UQ__NhaCungC__A9D10534C0D75264").IsUnique();

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(255)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhaXuatBan>(entity =>
        {
            entity.HasKey(e => e.MaNxb).HasName("PK__NhaXuatB__3A19482C99B6E1A1");

            entity.ToTable("NhaXuatBan");

            entity.HasIndex(e => e.Email, "UQ__NhaXuatB__A9D10534AD6621F1").IsUnique();

            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNxb)
                .HasMaxLength(255)
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__Sach__B235742D853DF60F");

            entity.ToTable("Sach");

            entity.Property(e => e.GiaBan).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaNxb).HasColumnName("MaNXB");
            entity.Property(e => e.MoTa).HasMaxLength(1000);
            entity.Property(e => e.TenSach).HasMaxLength(255);

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sach__MaLoai__440B1D61");

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .HasConstraintName("FK__Sach__MaNXB__45F365D3");

            entity.HasOne(d => d.MaTacGiaNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTacGia)
                .HasConstraintName("FK__Sach__MaTacGia__44FF419A");
        });

        modelBuilder.Entity<TacGium>(entity =>
        {
            entity.HasKey(e => e.MaTacGia).HasName("PK__TacGia__F24E675613DB94B4");

            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.QueQuan).HasMaxLength(255);
            entity.Property(e => e.TenTacGia).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC86871A9D");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E4A308CB8C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D1053484D43EC0").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.NgayDangKy).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .HasColumnName("SDT");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
