-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[GetAllEmployees]
	@pageIndex INT = 1,
	@pageSize INT = 10,
	@search NVARCHAR(100) = ''
AS
BEGIN
	
	SELECT 

	(SELECT COUNT(1) FROM Employee
		WHERE IsDeleted = 0 AND (FirstName LIKE '%' + @search +'%' OR LastName LIKE '%' + @search +'%' OR Email LIKE '%' + @search +'%'
		OR Phone LIKE '%' + @search +'%') 	
	) AS [RowCount],
	
	* FROM Employee 
	WHERE IsDeleted = 0 AND (FirstName LIKE '%' + @search +'%' OR LastName LIKE '%' + @search +'%' OR Email LIKE '%' + @search +'%'
	OR Phone LIKE '%' + @search +'%') 	
	ORDER by EmpID DESC OFFSET (@pageIndex-1)*@pageSize ROWS FETCH NEXT @pageSize ROWS ONLY

END
GO