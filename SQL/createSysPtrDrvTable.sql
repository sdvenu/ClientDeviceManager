CREATE TABLE [SysPtrDrvTable] (
	[WSName] [varchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DeviceName] [varchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Driver] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Enabled] [smallint] NOT NULL CONSTRAINT [DF_SysPtrDrvTable_Enabled] DEFAULT (1),
	[PrinterName] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Font] [varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Orientation] [smallint] NULL ,
	[InsertLFAfterCR] [smallint] NULL ,
	[MarginTop] [decimal](10, 2) NULL ,
	[MarginBottom] [decimal](10, 2) NULL ,
	[MarginLeft] [decimal](10, 2) NULL ,
	[MarginRight] [decimal](10, 2) NULL ,
	[FontSize] [int] NULL ,
	[Bold] [smallint] NULL ,
	[Italic] [smallint] NULL ,
	[DebugLevel] [smallint] NULL ,
	[LogFile] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MaxLogFileSize] [int] NULL ,
	[FormFeed] [smallint] NULL CONSTRAINT [DF_SysPtrDrvTable_PageEject] DEFAULT (0),
	CONSTRAINT [PK_SysPtrDrvTable] PRIMARY KEY  CLUSTERED 
	(
		[WSName],
		[DeviceName]
	)  ON [PRIMARY] 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


