SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.SelectSysPtrDrv
(
	@WSName varchar(32) ,
	@DeviceName varchar(32),
	@Driver varchar(20) OUT,
	@Enabled smallint OUTPUT,
	@PrinterName varchar(60) OUTPUT,
	@Font varchar(60) OUTPUT,
	@Orientation smallint  OUTPUT,
	@InsertLFAfterCR smallint OUTPUT,
	@MarginTop decimal(10,2)  OUTPUT,
	@MarginBottom decimal(10,2)  OUTPUT,
	@MarginLeft decimal(10,2)  OUTPUT,
	@MarginRight decimal(10,2)  OUTPUT,
	@FontSize int  OUTPUT,
	@Bold smallint  OUTPUT,
	@Italic smallint  OUTPUT,
	@DebugLevel smallint  OUTPUT,
	@LogFile varchar(256) OUTPUT,
	@MaxLogFileSize int  OUTPUT,
	@FormFeed smallint OUTPUT
)
AS
	Select @WSName = WSName, 
	@DeviceName = DeviceName, 
	@Driver = Driver, 
	@Enabled = Enabled, 
	@PrinterName = PrinterName, 
	@Font = Font, 
	@Orientation = Orientation, 
	@InsertLFAfterCR = InsertLFAfterCR, 
	@MarginTop = MarginTop, 
	@MarginBottom = MarginBottom, 
	@MarginLeft = MarginLeft, 
	@MarginRight = MarginRight, 
	@FontSize = FontSize, 
	@Bold = Bold, 
	@Italic = Italic, 
	@DebugLevel = DebugLevel, 
	@LogFile = LogFile, 
	@MaxLogFileSize = MaxLogFileSize,
	@FormFeed = FormFeed
	From SysPtrDrvTable Where WSName = @WSName AND DeviceName = @DeviceName
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

