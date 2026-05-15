USE HotelReservationDB;
GO


-- Indexes to improve query performance
CREATE NONCLUSTERED INDEX IX_Reservation_DateStatus
ON dbo.Reservation (CheckInDate, CheckOutDate, ReservationStatus)
INCLUDE (CustomerID, StaffID);
GO

CREATE NONCLUSTERED INDEX IX_ReservationRoom_Room
ON dbo.ReservationRoom (RoomID, ReservationID);
GO

CREATE NONCLUSTERED INDEX IX_Customer_Name
ON dbo.Customer (FullName)
INCLUDE (Email, Phone);
GO

CREATE NONCLUSTERED INDEX IX_Payment_ReservationStatus
ON dbo.Payment (ReservationID, PaymentStatus)
INCLUDE (Amount, PaymentDate);
GO

SET STATISTICS IO ON;
SELECT * FROM dbo.fn_AvailableRooms('2026-06-01', '2026-06-04', NULL);
SET STATISTICS IO OFF;
GO
