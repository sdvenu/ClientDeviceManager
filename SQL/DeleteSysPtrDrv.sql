SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE dbo.DeleteSysPtrDrv
(
	@WSName varchar(32) 
)
AS
	delete From SysPtrDrvTable Where WSName = @WSName;
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

