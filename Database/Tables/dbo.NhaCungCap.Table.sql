USE [CDLT]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 18/02/2020 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaSo] [uniqueidentifier] NOT NULL,
	[Ten] [nvarchar](250) NULL,
	[Sdt] [varchar](16) NULL,
	[DiaChi] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NhaCungCap] ([MaSo], [Ten], [Sdt], [DiaChi]) VALUES (N'bd16c801-8971-4c2c-9e91-6329ac2c9884', N'Visan', N'+050212120', N'Hanfoi')
ALTER TABLE [dbo].[NhaCungCap] ADD  DEFAULT (newid()) FOR [MaSo]
GO
