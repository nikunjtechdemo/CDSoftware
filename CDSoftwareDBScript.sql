USE [CDSoftware]
GO
/****** Object:  UserDefinedTableType [dbo].[dtAccountTo]    Script Date: 2/2/2022 10:37:52 AM ******/
CREATE TYPE [dbo].[dtAccountTo] AS TABLE(
	[MemberId] [int] NULL,
	[Membername] [varchar](50) NULL,
	[Amount] [numeric](18, 4) NULL
)
GO
/****** Object:  StoredProcedure [dbo].[Test]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Test] 
	-- Add the parameters for the stored procedure here
	@dtAccountTo dtAccountTo READONLY
AS
BEGIN
	select ROW_NUMBER()OVER(order by MemberId) as ROW_NO,Membername,Amount into #tmpAccountTo From @dtAccountTo;
	select * from #tmpAccountTo;
END

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteMember]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteMember]
	@MemberId int,
	@UserId int
AS
BEGIN
	IF(EXISTS(SELECT MemberId FROM tMember where MemberId=@MemberId))
	BEGIN
		UPDATE tMember SET IsActive=1,IsDeleted=1,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE MemberId=@MemberId;
		SELECT 1;
	END
	ELSE
	BEGIN
		SELECT 0;
	END
END

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteUser]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteUser]
	@UserId int
	
AS
BEGIN
	IF(EXISTS(SELECT Id FROM tUser where Id=@UserId))
	BEGIN
		UPDATE tUser SET IsDeleted=1 WHERE Id=@UserId;
		SELECT 1;
	END
	ELSE
	BEGIN
		SELECT 0;
	END

END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetMembers]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetMembers]
	
AS
BEGIN
	SELECT MemberId,Membername,[Address],ContactNo,AccountBalance FROM tMember WHERE IsDeleted=0;

	SELECT SUM(AccountBalance) as Balance from tMember WHERE IsDeleted=0;
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetUsers]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetUsers]
	
AS
BEGIN
	SELECT id,username,[password] FROM tUser where IsDeleted=0;
END

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertMember]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertMember]
	@MemberName varchar(50),
	@Address varchar(150),
	@ContactNo varchar(10),
	@AccountBalance numeric(18,4),
	@UserId int
AS
BEGIN
	
INSERT INTO [dbo].[tMember]
           ([Membername]
           ,[Address]
           ,[ContactNo]
           ,[AccountBalance]
           ,[IsActive]
           ,[IsDeleted]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[ModifiedBy]
           ,[ModifiedOn])
     VALUES
           (@MemberName
           ,@Address
           ,@ContactNo           
		   ,@AccountBalance
           ,1
           ,0
           ,@UserId
           ,GETDATE()
           ,@UserId
           ,GETDATE());

INSERT INTO [dbo].[tTransaction]
           ([MemberId]
           ,[TransType]
           ,[TransDate]
           ,[Amount]
           ,[OpeningBalance]
           ,[Description]
           ,[Comments]
           ,[IsDeleted]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[ModifiedBy]
           ,[ModifiedOn])
     VALUES
           (@@IDENTITY
           ,0
           ,convert(varchar,getdate(),106)
           ,@AccountBalance
           ,0
           ,'Openning Balance'
           ,''
           ,0
           ,@UserId
           ,GETDATE()
           ,@UserId
           ,GETDATE())


	
  SELECT @@IDENTITY;		
END

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTransaction]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertTransaction]
	@MemberId int,
	@TransType Bit,
	@TransDate varchar(25),
	@Amount numeric(18,4),
	@Description varchar(500),
	@Comment varchar(200),
	@UserId int
AS
BEGIN
	
Begin Transaction
Declare @OpeningBalance numeric(18,4)
select @OpeningBalance=AccountBalance from tMember where MemberId=@MemberId;
INSERT INTO [dbo].[tTransaction]
           ([MemberId]
           ,[TransType]
           ,[TransDate]
           ,[Amount]
		   ,[OpeningBalance]
           ,[Description]
           ,[Comments]
           ,[IsDeleted]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[ModifiedBy]
           ,[ModifiedOn])
     VALUES
           (@MemberId
           ,@TransType
           ,@TransDate
           ,@Amount
		   ,@OpeningBalance
           ,@Description
           ,@Comment
           ,0
           ,@UserId
           ,GETDATE()
           ,@UserId
           ,GETDATE())


if (@TransType=0)
begin
UPDATE tMember SET AccountBalance=(AccountBalance+@Amount) WHERE MemberId=@MemberId;
end
else
begin
UPDATE tMember SET AccountBalance=(AccountBalance-@Amount) WHERE MemberId=@MemberId;
end

Commit Transaction

SELECT @@IDENTITY;




END

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertUser]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertUser]
	@Username nvarchar(50),
	@Password nvarchar(50),
	@UserId int
AS
BEGIN
	

INSERT INTO [dbo].[tUser]
           ([username]
           ,[password]
           ,[IsAdmin]
           ,[IsActive]
           ,[IsDeleted]
           ,[CreatedBy]
           ,[CreatedOn])
     VALUES
           (@Username
           ,@Password
           ,0
           ,1
           ,0
           ,@UserId
           ,GETDATE());

SELECT @@IDENTITY

END

GO
/****** Object:  StoredProcedure [dbo].[usp_TransactionHistory]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TransactionHistory]
	@TransFromDate varchar(25),
	@TransToDate varchar(25),
	@MemberId int
AS
BEGIN
	IF(@MemberId=0)
	BEGIN
		SELECT * INTO #temp FROM 
		((SELECT 0 as TransID, NULL as MemberId, NULL as TransactionDate,NULL as Membername,
			SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END) as Credit,
			SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END) as Debit,
			(SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END)-SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END)) as Balance,
			'Previous Closing Balance' as [Description],'' as Comments
			FROM tTransaction t
			WHERE t.IsDeleted=0 and cast(t.TransDate as Date) < cast(@TransFromDate as Date))
		UNION
		(SELECT t.TransId, t.MemberId,convert(varchar,t.TransDate,106) as TransactionDate, m.Membername,
			 CASE WHEN TransType=0 THEN Amount END as Credit,
			 CASE WHEN TransType=1 THEN Amount END as Debit,
			 CASE when TransType=0 THEN t.OpeningBalance+Amount ELSE t.OpeningBalance-Amount END Balance,
			 t.[Description],Comments  from tTransaction t
		INNER JOIN tMember m ON t.MemberId=m.MemberId 
		WHERE t.IsDeleted=0 AND  cast(t.TransDate as Date) >= cast(@TransFromDate as DATE) AND cast(t.TransDate as Date) <= cast(@TransToDate as DATE)
		)) A

		SELECT * FROM #temp

		SELECT SUM(Credit) as Credit, SUM(Debit) as Debit, (SUM(Credit)-SUM(Debit)) as Balance FROM #temp 
		--SELECT t.TransId, t.MemberId,convert(varchar,t.TransDate,106) as TransactionDate, m.Membername,
		--	 CASE WHEN TransType=0 THEN Amount END as Credit,
		--	 CASE WHEN TransType=1 THEN Amount END as Debit,
		--	 CASE when TransType=0 THEN t.OpeningBalance+Amount ELSE t.OpeningBalance-Amount END Balance,
		--	 t.[Description],Comments  from tTransaction t
		--INNER JOIN tMember m ON t.MemberId=m.MemberId 
		--WHERE t.IsDeleted=0 AND  cast(t.TransDate as Date) >= cast(@TransFromDate as DATE) AND cast(t.TransDate as Date) <= cast(@TransToDate as DATE);

		--SELECT  SUM(case WHEN TransType=0 THEN Amount END) as Credit,SUM(case WHEN TransType=1 THEN Amount END) as Debit, (SUM(case WHEN TransType=0 THEN Amount END) - SUM(case WHEN TransType=1 THEN Amount END)) as Balance
		--FROM tTransaction t 
		--WHERE t.IsDeleted=0 AND  cast(t.TransDate as Date) >= cast(@TransFromDate as DATE) AND cast(t.TransDate as Date) <= cast(@TransToDate as DATE);
	END
	ELSE
	BEGIN
		SELECT * INTO #temp1 FROM 
		((SELECT 0 as TransID, NULL as MemberId, NULL as TransactionDate,NULL as Membername,
			SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END) as Credit,
			SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END) as Debit,
			(SUM(CASE WHEN TransType=0 THEN Amount ELSE 0 END)-SUM(CASE WHEN TransType=1 THEN Amount ELSE 0 END)) as Balance,
			'Previous Closing Balance' as [Description],'' as Comments
			FROM tTransaction t
			WHERE t.IsDeleted=0 AND t.MemberId=@MemberId and cast(t.TransDate as Date) < cast(@TransFromDate as Date))
		UNION
		(SELECT t.TransId, t.MemberId,convert(varchar,t.TransDate,106) as TransactionDate, m.Membername,
			 CASE WHEN TransType=0 THEN Amount END as Credit,
			 CASE WHEN TransType=1 THEN Amount END as Debit,
			 CASE when TransType=0 THEN t.OpeningBalance+Amount ELSE t.OpeningBalance-Amount END Balance,
			 t.[Description],Comments  from tTransaction t
		INNER JOIN tMember m ON t.MemberId=m.MemberId AND t.MemberId=@MemberId
		WHERE t.IsDeleted=0 AND  cast(t.TransDate as Date) >= cast(@TransFromDate as DATE) AND cast(t.TransDate as Date) <= cast(@TransToDate as DATE)
		)) A

		SELECT * FROM #temp1

		SELECT SUM(Credit) as Credit, SUM(Debit) as Debit, (SUM(Credit)-SUM(Debit)) as Balance FROM #temp1
		--SELECT t.TransId, t.MemberId,convert(varchar,t.TransDate,106) as TransactionDate, m.Membername,
		--	 CASE WHEN TransType=0 THEN Amount END as Credit,
		--	 CASE WHEN TransType=1 THEN Amount END as Debit,
		--	 CASE when TransType=0 THEN t.OpeningBalance+Amount ELSE t.OpeningBalance-Amount END Balance,
		--	 t.[Description],Comments  from tTransaction t 
		--INNER JOIN tMember m ON t.MemberId=m.MemberId AND m.MemberId=@MemberId
		--WHERE t.IsDeleted=0 AND  cast(t.TransDate as Date) >= cast(@TransFromDate as DATE) AND cast(t.TransDate as Date) <= cast(@TransToDate as DATE);

		--SELECT  SUM(case WHEN TransType=0 THEN Amount END) as Credit,SUM(case WHEN TransType=1 THEN Amount END) as Debit, (SUM(case WHEN TransType=0 THEN Amount END) - SUM(case WHEN TransType=1 THEN Amount END)) as Balance
		--FROM tTransaction t 
		--WHERE t.IsDeleted=0 AND  cast(t.TransDate as Date) >= cast(@TransFromDate as DATE) AND cast(t.TransDate as Date) <= cast(@TransToDate as DATE)
		--AND t.MemberId=@MemberId
	END
END

GO
/****** Object:  StoredProcedure [dbo].[usp_TransferMoney]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_TransferMoney]
	@AccountFrom int,
	@dtAccountTo  dtAccountTo READONLY,
	--@AccountTo int,
	@TransDate varchar(25),
	--@Amount numeric(18,4),
	--@DescriptionFrom varchar(500),
	--@DescriptionTo varchar(500),
	
	@Comment varchar(200),
	@UserId int
AS
BEGIN

begin transaction
	select ROW_NUMBER()OVER(order by MemberId) as ROW_NO,MemberId,Membername,Amount into #tmpAccountTo From @dtAccountTo;

	Declare @RowCount int;
	Select @RowCount=Count(1) FROM #tmpAccountTo;
	Declare @ROWID int=1;
	WHILE @RowCount>=@ROWID
	BEGIN
			begin transaction
			Declare @AccountTo int,@Amount numeric(18,4),@DescriptionFrom varchar(500),@DescriptionTo varchar(500),@FromMember varchar(50),@ToMember varchar(50)
			
			SELECT @AccountTo=MemberId, @Amount=Amount,@ToMember=Membername From #tmpAccountTo where ROW_NO=@ROWID;

			Declare @OpeningBalance numeric(18,4)
			select @OpeningBalance=AccountBalance,@FromMember=Membername from tMember where MemberId=@AccountFrom;

			SET @DescriptionFrom='Transfered to ' +@ToMember;
			SET @DescriptionTo='Credited from ' + @FromMember;

			INSERT INTO [dbo].[tTransaction]
				   ([MemberId]
				   ,[TransType]
				   ,[TransDate]
				   ,[Amount]
				   ,[OpeningBalance]
				   ,[Description]
				   ,[Comments]
				   ,[IsDeleted]
				   ,[CreatedBy]
				   ,[CreatedOn]
				   ,[ModifiedBy]
				   ,[ModifiedOn])
			 VALUES
				   (@AccountFrom
				   ,1
				   ,@TransDate
				   ,@Amount
				   ,@OpeningBalance
				   ,@DescriptionFrom
				   ,@Comment
				   ,0
				   ,@UserId
				   ,GETDATE()
				   ,@UserId
				   ,GETDATE())

			UPDATE tMember SET AccountBalance=(AccountBalance-@Amount) WHERE MemberId=@AccountFrom;
	
			select @OpeningBalance=AccountBalance from tMember where MemberId=@AccountTo;

			INSERT INTO [dbo].[tTransaction]
				   ([MemberId]
				   ,[TransType]
				   ,[TransDate]
				   ,[Amount]
				   ,[OpeningBalance]
				   ,[Description]
				   ,[Comments]
				   ,[IsDeleted]
				   ,[CreatedBy]
				   ,[CreatedOn]
				   ,[ModifiedBy]
				   ,[ModifiedOn])
			 VALUES
				   (@AccountTo
				   ,0
				   ,@TransDate
				   ,@Amount
				   ,@OpeningBalance
				   ,@DescriptionTo
				   ,@Comment
				   ,0
				   ,@UserId
				   ,GETDATE()
				   ,@UserId
				   ,GETDATE())

			 UPDATE tMember SET AccountBalance=(AccountBalance+@Amount) WHERE MemberId=@AccountTo;

			 SET @ROWID+=1;
			 commit transaction
	END
	SELECT @@IDENTITY;
commit Transaction

END

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateMember]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateMember]
	@MemberId int,
	@MemberName varchar(50),
	@Address varchar(150),
	@ContactNo varchar(10),
	@AccountBalance numeric(18,4),
	@UserId int
AS
BEGIN
	IF(EXISTS(SELECT MemberId FROM tMember where MemberId=@MemberId))
	BEGIN
		UPDATE tMember SET Membername=@MemberName,[Address]=@Address,ContactNo=@ContactNo,AccountBalance=@AccountBalance,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE MemberId=@MemberId;
		SELECT 1;
	END
	ELSE
	BEGIN
		SELECT 0;
	END
END

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateTransaction]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdateTransaction]
	@TransId Int,
	@Amount numeric(18,4),
	@IsDelete bit,
	@UserId Int
AS
BEGIN
	Begin Transaction
	Declare @MemberId int,@OldAmount numeric(18,4),@TransType bit,@Result numeric(18,4)

	SELECT @MemberId=MemberId,@OldAmount=Amount,@TransType=TransType  From tTransaction WHERE TransId=@TransId
	iF(@IsDelete=1)
	begin
		SET @Result=@Amount-@OldAmount

		UPDATE tTransaction SET Amount=@Amount,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE TransId=@TransId

		If(@TransType=0)
		Begin
			UPDATE tTransaction SET OpeningBalance+=@Result,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE TransId >@TransId and MemberId=@MemberId
			UPDATE tMember SET AccountBalance+=@Result,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE MemberId=@MemberId 
			SELECT 1
		end
		else
		begin
			UPDATE tTransaction SET OpeningBalance-=@Result,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE TransId >@TransId and MemberId=@MemberId
			UPDATE tMember SET AccountBalance-=@Result,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE MemberId=@MemberId
			SELECT 1
		end
	end
	ELSE
	begin
		UPDATE tTransaction SET IsDeleted=1,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE TransId=@TransId
		If(@TransType=0)
		Begin
			UPDATE tTransaction SET OpeningBalance-=@OldAmount,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE TransId >@TransId and MemberId=@MemberId
			UPDATE tMember SET AccountBalance-=@OldAmount,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE MemberId=@MemberId
			SELECT 1
		end
		else
		begin
			UPDATE tTransaction SET OpeningBalance+=@OldAmount,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE TransId >@TransId and MemberId=@MemberId
			UPDATE tMember SET AccountBalance+=@OldAmount,ModifiedBy=@UserId,ModifiedOn=GETDATE() WHERE MemberId=@MemberId
			SELECT 1
		end
	end
	commit Transaction

	
END

GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateUser]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateUser]
	@Username nvarchar(50),
	@Password nvarchar(50),
	@UserId   int
AS
BEGIN
	IF(EXISTS(SELECT Id FROM tUser where Id=@UserId))
	BEGIN
		UPDATE tUser SET username=@Username, [password]=@Password WHERE Id=@UserId;
		SELECT 1;
	END
	ELSE
	BEGIN
		SELECT 0;
	END
END

GO
/****** Object:  StoredProcedure [dbo].[usp_ValidateLogin]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ValidateLogin]
	@Username nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	SELECT Id,username,IsAdmin,IsActive,CreatedBy FROM tUser
	WHERE username=@Username AND [password]=@Password and IsDeleted=0 and IsActive=1
END

GO
/****** Object:  Table [dbo].[tMember]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tMember](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[Membername] [varchar](50) NOT NULL,
	[Address] [varchar](150) NOT NULL,
	[ContactNo] [varchar](10) NOT NULL,
	[AccountBalance] [numeric](18, 4) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK__tMember__0CF04B1879E13625] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tTransaction]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tTransaction](
	[TransId] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[TransType] [bit] NOT NULL,
	[TransDate] [varchar](25) NOT NULL,
	[Amount] [numeric](18, 4) NOT NULL,
	[OpeningBalance] [numeric](18, 4) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Comments] [varchar](200) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK__tTransac__9E5DDB3CDD8FD69C] PRIMARY KEY CLUSTERED 
(
	[TransId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tUser]    Script Date: 2/2/2022 10:37:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tMember] ADD  CONSTRAINT [DF__tMember__Account__31EC6D26]  DEFAULT ((0)) FOR [AccountBalance]
GO
ALTER TABLE [dbo].[tMember] ADD  CONSTRAINT [DF__tMember__IsActiv__32E0915F]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tMember] ADD  CONSTRAINT [DF__tMember__IsDelet__33D4B598]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tTransaction] ADD  CONSTRAINT [DF__tTransact__IsDel__30F848ED]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tUser] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[tUser] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tUser] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
