-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[AddEditEmployee]
	@EmpID BIGINT = 0,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(50),
	@Phone NVARCHAR(50),
	@HireDate DATE,
	@Position NVARCHAR(100),
	@Salary DECIMAL(18,2),
	@Type NVARCHAR(5)
AS
BEGIN
	IF(@Type = 'Add')
	BEGIN
		
		INSERT INTO Employee(FirstName, LastName, Email, Phone, HireDate, Position, Salary)
		VALUES(LTRIM(RTRIM(@FirstName)), LTRIM(RTRIM(@LastName)), LTRIM(RTRIM(LOWER(@Email))), @Phone, @HireDate, @Position, @Salary);
		
		SELECT 1 AS [Return];

	END
	ELSE IF(@Type = 'Edit')
	BEGIN

		UPDATE Employee SET FirstName = LTRIM(RTRIM(@FirstName)), LastName = LTRIM(RTRIM(@LastName)), Email = LTRIM(RTRIM(LOWER(@Email))), Phone = @Phone,
		HireDate = @HireDate, Position = LTRIM(RTRIM(@Position)), Salary = @Salary, ModifiedAt = GETUTCDATE() 
		WHERE EmpID = @EmpID;

		Select 2 AS [Return];

	END
	ELSE
	BEGIN
		Select 0 AS [Return];
	END
END
GO