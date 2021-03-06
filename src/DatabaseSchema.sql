USE [Feed Grabber]
GO
ALTER TABLE [dbo].[Article] DROP CONSTRAINT [FK_Article_Feed]
GO
ALTER TABLE [dbo].[Feed] DROP CONSTRAINT [DF_Feed_QueryCount]
GO
/****** Object:  Table [dbo].[Feed]    Script Date: 03/09/2016 22:22:04 ******/
DROP TABLE [dbo].[Feed]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 03/09/2016 22:22:04 ******/
DROP TABLE [dbo].[Article]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 03/09/2016 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArticleGUID] [uniqueidentifier] NOT NULL,
	[FeedGUID] [uniqueidentifier] NOT NULL,
	[ArticleRemoteID] [nvarchar](max) NOT NULL,
	[ArticleURL] [nvarchar](max) NOT NULL,
	[ArticleTitle] [nvarchar](max) NOT NULL,
	[ArticleDescription] [nvarchar](max) NULL,
	[PublishedDateTime] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleGUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feed]    Script Date: 03/09/2016 22:22:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feed](
	[FeedGUID] [uniqueidentifier] NOT NULL,
	[FeedURL] [nvarchar](2048) NOT NULL,
	[FeedTitle] [nvarchar](1024) NOT NULL,
	[FeedDescription] [nvarchar](2048) NOT NULL,
	[QueryCount] [bigint] NOT NULL,
	[LastQueryDateTime] [datetime] NULL,
 CONSTRAINT [PK_Feed] PRIMARY KEY CLUSTERED 
(
	[FeedGUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Feed] ADD  CONSTRAINT [DF_Feed_QueryCount]  DEFAULT ((0)) FOR [QueryCount]
GO
ALTER TABLE [dbo].[Article]  WITH NOCHECK ADD  CONSTRAINT [FK_Article_Feed] FOREIGN KEY([FeedGUID])
REFERENCES [dbo].[Feed] ([FeedGUID])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_Feed]
GO
