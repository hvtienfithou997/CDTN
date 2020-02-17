ALTER TABLE [ChiTietDonHang] DROP CONSTRAINT [FK__ChiTietDo__MaHan__6C190EBB]
GO
ALTER TABLE [ChiTietDonHang] DROP CONSTRAINT [FK__ChiTietDo__MaDon__6B24EA82]
GO
ALTER TABLE [ChiTietDonHang] DROP CONSTRAINT [DF__ChiTietDon__MaSo__6A30C649]
GO
/****** Object:  Table [ChiTietDonHang]    Script Date: 17/02/2020 9:54:06 CH ******/
DROP TABLE [ChiTietDonHang]
GO
/****** Object:  Table [ChiTietDonHang]    Script Date: 17/02/2020 9:54:06 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ChiTietDonHang](
	[MaSo] [uniqueidentifier] NOT NULL,
	[MaDonHang] [uniqueidentifier] NOT NULL,
	[MaHang] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [ChiTietDonHang] ADD  DEFAULT (newid()) FOR [MaSo]
GO
ALTER TABLE [ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaDonHang])
REFERENCES [DonHang] ([MaSo])
GO
ALTER TABLE [ChiTietDonHang]  WITH CHECK ADD FOREIGN KEY([MaHang])
REFERENCES [SanPham] ([MaHang])
GO
