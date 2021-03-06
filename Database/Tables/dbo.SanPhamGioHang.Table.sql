USE [CDLT]
GO
/****** Object:  Table [dbo].[SanPhamGioHang]    Script Date: 18/02/2020 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamGioHang](
	[MaTaiKhoan] [uniqueidentifier] NOT NULL,
	[MaHang] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SanPhamGioHang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SanPhamGioHang] ON 

INSERT [dbo].[SanPhamGioHang] ([MaTaiKhoan], [MaHang], [SoLuong], [Id]) VALUES (N'b122af64-74be-4efc-8f03-a95518af9532', 5, 1, 2)
INSERT [dbo].[SanPhamGioHang] ([MaTaiKhoan], [MaHang], [SoLuong], [Id]) VALUES (N'11a23d38-3a3e-462c-a6ac-1a5e34127d0c', 7, 3, 5)
INSERT [dbo].[SanPhamGioHang] ([MaTaiKhoan], [MaHang], [SoLuong], [Id]) VALUES (N'11a23d38-3a3e-462c-a6ac-1a5e34127d0c', 5, 2, 7)
SET IDENTITY_INSERT [dbo].[SanPhamGioHang] OFF
/****** Object:  Index [UQ__SanPhamG__6CE06899EAF00F84]    Script Date: 18/02/2020 5:39:06 PM ******/
ALTER TABLE [dbo].[SanPhamGioHang] ADD  CONSTRAINT [UQ__SanPhamG__6CE06899EAF00F84] UNIQUE NONCLUSTERED 
(
	[MaTaiKhoan] ASC,
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SanPhamGioHang]  WITH CHECK ADD  CONSTRAINT [FK__SanPhamGi__MaHan__1CBC4616] FOREIGN KEY([MaHang])
REFERENCES [dbo].[SanPham] ([MaHang])
GO
ALTER TABLE [dbo].[SanPhamGioHang] CHECK CONSTRAINT [FK__SanPhamGi__MaHan__1CBC4616]
GO
ALTER TABLE [dbo].[SanPhamGioHang]  WITH CHECK ADD  CONSTRAINT [FK__SanPhamGi__MaTai__1BC821DD] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
GO
ALTER TABLE [dbo].[SanPhamGioHang] CHECK CONSTRAINT [FK__SanPhamGi__MaTai__1BC821DD]
GO
