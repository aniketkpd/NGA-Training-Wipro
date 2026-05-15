USE HotelReservationDB;
GO

-- 1. INNER JOIN: reservation details with customer and room category.
SELECT *
FROM dbo.vwReservationDetails
ORDER BY CheckInDate;

-- 2. LEFT JOIN: all customers, including those without reservations.
SELECT c.CustomerID, c.FullName, COUNT(r.ReservationID) AS ReservationCount
FROM dbo.Customer c
LEFT JOIN dbo.Reservation r ON c.CustomerID = r.CustomerID
GROUP BY c.CustomerID, c.FullName
ORDER BY ReservationCount DESC;

-- 3. RIGHT JOIN: rooms and any reservation assignment.
SELECT rm.RoomNumber, r.ReservationID, r.ReservationStatus
FROM dbo.ReservationRoom rr
RIGHT JOIN dbo.Room rm ON rr.RoomID = rm.RoomID
LEFT JOIN dbo.Reservation r ON rr.ReservationID = r.ReservationID
ORDER BY rm.RoomNumber;

-- 4. FULL JOIN: compare room categories and rooms even if one side is missing.
SELECT rc.CategoryName, rm.RoomNumber, rm.RoomStatus
FROM dbo.RoomCategory rc
FULL JOIN dbo.Room rm ON rc.CategoryID = rm.CategoryID
ORDER BY rc.CategoryName, rm.RoomNumber;

-- 5. GROUP BY and HAVING: categories with more than one room.
SELECT rc.CategoryName, COUNT(rm.RoomID) AS RoomCount, AVG(rc.BaseRate) AS AverageRate
FROM dbo.RoomCategory rc
INNER JOIN dbo.Room rm ON rc.CategoryID = rm.CategoryID
GROUP BY rc.CategoryName
HAVING COUNT(rm.RoomID) > 1;

-- 6. Scalar subquery: reservations above average successful payment.
SELECT r.ReservationID, c.FullName, dbo.fn_CalculateReservationAmount(r.ReservationID) AS EstimatedBill
FROM dbo.Reservation r
INNER JOIN dbo.Customer c ON r.CustomerID = c.CustomerID
WHERE dbo.fn_CalculateReservationAmount(r.ReservationID) >
(
    SELECT AVG(Amount)
    FROM dbo.Payment
    WHERE PaymentStatus = 'Success'
);

-- 7. Correlated subquery: customers whose reservation count is above zero.
SELECT c.CustomerID, c.FullName, c.Email
FROM dbo.Customer c
WHERE
(
    SELECT COUNT(*)
    FROM dbo.Reservation r
    WHERE r.CustomerID = c.CustomerID
) > 0;

-- 8. Nested subquery: rooms in the highest priced category.
SELECT RoomNumber, RoomStatus
FROM dbo.Room
WHERE CategoryID =
(
    SELECT CategoryID
    FROM dbo.RoomCategory
    WHERE BaseRate =
    (
        SELECT MAX(BaseRate)
        FROM dbo.RoomCategory
    )
);

-- 9. Table-valued function: available rooms for a date range.
SELECT *
FROM dbo.fn_AvailableRooms('2026-06-01', '2026-06-04', NULL);

-- 10. Revenue by customer using joins and aggregation.
SELECT c.FullName, SUM(CASE WHEN p.PaymentStatus = 'Success' THEN p.Amount ELSE 0 END) AS PaidAmount
FROM dbo.Customer c
INNER JOIN dbo.Reservation r ON c.CustomerID = r.CustomerID
LEFT JOIN dbo.Payment p ON r.ReservationID = p.ReservationID
GROUP BY c.FullName
ORDER BY PaidAmount DESC;

-- 11. Pending balance report.
SELECT
    r.ReservationID,
    c.FullName,
    dbo.fn_CalculateReservationAmount(r.ReservationID) AS BillAmount,
    COALESCE(SUM(CASE WHEN p.PaymentStatus = 'Success' THEN p.Amount END), 0) AS PaidAmount,
    dbo.fn_CalculateReservationAmount(r.ReservationID) - COALESCE(SUM(CASE WHEN p.PaymentStatus = 'Success' THEN p.Amount END), 0) AS BalanceAmount
FROM dbo.Reservation r
INNER JOIN dbo.Customer c ON r.CustomerID = c.CustomerID
LEFT JOIN dbo.Payment p ON r.ReservationID = p.ReservationID
GROUP BY r.ReservationID, c.FullName;

-- 12. Service usage report.
SELECT s.ServiceName, SUM(rs.Quantity) AS TotalQuantity, SUM(rs.Quantity * rs.ChargedPrice) AS ServiceRevenue
FROM dbo.Service s
INNER JOIN dbo.ReservationService rs ON s.ServiceID = rs.ServiceID
GROUP BY s.ServiceName
ORDER BY ServiceRevenue DESC;
GO
