/****** Object:  Table [dbo].[Application]    Script Date: 28/10/2018 10:36:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Application](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ContactName] [varchar](64) NOT NULL,
	[ContactEmail] [varchar](256) NOT NULL,
	[ContactPhone] [varchar](256) NOT NULL,
	[Address] [varchar](256) NULL,
	[City] [varchar](256) NULL,
	[State] [varchar](256) NULL,
	[Zip] [varchar](256) NULL,
	[Country] [varchar](256) NULL,
	[ApiKey] [varchar](255) NOT NULL,
	[ApiSecretKey] [varchar](255) NOT NULL,
	[ApiToken] [varchar](1024) NULL,
	[ApiTokenCreated] [datetime] NULL,
	[ApiTokenExpireOn] [datetime] NULL,
	[EmailPreferences] [varchar](2056) NOT NULL,
	[TypeId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Created] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


