USE [master]
GO
/****** Object:  Database [ExpenseSample]    Script Date: 01/29/2009 16:03:42 ******/
CREATE DATABASE [ExpenseSample] 
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'ExpenseSample', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExpenseSample].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [ExpenseSample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExpenseSample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExpenseSample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExpenseSample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExpenseSample] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExpenseSample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExpenseSample] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ExpenseSample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExpenseSample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExpenseSample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExpenseSample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExpenseSample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExpenseSample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExpenseSample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExpenseSample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExpenseSample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ExpenseSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExpenseSample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExpenseSample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExpenseSample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExpenseSample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExpenseSample] SET  READ_WRITE 
GO
ALTER DATABASE [ExpenseSample] SET RECOVERY FULL 
GO
ALTER DATABASE [ExpenseSample] SET  MULTI_USER 
GO
ALTER DATABASE [ExpenseSample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExpenseSample] SET DB_CHAINING OFF 

USE [ExpenseSample]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 01/29/2009 16:06:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Expenses](
	[ExpenseID] [bigint] IDENTITY(1,1) NOT NULL,
	[WorkflowID] [uniqueidentifier] NULL,
	[Employee] [varchar](50) NULL,
	[ExpenseDate] [datetime] NULL,
	[Amount] [float] NULL,
	[CategoryID] [tinyint] NULL,
	[Description] [varchar](200) NULL,
	[StatusID] [tinyint] NULL,
	[AssignedTo] [varchar](50) NULL,
	[IsCompleted] [bit] NULL,
	[DateSubmitted] [datetime] NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Expenses_1] PRIMARY KEY CLUSTERED 
(
	[ExpenseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ExpenseReviews]    Script Date: 01/29/2009 16:04:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ExpenseReviews](
	[ReviewID] [bigint] IDENTITY(1,1) NOT NULL,
	[ExpenseID] [bigint] NULL,
	[Reviewer] [varchar](50) NULL,
	[Remarks] [varchar](200) NULL,
	[IsApproved] [bit] NULL,
	[DateApproved] [datetime] NULL,
 CONSTRAINT [PK_ExpenseReviews] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ExpenseReviews]  WITH CHECK ADD  CONSTRAINT [FK_ExpenseReviews_Expenses1] FOREIGN KEY([ExpenseID])
REFERENCES [dbo].[Expenses] ([ExpenseID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ExpenseReviews] CHECK CONSTRAINT [FK_ExpenseReviews_Expenses1]
GO

/****** Object:  Table [dbo].[ExpenseLogs]    Script Date: 01/29/2009 16:04:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExpenseLogs](
	[LogID] [bigint] IDENTITY(1,1) NOT NULL,
	[ExpenseID] [bigint] NULL,
	[StatusID] [tinyint] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_ExpenseLogs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ExpenseLogs]  WITH CHECK ADD  CONSTRAINT [FK_ExpenseLogs_Expenses1] FOREIGN KEY([ExpenseID])
REFERENCES [dbo].[Expenses] ([ExpenseID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ExpenseLogs] CHECK CONSTRAINT [FK_ExpenseLogs_Expenses1]
GO

