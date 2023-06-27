SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.SelectSysPtrDS
(
	@WSName varchar(32) ,
	@DeviceName varchar(32))
AS
	Select WSName, 
	DeviceName, 
	Driver, 
	Enabled, 
	PrinterName
	From SysPtrDrvTable Where WSName = @WSName AND DeviceName = @DeviceName
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

