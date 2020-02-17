ALTER TABLE [SanPham] DROP CONSTRAINT [FK__SanPham__MaNhomH__38996AB5]
GO
ALTER TABLE [SanPham] DROP CONSTRAINT [FK__SanPham__MaNhaCu__37A5467C]
GO
ALTER TABLE [SanPham] DROP CONSTRAINT [DF__SanPham__KhuyenM__36B12243]
GO
ALTER TABLE [SanPham] DROP CONSTRAINT [DF__SanPham__SoLuong__35BCFE0A]
GO
ALTER TABLE [SanPham] DROP CONSTRAINT [DF__SanPham__GiaThan__34C8D9D1]
GO
ALTER TABLE [SanPham] DROP CONSTRAINT [DF__SanPham__Sku__33D4B598]
GO
/****** Object:  Table [SanPham]    Script Date: 17/02/2020 9:54:06 CH ******/
DROP TABLE [SanPham]
GO
/****** Object:  Table [SanPham]    Script Date: 17/02/2020 9:54:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SanPham](
	[MaHang] [int] IDENTITY(1,1) NOT NULL,
	[MaNhaCungCap] [uniqueidentifier] NOT NULL,
	[MaNhomHang] [int] NOT NULL,
	[Sku] [uniqueidentifier] NULL,
	[TenHang] [nvarchar](150) NOT NULL,
	[AnhSanPham] [image] NULL,
	[MoTa] [nvarchar](1000) NULL,
	[GiaThanh] [money] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[KhoiLuong] [decimal](18, 0) NULL,
	[TheTich] [decimal](18, 0) NULL,
	[KhuyenMai] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [SanPham] ADD  DEFAULT (newid()) FOR [Sku]
GO
ALTER TABLE [SanPham] ADD  DEFAULT ((1000)) FOR [GiaThanh]
GO
ALTER TABLE [SanPham] ADD  DEFAULT ((1)) FOR [SoLuong]
GO
ALTER TABLE [SanPham] ADD  DEFAULT ((0)) FOR [KhuyenMai]
GO
ALTER TABLE [SanPham]  WITH CHECK ADD FOREIGN KEY([MaNhaCungCap])
REFERENCES [NhaCungCap] ([MaSo])
GO
ALTER TABLE [SanPham]  WITH CHECK ADD FOREIGN KEY([MaNhomHang])
REFERENCES [NhomHang] ([MaSo])
GO
