USE [pTable]
GO

/****** Object:  Table [dbo].[elements]    Script Date: 18/11/2022 20:23:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[elements]') AND type in (N'U'))
DROP TABLE [dbo].[elements]
GO

/****** Object:  Table [dbo].[elements]    Script Date: 18/11/2022 20:23:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[elements](
	[element_id] [int] IDENTITY(1,1) NOT NULL,
	[group] [int] NULL,
	[period] [int] NULL,
	[atomic_number] [int] NULL,
	[atomic_mass] [float] NULL,
	[symbol] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_elements] PRIMARY KEY CLUSTERED 
(
	[element_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


