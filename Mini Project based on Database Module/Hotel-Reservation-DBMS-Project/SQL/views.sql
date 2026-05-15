USE HotelReservationDB;
GO

-- view to display reservation details
CREATE OR ALTER VIEW dbo.vwReservationDetails AS
SELECT
    r.ReservationID,
    c.FullName AS CustomerName,
    c.Phone,
    rm.RoomNumber,
    rc.CategoryName,
    r.CheckInDate,
    r.CheckOutDate,
    DATEDIFF(DAY, r.CheckInDate, r.CheckOutDate) AS Nights,
    rr.AssignedRate,
    r.ReservationStatus,
    s.FullName AS StaffName
FROM dbo.Reservation r
INNER JOIN dbo.Customer c ON r.CustomerID = c.CustomerID
INNER JOIN dbo.Staff s ON r.StaffID = s.StaffID
INNER JOIN dbo.ReservationRoom rr ON r.ReservationID = rr.ReservationID
INNER JOIN dbo.Room rm ON rr.RoomID = rm.RoomID
INNER JOIN dbo.RoomCategory rc ON rm.CategoryID = rc.CategoryID;
GO


-- view to display current room status
CREATE OR ALTER VIEW dbo.vwCurrentRoomStatus AS
SELECT
    rm.RoomID,
    rm.RoomNumber,
    rc.CategoryName,
    rc.BaseRate,
    rm.FloorNo,
    rm.RoomStatus,
    h.HotelName,
    h.City
FROM dbo.Room rm
INNER JOIN dbo.RoomCategory rc ON rm.CategoryID = rc.CategoryID
INNER JOIN dbo.Hotel h ON rm.HotelID = h.HotelID;
GO


-- view to display occupancy by category
CREATE OR ALTER VIEW dbo.vwOccupancyByCategory AS
SELECT
    rc.CategoryName,
    COUNT(rm.RoomID) AS TotalRooms,
    SUM(CASE WHEN rm.RoomStatus = 'Occupied' THEN 1 ELSE 0 END) AS OccupiedRooms,
    CAST(SUM(CASE WHEN rm.RoomStatus = 'Occupied' THEN 1 ELSE 0 END) * 100.0 / COUNT(rm.RoomID) AS DECIMAL(5,2)) AS OccupancyPercent
FROM dbo.RoomCategory rc
LEFT JOIN dbo.Room rm ON rc.CategoryID = rm.CategoryID
GROUP BY rc.CategoryName;
GO



-- view to display monthly revenue
CREATE OR ALTER VIEW dbo.vwMonthlyRevenue AS
SELECT
    YEAR(p.PaymentDate) AS RevenueYear,
    MONTH(p.PaymentDate) AS RevenueMonth,
    SUM(CASE WHEN p.PaymentStatus = 'Success' THEN p.Amount ELSE 0 END) AS SuccessfulRevenue,
    COUNT(CASE WHEN p.PaymentStatus = 'Success' THEN 1 END) AS SuccessfulPayments
FROM dbo.Payment p
GROUP BY YEAR(p.PaymentDate), MONTH(p.PaymentDate);
GO
