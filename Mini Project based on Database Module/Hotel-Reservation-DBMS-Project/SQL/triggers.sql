USE HotelReservationDB;
GO


-- Trigger to prevent double booking
CREATE OR ALTER TRIGGER dbo.trg_ReservationRoom_PreventDoubleBooking
ON dbo.ReservationRoom
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
        SELECT 1
        FROM inserted i
        INNER JOIN dbo.Reservation newR ON i.ReservationID = newR.ReservationID
        INNER JOIN dbo.ReservationRoom existingRR ON i.RoomID = existingRR.RoomID
        INNER JOIN dbo.Reservation existingR ON existingRR.ReservationID = existingR.ReservationID
        WHERE existingRR.ReservationRoomID <> i.ReservationRoomID
          AND newR.ReservationStatus IN ('Booked', 'CheckedIn')
          AND existingR.ReservationStatus IN ('Booked', 'CheckedIn')
          AND newR.CheckInDate < existingR.CheckOutDate
          AND newR.CheckOutDate > existingR.CheckInDate
    )
    BEGIN
        RAISERROR('Double booking is not allowed for the selected room and date range.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;

    INSERT INTO dbo.AuditLog (TableName, ActionType, RecordID, Description)
    SELECT
        'ReservationRoom',
        'INSERT/UPDATE',
        i.ReservationRoomID,
        CONCAT('Room ', i.RoomID, ' assigned to reservation ', i.ReservationID)
    FROM inserted i;
END;
GO



-- Trigger to update room status
CREATE OR ALTER TRIGGER dbo.trg_Reservation_StatusUpdate
ON dbo.Reservation
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE rm
    SET RoomStatus =
        CASE
            WHEN i.ReservationStatus = 'CheckedIn' THEN 'Occupied'
            WHEN i.ReservationStatus IN ('CheckedOut', 'Cancelled', 'NoShow') THEN 'Available'
            ELSE rm.RoomStatus
        END
    FROM dbo.Room rm
    INNER JOIN dbo.ReservationRoom rr ON rm.RoomID = rr.RoomID
    INNER JOIN inserted i ON rr.ReservationID = i.ReservationID;

    INSERT INTO dbo.AuditLog (TableName, ActionType, RecordID, Description)
    SELECT
        'Reservation',
        'UPDATE',
        i.ReservationID,
        CONCAT('Reservation status changed from ', d.ReservationStatus, ' to ', i.ReservationStatus)
    FROM inserted i
    INNER JOIN deleted d ON i.ReservationID = d.ReservationID
    WHERE ISNULL(i.ReservationStatus, '') <> ISNULL(d.ReservationStatus, '');
END;
GO



-- Trigger to log room removal
CREATE OR ALTER TRIGGER dbo.trg_ReservationRoom_DeleteAudit
ON dbo.ReservationRoom
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.AuditLog (TableName, ActionType, RecordID, Description)
    SELECT
        'ReservationRoom',
        'DELETE',
        d.ReservationRoomID,
        CONCAT('Room ', d.RoomID, ' removed from reservation ', d.ReservationID)
    FROM deleted d;
END;
GO
