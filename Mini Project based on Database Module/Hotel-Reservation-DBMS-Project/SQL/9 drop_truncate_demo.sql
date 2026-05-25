USE HotelReservationDB;
GO

-- This script demonstrates the use of DROP and TRUNCATE statements in SQL Server.
IF OBJECT_ID('dbo.TempMaintenanceLog', 'U') IS NOT NULL DROP TABLE dbo.TempMaintenanceLog;


-- Create a temporary table to log maintenance activities for hotel rooms.
CREATE TABLE dbo.TempMaintenanceLog (
    TempLogID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT NOT NULL,
    Notes VARCHAR(200) NOT NULL
);


-- Insert sample maintenance log entries for RoomID 7.
INSERT INTO dbo.TempMaintenanceLog (RoomID, Notes)
VALUES (7, 'AC inspection'), (7, 'Fresh linen check');


-- Display the contents of the TempMaintenanceLog table.
SELECT * FROM dbo.TempMaintenanceLog;

-- Now, we will use the TRUNCATE statement to remove all records from the TempMaintenanceLog table.
TRUNCATE TABLE dbo.TempMaintenanceLog;


-- Display the contents of the TempMaintenanceLog table after truncation to confirm it's empty.
SELECT * FROM dbo.TempMaintenanceLog;

-- Finally, we will drop the TempMaintenanceLog table to clean up the database.
DROP TABLE dbo.TempMaintenanceLog;
GO
