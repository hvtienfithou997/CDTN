ALTER TABLE [TaiKhoan] DROP CONSTRAINT [DF__TaiKhoan__MaTaiK__108B795B]
GO
/****** Object:  Table [TaiKhoan]    Script Date: 17/02/2020 9:54:06 CH ******/
DROP TABLE [TaiKhoan]
GO
/****** Object:  Table [TaiKhoan]    Script Date: 17/02/2020 9:54:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TaiKhoan](
	[MaTaiKhoan] [uniqueidentifier] NOT NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[TokenResetMatKhau] [nvarchar](250) NULL,
	[TokenNgayHetHan] [datetimeoffset](0) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [TaiKhoan] ADD  DEFAULT (newid()) FOR [MaTaiKhoan]
GO
