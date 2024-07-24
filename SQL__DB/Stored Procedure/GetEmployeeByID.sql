-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[GetEmployeeByID]
	@EmpId BIGINT
AS
BEGIN
	
	Select * from Employee Where EmpID = @EmpId

END
GO