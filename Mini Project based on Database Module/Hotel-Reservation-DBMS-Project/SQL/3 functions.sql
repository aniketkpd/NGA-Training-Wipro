USE HotelReservationDB;
GO

-- Function for calculating the total amount of a reservation
CREATE OR ALTER FUNCTION dbo.fn_CalculateReservationAmount (@ReservationID INT)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @RoomAmount DECIMAL(12,2) = 0;
    DECLARE @ServiceAmount DECIMAL(12,2) = 0;
    DECLARE @TaxRate DECIMAL(5,2) = 0;
    DECLARE @Total DECIMAL(12,2) = 0;

    SELECT
        @RoomAmount = COALESCE(SUM(DATEDIFF(DAY, r.CheckInDate, r.CheckOutDate) * rr.AssignedRate), 0),
        @TaxRate = MAX(r.TaxRate)
    FROM dbo.Reservation r
    INNER JOIN dbo.ReservationRoom rr ON r.ReservationID = rr.ReservationID
    WHERE r.ReservationID = @ReservationID
    GROUP BY r.ReservationID;

    SELECT @ServiceAmount = COALESCE(SUM(rs.Quantity * rs.ChargedPrice), 0)
    FROM dbo.ReservationService rs
    WHERE rs.ReservationID = @ReservationID;

    SET @Total = (@RoomAmount + @ServiceAmount) * (1 + COALESCE(@TaxRate, 0) / 100.0);
    RETURN @Total;
END;
GO





-- Function for finding available rooms
CREATE OR ALTER FUNCTION dbo.fn_AvailableRooms
(
    @CheckInDate DATE,
    @CheckOutDate DATE,
    @CategoryID INT = NULL
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        rm.RoomID,
        rm.RoomNumber,
        rc.CategoryName,
        rc.BaseRate,
        rm.FloorNo,
        rm.RoomStatus
    FROM dbo.Room rm
    INNER JOIN dbo.RoomCategory rc ON rm.CategoryID = rc.CategoryID
    WHERE rm.RoomStatus = 'Available'
      AND (@CategoryID IS NULL OR rm.CategoryID = @CategoryID)
      AND NOT EXISTS
      (
          SELECT 1
          FROM dbo.ReservationRoom rr
          INNER JOIN dbo.Reservation r ON rr.ReservationID = r.ReservationID
          WHERE rr.RoomID = rm.RoomID
            AND r.ReservationStatus IN ('Booked', 'CheckedIn')
            AND @CheckInDate < r.CheckOutDate
            AND @CheckOutDate > r.CheckInDate
      )
);
GO
