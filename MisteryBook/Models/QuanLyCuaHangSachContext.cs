using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MisteryBook.Models;

public partial class QuanLyCuaHangSachContext : DbContext
{
    public QuanLyCuaHangSachContext()
    {
    }

    public QuanLyCuaHangSachContext(DbContextOptions<QuanLyCuaHangSachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonMua> ChiTietDonMuas { get; set; }

    public virtual DbSet<ChiTietDonNhap> ChiTietDonNhaps { get; set; }

    public virtual DbSet<HoaDonMua> HoaDonMuas { get; set; }

    public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<TacGium> TacGia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-D260V60;Database=QuanLyCuaHangSach;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonMua>(entity =>
        {
            entity.HasKey(e => new { e.SoHdmua, e.MaSach }).HasName("PK_chitiethdmua");

            entity.ToTable("ChiTietDonMua");

            entity.Property(e => e.SoHdmua).HasColumnName("SoHDMua");
            entity.Property(e => e.MaSach)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietDonMuas)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chitiethdmua_masach");

            entity.HasOne(d => d.SoHdmuaNavigation).WithMany(p => p.ChiTietDonMuas)
                .HasForeignKey(d => d.SoHdmua)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chitiethdmua_sohd");
        });

        modelBuilder.Entity<ChiTietDonNhap>(entity =>
        {
            entity.HasKey(e => new { e.SoHdnh, e.MaSach }).HasName("PK_hdnh_masach");

            entity.ToTable("ChiTietDonNhap");

            entity.Property(e => e.SoHdnh).HasColumnName("SoHDNH");
            entity.Property(e => e.MaSach)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.ChiTietDonNhaps)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chitietdonnhap_masach");

            entity.HasOne(d => d.SoHdnhNavigation).WithMany(p => p.ChiTietDonNhaps)
                .HasForeignKey(d => d.SoHdnh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_chitietnhap_hdnhap");
        });

        modelBuilder.Entity<HoaDonMua>(entity =>
        {
            entity.HasKey(e => e.SoHdmua).HasName("PK_hdmua");

            entity.ToTable("HoaDonMua");

            entity.Property(e => e.SoHdmua)
                .ValueGeneratedNever()
                .HasColumnName("SoHDMua");
            entity.Property(e => e.MaKh)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MucGiamGia).HasDefaultValue(0.0);
            entity.Property(e => e.NgayMua).HasColumnType("datetime");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDonMuas)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hdmua_khachhang");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDonMuas)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hdmua_nhanvien");
        });

        modelBuilder.Entity<HoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.SoHdnh).HasName("PK_hdnhap");

            entity.ToTable("HoaDonNhap");

            entity.Property(e => e.SoHdnh).HasColumnName("SoHDNH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MaNxb)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("MaNXB");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hdnhap_nv");

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNxb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hdnhap_nxb");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK_makh");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.GioiTinh).HasMaxLength(6);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<NhaXuatBan>(entity =>
        {
            entity.HasKey(e => e.MaNxb).HasName("PK_manxb");

            entity.ToTable("NhaXuatBan");

            entity.Property(e => e.MaNxb)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("MaNXB");
            entity.Property(e => e.DiaChi).HasMaxLength(30);
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNxb)
                .HasMaxLength(30)
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK_manv");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.DiaChi).HasMaxLength(30);
            entity.Property(e => e.GioiTinh).HasMaxLength(6);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.NgayVaoLam).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("TenNV");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK_masach_matg");

            entity.ToTable("Sach");

            entity.Property(e => e.MaSach)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.MaNxb)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("MaNXB");
            entity.Property(e => e.TenSach).HasMaxLength(50);
            entity.Property(e => e.TheLoai).HasMaxLength(30);

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sach_nxb");

            entity.HasMany(d => d.MaTgs).WithMany(p => p.MaSaches)
                .UsingEntity<Dictionary<string, object>>(
                    "SachTacGium",
                    r => r.HasOne<TacGium>().WithMany()
                        .HasForeignKey("MaTg")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_matg"),
                    l => l.HasOne<Sach>().WithMany()
                        .HasForeignKey("MaSach")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_masach"),
                    j =>
                    {
                        j.HasKey("MaSach", "MaTg").HasName("PK_sach_tg");
                        j.ToTable("Sach_TacGia");
                        j.IndexerProperty<string>("MaSach")
                            .HasMaxLength(5)
                            .IsUnicode(false);
                        j.IndexerProperty<string>("MaTg")
                            .HasMaxLength(5)
                            .IsUnicode(false)
                            .HasColumnName("MaTG");
                    });
        });

        modelBuilder.Entity<TacGium>(entity =>
        {
            entity.HasKey(e => e.MaTg).HasName("PK_matg");

            entity.Property(e => e.MaTg)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MaTG");
            entity.Property(e => e.TenTg)
                .HasMaxLength(50)
                .HasColumnName("TenTG");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
