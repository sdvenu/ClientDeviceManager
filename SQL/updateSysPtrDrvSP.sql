SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.UpdateSysPtrDrv
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
UPDATE SysPtrDrvTable SET Driver = @Driver, Enabled = @Enabled,
PrinterName = @PrinterName,  Font = @Font, Orientation = @Orientation,InsertLFAfterCR=@InsertLFAfterCR, MarginTop = @MarginTop, MarginBottom=@MarginBottom, MarginLeft=@MarginLeft, 
MarginRight=@MarginRight,FontSize=@FontSize, Bold=@Bold, Italic=@Italic, DebugLevel=@DebugLevel, LogFile=@LogFile, MaxLogFileSize=@MaxLogFileSize,
FormFeed=@FormFeed 
WHERE (WSName = @WSName) AND (DeviceName = @DeviceName) ;
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

