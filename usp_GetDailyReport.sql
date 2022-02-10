USE [CDSoftware]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetDailyReport]    Script Date: 2/10/2022 9:35:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetDailyReport]
	-- Add the parameters for the stored procedure here
	@FromDate varchar(25),
	@ToDate varchar(25)
AS
BEGIN

	select MemberId,Membername,AccountBalance as Amount FROM tMember where AccountBalance >0 and IsDeleted=0;
	select MemberId,Membername,ABS(AccountBalance) as Amount FROM tMember where AccountBalance <0 and IsDeleted=0;
	--(SELECT t.MemberId, m.Membername,
	--		 ABS(SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END)-SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END)) as Amount
	--		 from tTransaction t
	--	INNER JOIN tMember m ON t.MemberId=m.MemberId 
	--	WHERE t.IsDeleted=0 AND  cast(t.TransDate as Date) >= cast(@FromDate as DATE) AND cast(t.TransDate as Date) <= cast(@ToDate as DATE) 
	--	GROUP BY t.MemberId,m.Membername having (SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END)-SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END)) > 0
	--	)

	--(SELECT 0 as MemberId, 'Previous Closing Balance' as Membername,
	--		(SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END)-SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END)) as Amount
	--		FROM tTransaction t
	--		WHERE t.IsDeleted=0 and cast(t.TransDate as Date) < cast(@FromDate as Date) and t.MemberId=1) 
	--UNION
	--(SELECT t.MemberId, m.Membername,
	--		 ABS(SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END)-SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END)) as Amount
	--		 from tTransaction t
	--	INNER JOIN tMember m ON t.MemberId=m.MemberId 
	--	WHERE t.IsDeleted=0 AND  cast(t.TransDate as Date) >= cast(@FromDate as DATE) AND cast(t.TransDate as Date) <= cast(@ToDate as DATE) 
	--	GROUP BY t.MemberId,m.Membername having (SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END)-SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END)) < 0
	--	)
END

GO

