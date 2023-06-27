SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.InsertSysPtrDrv
(
	@WSName varchar(32),
	@DeviceName varchar(32),
	@Driver varchar(20),
	@Enabled smallint,
	@PrinterName varchar(60),
	@Font varchar(60),
	@Orientation smallint,
	@InsertLFAfterCR smallint,
	@MarginTop decimal(10,2),
	@MarginBottom decimal(10,2),
	@MarginLeft decimal(10,2),
	@MarginRight decimal(10,2),
	@FontSize int,
	@Bold smallint,
	@Italic smallint,
	@DebugLevel smallint,
	@LogFile Text,
	@MaxLogFileSize int,
	@FormFeed smallint
)
AS
	SET NOCOUNT OFF;
INSERT INTO SysPtrDrvTable(WSName, DeviceName, Driver, Enabled, PrinterName, Font, Orientation, InsertLFAfterCR, MarginTop, MarginBottom, 
	MarginLeft, MarginRight, FontSize, Bold, Italic, DebugLevel, LogFile, MaxLogFileSize, FormFeed) 
VALUES (@WSName, @DeviceName, @Driver, @Enabled, @PrinterName, @Font, @Orientation, @InsertLFAfterCR, @MarginTop, @MarginBottom, 
	@MarginLeft, @MarginRight, @FontSize, @Bold, @Italic, @DebugLevel, @LogFile, @MaxLogFileSize, @FormFeed);
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

