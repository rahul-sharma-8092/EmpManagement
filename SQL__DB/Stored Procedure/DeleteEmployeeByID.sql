-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[DeleteEmployeeByID]
	@empID BIGINT = 0
AS
BEGIN
	SET NOCOUNT OFF;

	Update Employee SET IsDeleted = 1, ModifiedAt = GETDATE() WHERE EmpID = @empID

END
GO