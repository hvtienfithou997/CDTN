USE [CDLT]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 18/02/2020 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaHang] [int] IDENTITY(1,1) NOT NULL,
	[MaNhaCungCap] [uniqueidentifier] NOT NULL,
	[MaNhomHang] [int] NOT NULL,
	[Sku] [uniqueidentifier] NULL,
	[TenHang] [nvarchar](150) NOT NULL,
	[MoTa] [nvarchar](1000) NULL,
	[GiaThanh] [money] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[KhoiLuong] [decimal](18, 0) NULL,
	[TheTich] [decimal](18, 0) NULL,
	[KhuyenMai] [decimal](18, 0) NULL,
	[AnhSanPham] [ntext] NULL,
 CONSTRAINT [PK__SanPham__19C0DB1D5EEBFFB7] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaHang], [MaNhaCungCap], [MaNhomHang], [Sku], [TenHang], [MoTa], [GiaThanh], [SoLuong], [KhoiLuong], [TheTich], [KhuyenMai], [AnhSanPham]) VALUES (5, N'bd16c801-8971-4c2c-9e91-6329ac2c9884', 2, N'a4ab0fc0-b878-482e-a7cd-980a32dfc045', N'Sắn', N'Khống có', 1000000.0000, 3, CAST(1 AS Decimal(18, 0)), NULL, CAST(50000 AS Decimal(18, 0)), N'https://cdn.vietnambiz.vn/stores/news_dataimages/hanhtt/092018/01/18/3921_cY-sYn-2.jpg')
INSERT [dbo].[SanPham] ([MaHang], [MaNhaCungCap], [MaNhomHang], [Sku], [TenHang], [MoTa], [GiaThanh], [SoLuong], [KhoiLuong], [TheTich], [KhuyenMai], [AnhSanPham]) VALUES (7, N'bd16c801-8971-4c2c-9e91-6329ac2c9884', 1, N'3a29266b-408e-48b4-b929-8d963faa653a', N'Dưa muối', N'Muối không ngon', 1000.0000, 5, NULL, NULL, CAST(2 AS Decimal(18, 0)), N'https://monngonchuabenh.com/wp-content/uploads/2019/01/cach-lam-dua-cai-chua-ngot-11.jpg')
SET IDENTITY_INSERT [dbo].[SanPham] OFF
/****** Object:  Index [UQ__SanPham__CA1FD3C59B33022A]    Script Date: 18/02/2020 5:39:06 PM ******/
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [UQ__SanPham__CA1FD3C59B33022A] UNIQUE NONCLUSTERED 
(
	[Sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF__SanPham__Sku__72C60C4A]  DEFAULT (newid()) FOR [Sku]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF__SanPham__GiaThan__73BA3083]  DEFAULT ((1000)) FOR [GiaThanh]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF__SanPham__SoLuong__74AE54BC]  DEFAULT ((1)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF__SanPham__KhuyenM__75A278F5]  DEFAULT ((0)) FOR [KhuyenMai]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK__SanPham__MaNhaCu__76969D2E] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaSo])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK__SanPham__MaNhaCu__76969D2E]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK__SanPham__MaNhomH__778AC167] FOREIGN KEY([MaNhomHang])
REFERENCES [dbo].[NhomHang] ([MaSo])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK__SanPham__MaNhomH__778AC167]
GO
