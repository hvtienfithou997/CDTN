USE [CDLT]
GO
/****** Object:  Table [dbo].[ThongTinKhachHang]    Script Date: 18/02/2020 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinKhachHang](
	[MaSo] [uniqueidentifier] NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[SDT] [nvarchar](16) NOT NULL,
	[DiaChi] [nvarchar](250) NOT NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[MacDinh] [bit] NULL,
	[MaTaiKhoan] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ThongTinKhachHang] ADD  DEFAULT (newid()) FOR [MaSo]
GO
ALTER TABLE [dbo].[ThongTinKhachHang]  WITH CHECK ADD FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
GO
