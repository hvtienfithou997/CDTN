USE [CDLT]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 18/02/2020 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
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
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT (newid()) FOR [MaSo]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaGiamGia])
REFERENCES [dbo].[Coupon] ([MaSo])
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
GO
