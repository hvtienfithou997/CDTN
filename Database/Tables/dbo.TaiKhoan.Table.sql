USE [CDLT]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 18/02/2020 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
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
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Email], [TokenResetMatKhau], [TokenNgayHetHan]) VALUES (N'00000000-0000-0000-0000-000000000000', N'mrtien', N'8AA8A52544C2039137AB9E704C4DE799673A1EB2CAB25AC47DBF9769DB4417E5', N'hvtien1@gmail.com', NULL, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Email], [TokenResetMatKhau], [TokenNgayHetHan]) VALUES (N'11a23d38-3a3e-462c-a6ac-1a5e34127d0c', N'jofori89', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'jofori89@gmail.com', NULL, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Email], [TokenResetMatKhau], [TokenNgayHetHan]) VALUES (N'6159ad23-5ec9-4415-9a4a-73ce2f32f21c', N'tientien', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'aaaaaaaa@gmail.com', NULL, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Email], [TokenResetMatKhau], [TokenNgayHetHan]) VALUES (N'29076563-873c-41af-ac6f-8ba65c209e26', N'happyday', N'123456', N'hvtien@gmail.com', NULL, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenDangNhap], [MatKhau], [Email], [TokenResetMatKhau], [TokenNgayHetHan]) VALUES (N'b122af64-74be-4efc-8f03-a95518af9532', N'admin', N'8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92', N'admin@gmail.com', NULL, NULL)
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT (newid()) FOR [MaTaiKhoan]
GO
