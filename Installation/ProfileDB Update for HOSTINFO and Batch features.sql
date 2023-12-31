/* Update CDM for the new TLS / HOSTINFO / Batch features. */

USE [ProfileDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/******** TLS Updates ********/

/**** Add the TLS settings ****/

ALTER TABLE [dbo].[HSSPRouteInfo]
	ADD [SSL] [char](1) NOT NULL
		CONSTRAINT [DF_HSSPRouteInfo_SSL] DEFAULT (1)
GO
ALTER TABLE [dbo].[HSSPRouteInfo]
	ADD [SSLLOGGING] [char](1) NOT NULL
		CONSTRAINT [DF_HSSPRouteInfo_SSLLOGGING] DEFAULT (0)
GO
ALTER TABLE [dbo].[HSSPRouteInfo]
	ADD [SSLMAXLOGFILESIZE] [varchar](10) NOT NULL
		CONSTRAINT [DF_HSSPRouteInfo_SSLMAXLOGFILESIZE] DEFAULT (1000)
GO
ALTER TABLE [dbo].[HSSPRouteInfo]
	ADD [SSLLOGFILE] [varchar](255) NOT NULL
		CONSTRAINT [DF_HSSPRouteInfo_SSLLOGFILE] DEFAULT ('')
GO
ALTER TABLE [dbo].[HSSPRouteInfo]
	ADD [SSLHANDSHAKETIMEOUT] [varchar](4) NOT NULL
		CONSTRAINT [DF_HSSPRouteInfo_SSLHANDSHAKETIMEOUT] DEFAULT ('')
GO


/******** HOSTINFO Management ********/

/**** Create the HOSTINFO table ****/
CREATE TABLE [dbo].[HostInfo](
	[ID] [int] IDENTITY(0,1) NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Description] [varchar](64) NOT NULL
		CONSTRAINT [DF_HostInfo_Description] DEFAULT (''),
	[Contents] [varchar](4096) NOT NULL,
	CONSTRAINT [PK_ID] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
	) ON [PRIMARY]
GO

/**** Add the pre-defined entries to the HOSTINFO table ****/

/* Be sure "Ignore" is ID 0 */
INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('Ignore', 'Do not create, erase, overwrite, or modify any HostInfo file', 'Ignore')
GO

/* Be sure "None" is ID 1 */
INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('None', 'No HostInfo file for the workstation', 'None')
GO

/* Be sure "DEFAULT" is ID 2 */
INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('DEFAULT', 'The default for most workstations', 'RES;AA.ENC.HAVAIL.SABRE.COM;PSS;
CERT;AA.ENC.CERT.HAVAIL.SABRE.COM;CRT;
TSTS;AA.ENC.TSTS.SABRE.COM;STS;
DECS;DECS.AA.EDS.COM;FOS;
TDEC;TDEC.AA.EDS.COM;FST;
FOS;DECS.AA.EDS.COM;FOS;
FRT;DECS.AA.EDS.COM;FOS;
MSG;DECS.AA.EDS.COM;FOS;
TMSG;TDEC.AA.EDS.COM;FST;
TFRT;TDEC.AA.EDS.COM;FST;
')
GO

/**** Add the other pre-defined HOSTINFO definitions ****/

INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('AllUnencryptedHosts', 'All unencrypted hosts', 'RES;RES.AA.EDS.COM;PSS;
CERT;CERT.AA.EDS.COM;CRT;
TSTS;TSTS.AA.EDS.COM;STS;
DECS;DECS.AA.EDS.COM;FOS;
TDEC;TDEC.AA.EDS.COM;FST;
RESA;RESA.HOST.AA.EDS.COM;PSS;
RESB;RESB.HOST.AA.EDS.COM;PSS;
RESC;RESC.HOST.AA.EDS.COM;PSS;
RESD;RESD.HOST.AA.EDS.COM;PSS;
RESE;RESE.HOST.AA.EDS.COM;PSS;
RESF;RESF.HOST.AA.EDS.COM;PSS;
RESG;RESG.HOST.AA.EDS.COM;PSS;
RESH;RESH.HOST.AA.EDS.COM;PSS;
CERTC;CERTC.AA.EDS.COM;CRT;
CERTD;CERTD.AA.EDS.COM;CRT;
CERTG;CERTG.AA.EDS.COM;CRT;
CERTF;CERTF.AA.EDS.COM;CRT;
TSTSA;STSA.HOST.AA.EDS.COM;STS;
TSTSB;STSB.HOST.AA.EDS.COM;STS;
DECSI;FOSI.HOST.AA.EDS.COM;FOS;
DECSJ;FOSJ.HOST.AA.EDS.COM;FOS;
TDECI;FSTI.HOST.AA.EDS.COM;FST;
TDECJ;FSTJ.HOST.AA.EDS.COM;FST;
FOS;DECS.AA.EDS.COM;FOS;
FRT;DECS.AA.EDS.COM;FOS;
MSG;DECS.AA.EDS.COM;FOS;
TFRT;TDEC.AA.EDS.COM;FST;
TMSG;TDEC.AA.EDS.COM;FST;
FOSI;FOSI.AA.EDS.COM;FOS;
FOSJ;FOSJ.AA.EDS.COM;FOS;
FRTI;FOSI.HOST.AA.EDS.COM;FOS;
FRTJ;FOSJ.AA.EDS.COM;FOS;
MSGI;FOSI.HOST.AA.EDS.COM;FOS;
MSGJ;FOSJ.HOST.AA.EDS.COM;FOS;
TFRTI;FSTI.AA.EDS.COM;FST;
TFRTJ;FSTJ.AA.EDS.COM;FST;
TMSGI;FSTI.AA.EDS.COM;FST;
TMSGJ;FSTJ.AA.EDS.COM;FST;
')
GO

INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('StdUnencryptedHosts', 'Standard unencrypted hosts', 'RES;RES.AA.EDS.COM;PSS;
CERT;CERT.AA.EDS.COM;CRT;
TSTS;TSTS.AA.EDS.COM;STS;
DECS;DECS.AA.EDS.COM;FOS;
TDEC;TDEC.AA.EDS.COM;FST;
FOS;DECS.AA.EDS.COM;FOS;
FRT;DECS.AA.EDS.COM;FOS;
MSG;DECS.AA.EDS.COM;FOS;
TFRT;TDEC.AA.EDS.COM;FST;
TMSG;TDEC.AA.EDS.COM;FST;
')
GO

INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('AllUnencryptedHostsAndVPARS', 'All unencrypted hosts and VPARS', 'RES;RES.AA.EDS.COM;PSS;
CERT;CERT.AA.EDS.COM;CRT;
TSTS;TSTS.AA.EDS.COM;STS;
DECS;DECS.AA.EDS.COM;FOS;
TDEC;TDEC.AA.EDS.COM;FST;
RESA;RESA.HOST.AA.EDS.COM;PSS;
RESB;RESB.HOST.AA.EDS.COM;PSS;
RESC;RESC.HOST.AA.EDS.COM;PSS;
RESD;RESD.HOST.AA.EDS.COM;PSS;
RESE;RESE.HOST.AA.EDS.COM;PSS;
RESF;RESF.HOST.AA.EDS.COM;PSS;
RESG;RESG.HOST.AA.EDS.COM;PSS;
RESH;RESH.HOST.AA.EDS.COM;PSS;
CERTC;CERTC.AA.EDS.COM;CRT;
CERTD;CERTD.AA.EDS.COM;CRT;
CERTG;CERTG.AA.EDS.COM;CRT;
CERTF;CERTF.AA.EDS.COM;CRT;
TSTSA;STSA.HOST.AA.EDS.COM;STS;
TSTSB;STSB.HOST.AA.EDS.COM;STS;
DECSI;FOSI.HOST.AA.EDS.COM;FOS;
DECSJ;FOSJ.HOST.AA.EDS.COM;FOS;
TDECI;FSTI.HOST.AA.EDS.COM;FST;
TDECJ;FSTJ.HOST.AA.EDS.COM;FST;
FOS;DECS.AA.EDS.COM;FOS;
FRT;DECS.AA.EDS.COM;FOS;
MSG;DECS.AA.EDS.COM;FOS;
TFRT;TDEC.AA.EDS.COM;FST;
TMSG;TDEC.AA.EDS.COM;FST;
FOSI;FOSI.AA.EDS.COM;FOS;
FOSJ;FOSJ.AA.EDS.COM;FOS;
FRTI;FOSI.HOST.AA.EDS.COM;FOS;
FRTJ;FOSJ.AA.EDS.COM;FOS;
MSGI;FOSI.HOST.AA.EDS.COM;FOS;
MSGJ;FOSJ.HOST.AA.EDS.COM;FOS;
TFRTI;FSTI.AA.EDS.COM;FST;
TFRTJ;FSTJ.AA.EDS.COM;FST;
TMSGI;FSTI.AA.EDS.COM;FST;
TMSGJ;FSTJ.AA.EDS.COM;FST;
2DEC;F4T.AA.EDS.COM;2DEC;
2MSG;F4T.AA.EDS.COM;2MSG;
2FRT;F4T.AA.EDS.COM;2FRT;
P101A;AAA.AA.EDS.COM;101;
P102A;AAA2.AA.EDS.COM;102;
P103A;AAA3.AA.EDS.COM;103;
P104;AAB.AA.EDS.COM;104;
P163I;3DC1.AA.EDS.COM;301;
P164I;3DC1.AA.EDS.COM;31F;
P165I;3DC1.AA.EDS.COM;31M;
P166I;3DC2.AA.EDS.COM;302;
P167I;3DC2.AA.EDS.COM;32F;
P168I;3DC2.AA.EDS.COM;32M;
P193I;4DC1.AA.EDS.COM;41P;
P194I;4DC1.AA.EDS.COM;41F;
P195I;4DC1.AA.EDS.COM;41M;
P196I;4DC2.AA.EDS.COM;42P;
P197I;4DC2.AA.EDS.COM;42F;
P198I;4DC2.AA.EDS.COM;42M;
P180I;4DC3.AA.EDS.COM;43P;
P181I;4DC3.AA.EDS.COM;43F;
P182I;4DC3.AA.EDS.COM;43M;
P177I;5DEC.AA.EDS.COM;5DEC;
P178I;5DEC.AA.EDS.COM;5FRT;
P179I;5DEC.AA.EDS.COM;5MSG;
P148;6DC1.AA.EDS.COM;61P;
P149;6DC1.AA.EDS.COM;61F;
P150;6DC1.AA.EDS.COM;61M;
P151;6DC2.AA.EDS.COM;62P;
P152;6DC2.AA.EDS.COM;62F;
P153;6DC2.AA.EDS.COM;62M;
P154;6DC3.AA.EDS.COM;6TP;
P155;6DC3.AA.EDS.COM;6TF;
P156;6DC3.AA.EDS.COM;6TM;
P170;AAA2.AA.EDS.COM;6DP;
P171;AAA2.AA.EDS.COM;6DF;
P172;AAA2.AA.EDS.COM;6DM;
')
GO

INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('StdUnencryptedHostsAndVPARS', 'Standard unencrypted hosts and VPARS', 'RES;RES.AA.EDS.COM;PSS;
CERT;CERT.AA.EDS.COM;CRT;
TSTS;TSTS.AA.EDS.COM;STS;
DECS;DECS.AA.EDS.COM;FOS;
TDEC;TDEC.AA.EDS.COM;FST;
FOS;DECS.AA.EDS.COM;FOS;
FRT;DECS.AA.EDS.COM;FOS;
MSG;DECS.AA.EDS.COM;FOS;
TFRT;TDEC.AA.EDS.COM;FST;
TMSG;TDEC.AA.EDS.COM;FST;
2DEC;F4T.AA.EDS.COM;2DEC;
2MSG;F4T.AA.EDS.COM;2MSG;
2FRT;F4T.AA.EDS.COM;2FRT;
P101A;AAA.AA.EDS.COM;101;
P102A;AAA2.AA.EDS.COM;102;
P103A;AAA3.AA.EDS.COM;103;
P104;AAB.AA.EDS.COM;104;
P163I;3DC1.AA.EDS.COM;301;
P164I;3DC1.AA.EDS.COM;31F;
P165I;3DC1.AA.EDS.COM;31M;
P166I;3DC2.AA.EDS.COM;302;
P167I;3DC2.AA.EDS.COM;32F;
P168I;3DC2.AA.EDS.COM;32M;
P193I;4DC1.AA.EDS.COM;41P;
P194I;4DC1.AA.EDS.COM;41F;
P195I;4DC1.AA.EDS.COM;41M;
P196I;4DC2.AA.EDS.COM;42P;
P197I;4DC2.AA.EDS.COM;42F;
P198I;4DC2.AA.EDS.COM;42M;
P180I;4DC3.AA.EDS.COM;43P;
P181I;4DC3.AA.EDS.COM;43F;
P182I;4DC3.AA.EDS.COM;43M;
P177I;5DEC.AA.EDS.COM;5DEC;
P178I;5DEC.AA.EDS.COM;5FRT;
P179I;5DEC.AA.EDS.COM;5MSG;
P148;6DC1.AA.EDS.COM;61P;
P149;6DC1.AA.EDS.COM;61F;
P150;6DC1.AA.EDS.COM;61M;
P151;6DC2.AA.EDS.COM;62P;
P152;6DC2.AA.EDS.COM;62F;
P153;6DC2.AA.EDS.COM;62M;
P154;6DC3.AA.EDS.COM;6TP;
P155;6DC3.AA.EDS.COM;6TF;
P156;6DC3.AA.EDS.COM;6TM;
P170;AAA2.AA.EDS.COM;6DP;
P171;AAA2.AA.EDS.COM;6DF;
P172;AAA2.AA.EDS.COM;6DM;
')
GO

INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('AllVPARS', 'All VPARS', '2DEC;F4T.AA.EDS.COM;2DEC;
2MSG;F4T.AA.EDS.COM;2MSG;
2FRT;F4T.AA.EDS.COM;2FRT;
P101A;AAA.AA.EDS.COM;101;
P102A;AAA2.AA.EDS.COM;102;
P103A;AAA3.AA.EDS.COM;103;
P104;AAB.AA.EDS.COM;104;
P163I;3DC1.AA.EDS.COM;301;
P164I;3DC1.AA.EDS.COM;31F;
P165I;3DC1.AA.EDS.COM;31M;
P166I;3DC2.AA.EDS.COM;302;
P167I;3DC2.AA.EDS.COM;32F;
P168I;3DC2.AA.EDS.COM;32M;
P193I;4DC1.AA.EDS.COM;41P;
P194I;4DC1.AA.EDS.COM;41F;
P195I;4DC1.AA.EDS.COM;41M;
P196I;4DC2.AA.EDS.COM;42P;
P197I;4DC2.AA.EDS.COM;42F;
P198I;4DC2.AA.EDS.COM;42M;
P180I;4DC3.AA.EDS.COM;43P;
P181I;4DC3.AA.EDS.COM;43F;
P182I;4DC3.AA.EDS.COM;43M;
P177I;5DEC.AA.EDS.COM;5DEC;
P178I;5DEC.AA.EDS.COM;5FRT;
P179I;5DEC.AA.EDS.COM;5MSG;
P148;6DC1.AA.EDS.COM;61P;
P149;6DC1.AA.EDS.COM;61F;
P150;6DC1.AA.EDS.COM;61M;
P151;6DC2.AA.EDS.COM;62P;
P152;6DC2.AA.EDS.COM;62F;
P153;6DC2.AA.EDS.COM;62M;
P154;6DC3.AA.EDS.COM;6TP;
P155;6DC3.AA.EDS.COM;6TF;
P156;6DC3.AA.EDS.COM;6TM;
P170;AAA2.AA.EDS.COM;6DP;
P171;AAA2.AA.EDS.COM;6DF;
P172;AAA2.AA.EDS.COM;6DM;
')
GO

INSERT INTO [dbo].[HostInfo]
	(Name, Description, Contents) VALUES
	('AllSabreVPARS', 'All Sabre VPARS', '2DEC;ACPF4TI.VPARS.SABRE.COM;VP8;
2DECI;ACPF4TI.VPARS.SABRE.COM;VP8;
2DECJ;ACPF4TJ.VPARS.SABRE.COM;VP9;
CERTF;ACCESS.CERTF.SABRE.COM;CRT;
CERTG;ACCESS.CERTG.SABRE.COM;CRT;
P200;ACPMXC48.VPARS.SABRE.COM;VP5;
P220;ACCESS.STAGE.SABRE.COM;P22;
P220A;ACCESS.STAGE.SABRE.COM;P22;
PKG;ACCESS.PKG.SABRE.COM;PKG;
PKGE;ACCESS.PKGE.SABRE.COM;PKG;
PKGF;ACCESS.PKGF.SABRE.COM;PKG;
TMCS;ACCESS.TMCS.SABRE.COM;TMC;
TSS1;ACCESS.WNT.TSS1.SABRE.COM;WNT;
TSTSH;ACCESS.TSTSH.SABRE.COM;STS;
VDEC;ACPMXC48.VPARS.SABRE.COM;VP5; 
WN1;ACCESS.WNP.SABRE.COM;WNP;
WNP;ACCESS.WNP.SABRE.COM;WNP;
WNP0;ACCESS.WNP.SABRE.COM;WNP;
WNP1;ACCESS.WNP.SABRE.COM;WNP;
')
GO

/**** Link the workstations to a HOSTINFO definition ****/
ALTER TABLE [dbo].[MasterNodeExtraTable]
	ADD [HostInfo] [int] NOT NULL
		CONSTRAINT [DF_MasterNodeExtraTable_HostInfo] DEFAULT (0)
GO


/******** Batch Operations ********/

/**** Record whether users can perform batch operations ****/
ALTER TABLE [dbo].[ManagementRightsExtraTbl]
	ADD [IsAllowedBatchOperations] [bit] NOT NULL
		CONSTRAINT [DF_ManagementRightsExtraTbl_IsAllowedBatchOperations] DEFAULT (0)
GO


/******** Menus ********/

/**** Update the User menus ****/

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 8
	WHERE WebForm = 'LogOff.aspx' AND Rights = 'USER'
GO

/**** Update the Administrator menus ****/

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 7
	WHERE WebForm = 'AD_WebLink.aspx' AND Rights = 'ADMIN'
GO

INSERT INTO [dbo].[SupportOptions]
	(Description, WebForm, Rights, MenuOrder) VALUES
	('HOSTINFO Assignment', 'AD_HostInfoMgmt.aspx', 'ADMIN', 13)
GO

INSERT INTO [dbo].[SupportOptions]
	(Description, WebForm, Rights, MenuOrder) VALUES
	('Batch Operations', 'AD_BatchOperations.aspx', 'ADMIN', 14)
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 15
	WHERE WebForm = 'AD_SearchTA.aspx' AND Rights = 'ADMIN'
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 16
	WHERE WebForm = 'AD_AuditLog.aspx' AND Rights = 'ADMIN'
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 17
	WHERE WebForm = 'AD_ChangePWD.aspx' AND Rights = 'ADMIN'
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 18
	WHERE WebForm = 'LogOff.aspx' AND Rights = 'ADMIN'
GO

/**** Update the Supervisor menus ****/

INSERT INTO [dbo].[SupportOptions]
	(Description, WebForm, Rights, MenuOrder) VALUES
	('HOSTINFO Management', 'SP_HostInfoMgmt.aspx', 'SUPER', 5)
GO

INSERT INTO [dbo].[SupportOptions]
	(Description, WebForm, Rights, MenuOrder) VALUES
	('Batch Management', 'SP_BatchOperations.aspx', 'SUPER', 6)
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 7
	WHERE WebForm = 'SP_SearchTA.aspx' AND Rights = 'SUPER'
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 8
	WHERE WebForm = 'SP_ListAllTAs.aspx' AND Rights = 'SUPER'
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 9
	WHERE WebForm = 'SP_SearchAuditLog.aspx' AND Rights = 'SUPER'
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 10
	WHERE WebForm = 'CheckAuditLog.aspx' AND Rights = 'SUPER'
GO

UPDATE [dbo].[SupportOptions] SET
	MenuOrder = 11
	WHERE WebForm = 'LogOff.aspx' AND Rights = 'SUPER'
GO


/**** All users can use the Emul.aspx to display or manage the configuration ****/
UPDATE [dbo].[SupportOptions] SET
	WebForm = 'DisplayEmul.aspx'
	WHERE WebForm = 'Emul.aspx'
