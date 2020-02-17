ALTER TABLE [DonHang] DROP CONSTRAINT [FK__DonHang__MaTaiKh__628FA481]
GO
ALTER TABLE [DonHang] DROP CONSTRAINT [FK__DonHang__MaGiamG__6383C8BA]
GO
ALTER TABLE [DonHang] DROP CONSTRAINT [DF__DonHang__MaSo__619B8048]
GO
/****** Object:  Table [DonHang]    Script Date: 17/02/2020 9:54:06 CH ******/
DROP TABLE [DonHang]
GO
/****** Object:  Table [DonHang]    Script Date: 17/02/2020 9:54:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [DonHang](
	[MaSo] [uniqueidentifier] NOT NULL,
	[MaTaiKhoan] [uniqueidentifier] NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[SDT] [nvarchar](16) NOT NULL,
	[DiaChi] [nvarchar](250) NOT NULL,
	[MaGiamGia] [uniqueidentifier] NULL,
	[TongTien] [money] NOT NULL,
	[NgayLap] [datetimeoffset](0) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [DonHang] ADD  DEFAULT (newid()) FOR [MaSo]
GO
ALTER TABLE [DonHang]  WITH CHECK ADD FOREIGN KEY([MaGiamGia])
REFERENCES [Coupon] ([MaSo])
GO
ALTER TABLE [DonHang]  WITH CHECK ADD FOREIGN KEY([MaTaiKhoan])
REFERENCES [TaiKhoan] ([MaTaiKhoan])
GO
