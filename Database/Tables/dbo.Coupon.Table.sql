ALTER TABLE [Coupon] DROP CONSTRAINT [DF__Coupon__Active__47DBAE45]
GO
ALTER TABLE [Coupon] DROP CONSTRAINT [DF__Coupon__SoLuong__46E78A0C]
GO
ALTER TABLE [Coupon] DROP CONSTRAINT [DF__Coupon__KhuyenMa__45F365D3]
GO
ALTER TABLE [Coupon] DROP CONSTRAINT [DF__Coupon__MaSo__44FF419A]
GO
/****** Object:  Table [Coupon]    Script Date: 17/02/2020 9:54:06 CH ******/
DROP TABLE [Coupon]
GO
/****** Object:  Table [Coupon]    Script Date: 17/02/2020 9:54:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Coupon](
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
ALTER TABLE [Coupon] ADD  DEFAULT (newid()) FOR [MaSo]
GO
ALTER TABLE [Coupon] ADD  DEFAULT ((0)) FOR [KhuyenMai]
GO
ALTER TABLE [Coupon] ADD  DEFAULT ((1)) FOR [SoLuong]
GO
ALTER TABLE [Coupon] ADD  DEFAULT ((1)) FOR [Active]
GO
