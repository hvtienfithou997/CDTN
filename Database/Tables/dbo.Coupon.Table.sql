USE [CDLT]
GO
/****** Object:  Table [dbo].[Coupon]    Script Date: 18/02/2020 5:39:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupon](
	[MaSo] [uniqueidentifier] NOT NULL,
	[KhuyenMai] [decimal](18, 0) NULL,
	[NgayHetHan] [datetimeoffset](0) NULL,
	[SoLuong] [int] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Coupon] ADD  DEFAULT (newid()) FOR [MaSo]
GO
ALTER TABLE [dbo].[Coupon] ADD  DEFAULT ((0)) FOR [KhuyenMai]
GO
ALTER TABLE [dbo].[Coupon] ADD  DEFAULT ((1)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[Coupon] ADD  DEFAULT ((1)) FOR [Active]
GO
