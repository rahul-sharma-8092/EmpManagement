CREATE TABLE [dbo].[Logs]
(
	ID BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	EmpID BIGINT NULL,
	[Descriptions] NVARCHAR(MAX),
	[Timestamp] DateTime DEFAULT GETDATE(),
)
GO

-- =============================================
-- Author:      <Rahul Sharma>
-- Create date: <25/07/2024>
-- Description: Trigger to track changes in the Employee table
-- =============================================
CREATE TRIGGER [dbo].[Employee_ChangeTracking]
   ON [dbo].[Employee]
   AFTER INSERT, UPDATE, DELETE
AS 
BEGIN
    DECLARE @empId BIGINT, @name NVARCHAR(250), @descriptions NVARCHAR(MAX);

    IF EXISTS (SELECT 1 FROM INSERTED i INNER JOIN DELETED d ON i.EmpID = d.EmpID)
    BEGIN
        SELECT @empId = i.EmpID, 
               @name = CONCAT(i.FirstName, ' ', i.LastName)
        FROM INSERTED i
        INNER JOIN DELETED d ON i.EmpID = d.EmpID;

		IF(UPDATE(Isdeleted))
		BEGIN
			SET @descriptions = CONCAT('Employee DELETED - ID: ', @empId, ' Name: ', @name);
		END
		ELSE
		BEGIN
			IF(UPDATE(FirstName) OR UPDATE(LastName))
			BEGIN
				Select @name = CONCAT(D.FirstName, ' ', D.LastName, ' --> ', I.FirstName, ' ', I.LastName) from INSERTED I INNER JOIN DELETED D ON I.EmpID = D.EmpID
				SET @descriptions = CONCAT('Employee details updated - ID: ', @empId, ' Name: ', @name);
			END
			ELSE
			BEGIN
				SET @descriptions = CONCAT('Employee details updated - ID: ', @empId, ' Name: ', @name);
			END
		END

        INSERT INTO Logs (EmpID, Descriptions) VALUES (@empId, @descriptions);
    END
	
	ELSE IF EXISTS(SELECT 1 FROM INSERTED)
    BEGIN
        SELECT @empId = EmpID, @name = CONCAT(FirstName, ' ', LastName) FROM INSERTED;

        SET @descriptions = CONCAT('New Employee Added ID: ', @empId, ' Name: ', @name);

        INSERT INTO Logs (EmpID, Descriptions)
        VALUES (@empId, @descriptions);
    END

    ELSE IF EXISTS (SELECT 1 FROM DELETED)
    BEGIN
        SELECT @empId = EmpID, @name = CONCAT(FirstName, ' ', LastName) FROM DELETED;

        SET @descriptions = CONCAT('Employee parmanently DELETED - ID: ', @empId, ' Name: ', @name);

        INSERT INTO Logs (EmpID, Descriptions)
        VALUES (@empId, @descriptions);
    END
END
GO
