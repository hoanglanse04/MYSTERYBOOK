CREATE DATABASE WebsiteBanSach;
USE WebsiteBanSach;


-- Bảng User: Quản lý người dùng
CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(100) UNIQUE NOT NULL,
    Email NVARCHAR(255) UNIQUE NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('Admin', 'NhanVien', 'KhachHang')),
    HoTen NVARCHAR(255) NULL,
    SDT NVARCHAR(15) NULL,
    DiaChi NVARCHAR(255),
    NgayDangKy DATE DEFAULT GETDATE()
);

-- Bảng LoaiSach: Quản lý thể loại sách
CREATE TABLE LoaiSach (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL
);

-- Bảng TacGia: Quản lý thông tin tác giả
CREATE TABLE TacGia (
    MaTacGia INT IDENTITY(1,1) PRIMARY KEY,
    TenTacGia NVARCHAR(255) NOT NULL,
    NgaySinh DATE,
    QueQuan NVARCHAR(255),
    GhiChu NVARCHAR(500)
);

-- Bảng NhaXuatBan: Quản lý nhà xuất bản
CREATE TABLE NhaXuatBan (
    MaNXB INT IDENTITY(1,1) PRIMARY KEY,
    TenNXB NVARCHAR(255) NOT NULL,
    DiaChi NVARCHAR(255),
    SDT NVARCHAR(15),
    Email NVARCHAR(255) UNIQUE NULL
);

-- Bảng Sach: Thông tin sách
CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(255) NOT NULL,
    MaLoai INT NOT NULL,
    MaTacGia INT,
    MaNXB INT,
    NamXuatBan INT,
    GiaBan DECIMAL(10, 2) NOT NULL,
    SoLuongTon INT NOT NULL,
    MoTa NVARCHAR(1000),
    HinhAnh NVARCHAR(255),
    FOREIGN KEY (MaLoai) REFERENCES LoaiSach(MaLoai),
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia),
    FOREIGN KEY (MaNXB) REFERENCES NhaXuatBan(MaNXB)
);

-- Bảng DonHang: Thông tin đơn hàng của khách hàng
CREATE TABLE DonHang (
    SoDonHang INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT NOT NULL,
    MaNV INT,
    NgayLap DATE DEFAULT GETDATE(),
    TongSoLuong INT DEFAULT 0,
    TongTien DECIMAL(10, 2) DEFAULT 0,
    TrangThai NVARCHAR(50) DEFAULT N'Chờ xử lý' CHECK (TrangThai IN (N'Chờ Xử Lý',N'Đang Xử Lý', N'Đang Giao Hàng', N'Thành Công','Thất Bại')),
    FOREIGN KEY (MaKH) REFERENCES [User](UserID),
    FOREIGN KEY (MaNV) REFERENCES [User](UserID)
);

CREATE TABLE ChiTietDonHang (
    MaSach INT NOT NULL,
    SoDonHang INT NOT NULL,
    SoLuong INT NOT NULL,
    GiaBan DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (MaSach, SoDonHang),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach),
    FOREIGN KEY (SoDonHang) REFERENCES DonHang(SoDonHang)
);

-- Bảng NhaCungCap: Thông tin nhà cung cấp sách
CREATE TABLE NhaCungCap (
    MaNCC INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(255) NOT NULL,
    DiaChi NVARCHAR(255),
    SDT NVARCHAR(15) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL
);

-- Bảng DonNhap: Thông tin hóa đơn nhập sách
CREATE TABLE DonNhap (
    SoDonNhap INT IDENTITY(1,1) PRIMARY KEY,
    MaNCC INT NOT NULL,
    NgayNhap DATE DEFAULT GETDATE(),
    TongSoLuong INT DEFAULT 0,
    TongTien DECIMAL(10, 2) DEFAULT 0,
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

-- Bảng ChiTietDonNhap: Chi tiết sách được nhập
CREATE TABLE ChiTietDonNhap (
    MaSach INT NOT NULL,
    SoDonNhap INT NOT NULL,
    SoLuong INT NOT NULL,
    GiaNhap DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (MaSach, SoDonNhap),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach),
    FOREIGN KEY (SoDonNhap) REFERENCES DonNhap(SoDonNhap)
);

-- Thêm nhiều người dùng vào bảng User
INSERT INTO [User] (Username, Email, Password, Role, HoTen, SDT, DiaChi)
VALUES 
(N'admin2', N'admin2@website.com', N'password123', N'Admin', N'Nguyễn Văn B', N'0123456789', N'10 Đường ABC, TP.HCM'),
(N'nhanvien2', N'nv2@website.com', N'password123', N'NhanVien', N'Trần Thị C', N'0123456789', N'20 Đường XYZ, TP.HCM'),
(N'khachhang2', N'kh2@website.com', N'password123', N'KhachHang', N'Lê Thị D', N'0123456789', N'30 Đường DEF, TP.HCM'),
(N'khachhang3', N'kh3@website.com', N'password123', N'KhachHang', N'Nguyễn Thiện E', N'0123456789', N'40 Đường GHI, TP.HCM'),
(N'nhanvien3', N'nv3@website.com', N'password123', N'NhanVien', N'Phạm Minh F', N'0123456789', N'50 Đường JKL, TP.HCM');

-- Thêm nhiều thể loại sách vào bảng LoaiSach
INSERT INTO LoaiSach (TenLoai)
VALUES 
(N'Khoa học'),
(N'Văn học'),
(N'Tiểu thuyết'),
(N'Lịch sử'),
(N'Tâm lý'),
(N'Kinh tế'),
(N'Chính trị'),
(N'Nhân văn'),
(N'Sức khỏe'),
(N'Giải trí');

-- Thêm nhiều tác giả vào bảng TacGia
INSERT INTO TacGia (TenTacGia, NgaySinh, QueQuan, GhiChu)
VALUES 
(N'Nguyễn Trãi', '1380-11-07', N'Hà Tây', N'Tác giả của Bình Ngô đại cáo'),
(N'Hemingway', '1899-07-21', N'Mỹ', N'Tác giả của The Old Man and the Sea'),
(N'Shakespeare', '1564-04-23', N'Anh', N'Tác giả của Hamlet, Romeo and Juliet'),
(N'Albert Einstein', '1879-03-14', N'Đức', N'Tác giả của nhiều bài báo khoa học'),
(N'Haruki Murakami', '1949-01-12', N'Nhật Bản', N'Tác giả của Kafka on the Shore');

-- Thêm nhiều nhà xuất bản vào bảng NhaXuatBan
INSERT INTO NhaXuatBan (TenNXB, DiaChi, SDT, Email)
VALUES 
(N'NXB Kim Đồng', N'15 Đường A, TP.HCM', N'0123456789', N'nxb1@website.com'),
(N'NXB Trẻ', N'10 Đường B, Hà Nội', N'0123456789', N'nxb2@website.com'),
(N'NXB Giáo dục', N'50 Đường C, TP.HCM', N'0123456789', N'nxb3@website.com'),
(N'NXB Thế Giới', N'100 Đường D, TP.HCM', N'0123456789', N'nxb4@website.com'),
(N'NXB Lao Động', N'200 Đường E, Hà Nội', N'0123456789', N'nxb5@website.com');

-- Thêm nhiều sách vào bảng Sach
INSERT INTO Sach (TenSach, MaLoai, MaTacGia, MaNXB, NamXuatBan, GiaBan, SoLuongTon, MoTa, HinhAnh)
VALUES 
(N'Đắc Nhân Tâm', 5, 4, 1, 2000, 250.00, 100, N'Cuốn sách giúp phát triển kỹ năng giao tiếp và quản lý con người', N'dac_nhan_tam.jpg'),
(N'Đại Học Harvard - Tư Duy Và Lối Sống', 6, 5, 2, 2015, 300.00, 150, N'Sách giúp bạn có cái nhìn toàn diện về các giá trị sống và tư duy của những người thành công', N'dai_hoc_harvard.jpg'),
(N'Nhà Giả Kim', 3, 3, 3, 1988, 180.00, 200, N'Một câu chuyện về hành trình tìm kiếm ước mơ của một chàng trai', N'nha_gia_kim.jpg'),
(N'Tâm Lý Học Tội Phạm', 5, 4, 4, 2020, 220.00, 50, N'Tìm hiểu về tâm lý học trong tội phạm học', N'tam_ly_toi_pham.jpg'),
(N'Khiêu Vũ Với Lão Hòa Thượng', 4, 1, 5, 2017, 120.00, 80, N'Cuốn sách khám phá sự bình yên trong tâm hồn qua câu chuyện của một lão hòa thượng', N'khieu_vu_hoa_thuong.jpg');

-- Thêm nhiều đơn hàng vào bảng DonHang
INSERT INTO DonHang (MaKH, MaNV, NgayLap, TongSoLuong, TongTien, TrangThai)
VALUES 
(3, 2, '2024-12-19', 3, 540.00, N'Chờ xử lý'),
(4, 1, '2024-12-20', 2, 400.00, N'Đang giao hàng'),
(5, 3, '2024-12-21', 5, 800.00, N'Đã nhận hàng'),
(2, 1, '2024-12-22', 4, 600.00, N'Chờ xử lý'),
(1, 2, '2024-12-23', 1, 150.00, N'Đang giao hàng');

-- Thêm nhiều chi tiết đơn hàng vào bảng ChiTietDonHang
INSERT INTO ChiTietDonHang (MaSach, SoDonHang, SoLuong, GiaBan)
VALUES 
(1, 1, 1, 150.00),
(2, 1, 1, 180.00),
(3, 2, 1, 200.00),
(4, 3, 1, 220.00),
(5, 4, 2, 250.00),
(1, 5, 1, 150.00);

-- Thêm nhiều nhà cung cấp vào bảng NhaCungCap
INSERT INTO NhaCungCap (TenNCC, DiaChi, SDT, Email)
VALUES 
(N'NCC Sách Giáo Dục', N'200 Đường F, TP.HCM', N'0123456789', N'ncc1@website.com'),
(N'NCC Sách Tiểu Thuyết', N'300 Đường G, TP.HCM', N'0123456789', N'ncc2@website.com'),
(N'NCC Sách Tâm Lý', N'400 Đường H, TP.HCM', N'0123456789', N'ncc3@website.com'),
(N'NCC Sách Kinh Tế', N'500 Đường I, TP.HCM', N'0123456789', N'ncc4@website.com'),
(N'NCC Sách Chính Trị', N'600 Đường J, TP.HCM', N'0123456789', N'ncc5@website.com');

-- Thêm nhiều hóa đơn nhập sách vào bảng DonNhap
INSERT INTO DonNhap (MaNCC, NgayNhap, TongSoLuong, TongTien)
VALUES 
(1, '2024-12-18', 200, 10000.00),
(2, '2024-12-19', 150, 7500.00),
(3, '2024-12-20', 100, 5000.00),
(4, '2024-12-21', 300, 15000.00),
(5, '2024-12-22', 50, 2500.00);

-- Thêm nhiều chi tiết nhập sách vào bảng ChiTietDonNhap
INSERT INTO ChiTietDonNhap (MaSach, SoDonNhap, SoLuong, GiaNhap)
VALUES 
(1, 1, 100, 50.00),
(2, 2, 100, 50.00),
(3, 3, 50, 60.00),
(4, 4, 200, 70.00),
(5, 5, 50, 80.00);





--
select * from DonHang		
select * from [User]	
