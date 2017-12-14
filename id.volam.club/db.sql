USE [account_tong]
GO
/****** Object:  StoredProcedure [dbo].[AddAccount]    Script Date: 12/13/2017 19:30:00 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
/****** Object:  Stored Procedure dbo.AddAccount    Script Date: 2004-11-8 16:58:08 ******/








ALTER               proc [dbo].[AddAccount]
    @vAccountName varchar(255) = 'jxbb000430'
as

set nocount on
Insert Into dbo.Account_Info
		(cAccName,cSecPassWord,cPassWord,nExtPoint,nExtPoint1,nExtPoint2,nExtPoint3,nExtPoint4,nExtPoint5,nExtPoint6,nExtPoint7) 
	Values(@vAccountName,'0CC175B9C0F1B6A831C399E269772661','0CC175B9C0F1B6A831C399E269772661',0,0,0,0,0,0,0,0)

Insert Into dbo.account_Habitus
		(cAccName,iLeftSecond,dEndDate) 
	Values(@vAccountName,100000,'2020-12-31')
