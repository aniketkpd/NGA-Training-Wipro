USE HotelReservationDB;
GO

-- COMMIT demo: create a valid reservation and payment.
BEGIN TRANSACTION;
    INSERT INTO dbo.Reservation (CustomerID, StaffID, CheckInDate, CheckOutDate, ReservationStatus, TaxRate)
    VALUES (1, 1, '2026-07-01', '2026-07-03', 'Booked', 12.00);

    DECLARE @CommittedReservationID INT = SCOPE_IDENTITY();

    INSERT INTO dbo.ReservationRoom (ReservationID, RoomID, AssignedRate)
    VALUES (@CommittedReservationID, 4, 4200.00);

    INSERT INTO dbo.Payment (ReservationID, PaymentMethodID, Amount, PaymentStatus, ReferenceNo)
    VALUES (@CommittedReservationID, 3, 5000.00, 'Success', 'PAY-COMMIT-1001');
COMMIT TRANSACTION;
GO

-- ROLLBACK demo: intentionally try to assign an already booked room for overlapping dates.
BEGIN TRY
    BEGIN TRANSACTION;
        INSERT INTO dbo.Reservation (CustomerID, StaffID, CheckInDate, CheckOutDate, ReservationStatus, TaxRate)
        VALUES (2, 1, '2026-06-02', '2026-06-03', 'Booked', 12.00);

        DECLARE @RollbackReservationID INT = SCOPE_IDENTITY();

        INSERT INTO dbo.ReservationRoom (ReservationID, RoomID, AssignedRate)
        VALUES (@RollbackReservationID, 1, 2500.00);
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    SELECT ERROR_MESSAGE() AS RollbackReason;
END CATCH;
GO

-- Role-based access simulation using DCL.
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'HotelReadOnlyRole')
    CREATE ROLE HotelReadOnlyRole;
GO

GRANT SELECT ON dbo.vwReservationDetails TO HotelReadOnlyRole;
GRANT SELECT ON dbo.vwCurrentRoomStatus TO HotelReadOnlyRole;
REVOKE SELECT ON dbo.vwCurrentRoomStatus FROM HotelReadOnlyRole;
GO
