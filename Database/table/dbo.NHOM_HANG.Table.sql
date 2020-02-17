USE [CDLT]
GO
/****** Object:  Table [dbo].[NHOM_HANG]    Script Date: 17/02/2020 4:26:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOM_HANG](
	[MaNhomHang] [nchar](10) NOT NULL,
	[TenNhomHang] [nvarchar](50) NULL,
	[NgayNhap] [date] NULL,
	[NgayXuat] [date] NULL,
	[DonGia] [float] NULL,
	[SoLuong] [float] NULL,
 CONSTRAINT [PK_NHOM_HANG] PRIMARY KEY CLUSTERED 
(
	[MaNhomHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
