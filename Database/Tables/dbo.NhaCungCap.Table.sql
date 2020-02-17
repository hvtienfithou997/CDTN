ALTER TABLE [NhaCungCap] DROP CONSTRAINT [DF__NhaCungCap__MaSo__182C9B23]
GO
/****** Object:  Table [NhaCungCap]    Script Date: 17/02/2020 9:54:06 CH ******/
DROP TABLE [NhaCungCap]
GO
/****** Object:  Table [NhaCungCap]    Script Date: 17/02/2020 9:54:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NhaCungCap](
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
SET ANSI_PADDING OFF
GO
ALTER TABLE [NhaCungCap] ADD  DEFAULT (newid()) FOR [MaSo]
GO
