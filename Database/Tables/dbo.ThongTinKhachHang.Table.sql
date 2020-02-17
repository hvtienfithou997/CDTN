ALTER TABLE [ThongTinKhachHang] DROP CONSTRAINT [FK__ThongTinK__MaTai__6754599E]
GO
ALTER TABLE [ThongTinKhachHang] DROP CONSTRAINT [DF__ThongTinKh__MaSo__66603565]
GO
/****** Object:  Table [ThongTinKhachHang]    Script Date: 17/02/2020 9:54:06 CH ******/
DROP TABLE [ThongTinKhachHang]
GO
/****** Object:  Table [ThongTinKhachHang]    Script Date: 17/02/2020 9:54:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ThongTinKhachHang](
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
ALTER TABLE [ThongTinKhachHang] ADD  DEFAULT (newid()) FOR [MaSo]
GO
ALTER TABLE [ThongTinKhachHang]  WITH CHECK ADD FOREIGN KEY([MaTaiKhoan])
REFERENCES [TaiKhoan] ([MaTaiKhoan])
GO
