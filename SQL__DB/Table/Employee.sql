CREATE TABLE [dbo].[Employee](
	[EmpID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL UNIQUE,
	[Phone] [nvarchar](12) NULL,
	[HireDate] [date] NULL DEFAULT GETDATE(),
	[Position] [nvarchar](100) NOT NULL,
	[Salary] [decimal](18, 2) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0,
	[CreatedAt] [datetime] NULL DEFAULT GETDATE(),
	[ModifiedAt] [datetime] NULL,
)