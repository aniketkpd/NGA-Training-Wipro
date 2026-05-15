USE HotelReservationDB;
GO

IF OBJECT_ID('dbo.TempMaintenanceLog', 'U') IS NOT NULL DROP TABLE dbo.TempMaintenanceLog;

CREATE TABLE dbo.TempMaintenanceLog (
    TempLogID INT IDENTITY(1,1) PRIMARY KEY,
    RoomID INT NOT NULL,
    Notes VARCHAR(200) NOT NULL
);

INSERT INTO dbo.TempMaintenanceLog (RoomID, Notes)
VALUES (7, 'AC inspection'), (7, 'Fresh linen check');

TRUNCATE TABLE dbo.TempMaintenanceLog;

DROP TABLE dbo.TempMaintenanceLog;
GO
