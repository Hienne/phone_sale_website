USE [master]
GO
/****** Object:  Database [BanDienThoai]    Script Date: 7/10/2020 5:29:43 PM ******/
CREATE DATABASE [BanDienThoai]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BanDienThoai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BanDienThoai.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BanDienThoai_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BanDienThoai_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BanDienThoai] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BanDienThoai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BanDienThoai] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BanDienThoai] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BanDienThoai] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BanDienThoai] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BanDienThoai] SET ARITHABORT OFF 
GO
ALTER DATABASE [BanDienThoai] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BanDienThoai] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BanDienThoai] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BanDienThoai] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BanDienThoai] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BanDienThoai] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BanDienThoai] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BanDienThoai] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BanDienThoai] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BanDienThoai] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BanDienThoai] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BanDienThoai] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BanDienThoai] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BanDienThoai] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BanDienThoai] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BanDienThoai] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BanDienThoai] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BanDienThoai] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BanDienThoai] SET  MULTI_USER 
GO
ALTER DATABASE [BanDienThoai] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BanDienThoai] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BanDienThoai] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BanDienThoai] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BanDienThoai] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BanDienThoai] SET QUERY_STORE = OFF
GO
USE [BanDienThoai]
GO
/****** Object:  Table [dbo].[ChiTietDonDatHang]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonDatHang](
	[MaCTDDH] [int] NOT NULL,
	[MaDDH] [int] NULL,
	[MaSP] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_ChiTietDonDatHang] PRIMARY KEY CLUSTERED 
(
	[MaCTDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaCTPN] [int] NOT NULL,
	[MaPN] [int] NULL,
	[DonGiaNhap] [int] NULL,
	[SoLuongNhap] [int] NULL,
	[MaSP] [int] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaCTPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonDatHang]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonDatHang](
	[MaDDH] [int] NOT NULL,
	[NgayDat] [datetime] NULL,
	[DiaChiGiao] [nvarchar](255) NULL,
	[MaNguoiDung] [int] NULL,
	[MaTrangThai] [int] NULL,
 CONSTRAINT [PK_DonDatHang] PRIMARY KEY CLUSTERED 
(
	[MaDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiNguoiDung]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNguoiDung](
	[MaLND] [int] NOT NULL,
	[TenLoaiND] [nvarchar](100) NULL,
 CONSTRAINT [PK_LoaiNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaLND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[TaiKhoan] [nvarchar](100) NULL,
	[MatKhau] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[SDT] [nvarchar](10) NULL,
	[MaLND] [int] NULL,
	[GioiTinh] [nvarchar](15) NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[NgaySinh] [datetime] NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] NOT NULL,
	[TenNCC] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[SDT] [nvarchar](20) NULL,
	[Fax] [nvarchar](20) NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[MaNSX] [int] NOT NULL,
	[TenNSX] [nvarchar](255) NULL,
	[Logo] [nvarchar](255) NULL,
 CONSTRAINT [PK_NhaSanXuat] PRIMARY KEY CLUSTERED 
(
	[MaNSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPN] [int] NOT NULL,
	[MaNCC] [int] NULL,
	[NgayNhap] [datetime] NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] NOT NULL,
	[TenSP] [nvarchar](255) NULL,
	[MoTa] [nvarchar](255) NULL,
	[SLTon] [int] NULL,
	[MaNSX] [int] NULL,
	[SoLanMua] [int] NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[MaNCC] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 7/10/2020 5:29:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[MaTrangThai] [int] NOT NULL,
	[TenTrangThai] [nvarchar](100) NULL,
 CONSTRAINT [PK_TrangThai] PRIMARY KEY CLUSTERED 
(
	[MaTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuong], [DonGia]) VALUES (1, 1, 1, 2, 700)
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuong], [DonGia]) VALUES (2, 2, 2, 1, 899)
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuong], [DonGia]) VALUES (3, 2, 3, 1, 400)
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuong], [DonGia]) VALUES (4, 3, 4, 3, 200)
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuong], [DonGia]) VALUES (5, 3, 1, 4, 700)
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuong], [DonGia]) VALUES (6, 3, 2, 4, 899)
INSERT [dbo].[ChiTietDonDatHang] ([MaCTDDH], [MaDDH], [MaSP], [SoLuong], [DonGia]) VALUES (7, 4, 1, 1, 700)
GO
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [DonGiaNhap], [SoLuongNhap], [MaSP]) VALUES (1, 1, 650, 20, 1)
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [DonGiaNhap], [SoLuongNhap], [MaSP]) VALUES (2, 2, 850, 20, 2)
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [DonGiaNhap], [SoLuongNhap], [MaSP]) VALUES (3, 3, 350, 20, 3)
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [DonGiaNhap], [SoLuongNhap], [MaSP]) VALUES (4, 4, 150, 20, 4)
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [DonGiaNhap], [SoLuongNhap], [MaSP]) VALUES (5, 5, 750, 20, 1)
INSERT [dbo].[ChiTietPhieuNhap] ([MaCTPN], [MaPN], [DonGiaNhap], [SoLuongNhap], [MaSP]) VALUES (6, 6, 300, 20, 4)
GO
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayDat], [DiaChiGiao], [MaNguoiDung], [MaTrangThai]) VALUES (1, CAST(N'2020-06-30T00:00:00.000' AS DateTime), N'Hà Nam', 4, 1)
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayDat], [DiaChiGiao], [MaNguoiDung], [MaTrangThai]) VALUES (2, CAST(N'2020-07-01T00:00:00.000' AS DateTime), N'Hà Nội', 3, 1)
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayDat], [DiaChiGiao], [MaNguoiDung], [MaTrangThai]) VALUES (3, CAST(N'2020-07-05T00:00:00.000' AS DateTime), N'Hà Nội', 2, 0)
INSERT [dbo].[DonDatHang] ([MaDDH], [NgayDat], [DiaChiGiao], [MaNguoiDung], [MaTrangThai]) VALUES (4, CAST(N'2020-07-10T04:36:12.713' AS DateTime), N'Ha Noi', 3, 1)
GO
INSERT [dbo].[LoaiNguoiDung] ([MaLND], [TenLoaiND]) VALUES (1, N'Admin')
INSERT [dbo].[LoaiNguoiDung] ([MaLND], [TenLoaiND]) VALUES (2, N'Customer')
GO
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (1, N'Nguyen Hien', N'hien', N'123456', N'Ha Noi', N'hien456@gmail.com', N'09654852', 1, N'nam', N'rose.jpg', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (2, N'Nguyen A', N'nguyen_a', N'123456', N'Ha Noi', N'a@gmail.com', N'46130460', 2, N'nữ', N'rose2.jpg', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (3, N'Nguyen B', N'nguyen_b', N'123456', N'Ha Noi', N'b@gmail.com', N'5131321', 2, N'nam', N'rose3.jpg', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (4, N'Nguyen C', N'nguyen_c', N'123456', N'Ha Nam', N'c@gmail.com', N'4651355', 2, N'nữ', N'rose4.jpg', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (5, N'Nguyen D', N'nguyen_d', N'123456', N'Ha Nam', N'd123@gmail.com', N'3265465', 1, N'nam', N'rose5.jpg', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (6, N'hehe', N'huhu', N'123456', N'ha nam', N'hidlf@gmail.com', N'0966085805', 2, N'nữ', N'icon-profile-cgv.png', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (7, N'hihi', N'huhu3', N'123456', N'ha nam', N'hedf@gmail.com', N'0966085804', 1, N'nam', N'rose6.jpg', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (8, N'fsfs', N'sdfs', N'123456', N'ha nam', N'hien@gmail.com', N'0966085800', 1, N'nam', N'icon-profile-cgv.png', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [TaiKhoan], [MatKhau], [DiaChi], [Email], [SDT], [MaLND], [GioiTinh], [HinhAnh], [NgaySinh]) VALUES (9, N'hine', N'abc', N'123456', N'ha nam', N'hienw@gmail.com', N'0966085801', 2, N'nam', N'rose6.jpg', CAST(N'1999-03-26T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT], [Fax]) VALUES (1, N'Japan', N'abc/abc', N'japan@gmail.com', N'012345678', N'0777883')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT], [Fax]) VALUES (2, N'Ha Noi', N'Ha Noi', N'slkfj@gmail.com', N'013265485', N'5506540')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [Email], [SDT], [Fax]) VALUES (3, N'America', N'123/147', N'sldj@gmail.com', N'655665621', N'3465465')
GO
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [Logo]) VALUES (1, N'Nokia', N'brand1.png')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [Logo]) VALUES (2, N'Canon', N'brand2.png')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [Logo]) VALUES (3, N'Samsung', N'brand3.png')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [Logo]) VALUES (4, N'Apple', N'brand4.png')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [Logo]) VALUES (5, N'htc', N'brand5.png')
INSERT [dbo].[NhaSanXuat] ([MaNSX], [TenNSX], [Logo]) VALUES (6, N'LG', N'brand6.png')
GO
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [NgayNhap]) VALUES (1, 1, CAST(N'2020-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [NgayNhap]) VALUES (2, 2, CAST(N'2020-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [NgayNhap]) VALUES (3, 3, CAST(N'2020-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [NgayNhap]) VALUES (4, 1, CAST(N'2020-06-20T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [NgayNhap]) VALUES (5, 1, CAST(N'2020-07-07T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [NgayNhap]) VALUES (6, 2, CAST(N'2020-07-07T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [NgayNhap]) VALUES (7, 2, CAST(N'2020-07-08T00:00:00.000' AS DateTime))
INSERT [dbo].[PhieuNhap] ([MaPN], [MaNCC], [NgayNhap]) VALUES (8, 1, CAST(N'2020-07-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [SLTon], [MaNSX], [SoLanMua], [HinhAnh], [MaNCC], [DonGia]) VALUES (1, N'Samsung Galaxy s5-2015', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tristique, diam in consequat iaculis, est purus iaculis mauris, imperdiet facilisis ante ligula at nulla. Quisque volutpat nulla risus, id maximus ex aliquet ut.', 40, 3, 20, N'product-1.jpg', 1, 700)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [SLTon], [MaNSX], [SoLanMua], [HinhAnh], [MaNCC], [DonGia]) VALUES (2, N'Nokia Lumia 1320', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tristique, diam in consequat iaculis, est purus iaculis mauris, imperdiet facilisis ante ligula at nulla. Quisque volutpat nulla risus, id maximus ex aliquet ut.', 30, 1, 15, N'product-2.jpg', 2, 899)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [SLTon], [MaNSX], [SoLanMua], [HinhAnh], [MaNCC], [DonGia]) VALUES (3, N'LG Leon 2015', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tristique, diam in consequat iaculis, est purus iaculis mauris, imperdiet facilisis ante ligula at nulla. Quisque volutpat nulla risus, id maximus ex aliquet ut.', 15, 6, 30, N'product-3.jpg', 3, 400)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [SLTon], [MaNSX], [SoLanMua], [HinhAnh], [MaNCC], [DonGia]) VALUES (4, N'Sony microsoft', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tristique, diam in consequat iaculis, est purus iaculis mauris, imperdiet facilisis ante ligula at nulla. Quisque volutpat nulla risus, id maximus ex aliquet ut.', 50, 2, 50, N'product-4.jpg', 1, 200)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [SLTon], [MaNSX], [SoLanMua], [HinhAnh], [MaNCC], [DonGia]) VALUES (5, N'iPhone 6', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tristique, diam in consequat iaculis, est purus iaculis mauris, imperdiet facilisis ante ligula at nulla. Quisque volutpat nulla risus, id maximus ex aliquet ut.', 60, 4, 30, N'product-5.jpg', 2, 120)
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [MoTa], [SLTon], [MaNSX], [SoLanMua], [HinhAnh], [MaNCC], [DonGia]) VALUES (6, N'Samsung gallaxy note 4', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tristique, diam in consequat iaculis, est purus iaculis mauris, imperdiet facilisis ante ligula at nulla. Quisque volutpat nulla risus, id maximus ex aliquet ut.', 20, 3, 60, N'product-6.jpg', 3, 400)
GO
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (0, N'chưa thanh toán')
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (1, N'đã thanh toán')
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonDatHang_DonDatHang] FOREIGN KEY([MaDDH])
REFERENCES [dbo].[DonDatHang] ([MaDDH])
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [FK_ChiTietDonDatHang_DonDatHang]
GO
ALTER TABLE [dbo].[ChiTietDonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonDatHang_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietDonDatHang] CHECK CONSTRAINT [FK_ChiTietDonDatHang_SanPham]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([MaPN])
REFERENCES [dbo].[PhieuNhap] ([MaPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_SanPham]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_NguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_NguoiDung]
GO
ALTER TABLE [dbo].[DonDatHang]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_TrangThai] FOREIGN KEY([MaTrangThai])
REFERENCES [dbo].[TrangThai] ([MaTrangThai])
GO
ALTER TABLE [dbo].[DonDatHang] CHECK CONSTRAINT [FK_DonDatHang_TrangThai]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_LoaiNguoiDung] FOREIGN KEY([MaLND])
REFERENCES [dbo].[LoaiNguoiDung] ([MaLND])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_LoaiNguoiDung]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaCungCap]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaSanXuat] FOREIGN KEY([MaNSX])
REFERENCES [dbo].[NhaSanXuat] ([MaNSX])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaSanXuat]
GO
USE [master]
GO
ALTER DATABASE [BanDienThoai] SET  READ_WRITE 
GO
