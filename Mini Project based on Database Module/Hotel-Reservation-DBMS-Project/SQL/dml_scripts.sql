USE HotelReservationDB;
GO

INSERT INTO dbo.Hotel (HotelName, AddressLine, City, StateName, Phone, Email) VALUES
('Blue Orchid Grand', '14 Marine Drive', 'Mumbai', 'Maharashtra', '9876500001', 'frontdesk@blueorchid.com');

INSERT INTO dbo.RoomCategory (CategoryName, BaseRate, Capacity, Description) VALUES
('Standard', 2500.00, 2, 'Comfortable room for short stays'),
('Deluxe', 4200.00, 3, 'Larger room with city view'),
('Suite', 8000.00, 4, 'Premium suite with living area'),
('Family', 6500.00, 5, 'Family room with extra bedding');

INSERT INTO dbo.Room (HotelID, CategoryID, RoomNumber, FloorNo, RoomStatus) VALUES
(1, 1, '101', 1, 'Available'),
(1, 1, '102', 1, 'Available'),
(1, 2, '201', 2, 'Available'),
(1, 2, '202', 2, 'Available'),
(1, 3, '301', 3, 'Available'),
(1, 4, '401', 4, 'Available'),
(1, 4, '402', 4, 'Maintenance');

INSERT INTO dbo.Customer (FullName, Email, Phone, IdentityProofType, IdentityProofNo) VALUES
('Aarav Mehta', 'aarav.mehta@example.com', '9000000001', 'Aadhaar', 'ADH10001'),
('Isha Sharma', 'isha.sharma@example.com', '9000000002', 'Passport', 'PPT20002'),
('Kabir Rao', 'kabir.rao@example.com', '9000000003', 'Driving License', 'DL30003'),
('Naina Kapoor', 'naina.kapoor@example.com', '9000000004', 'Aadhaar', 'ADH40004'),
('Rohan Das', 'rohan.das@example.com', '9000000005', 'Passport', 'PPT50005');

INSERT INTO dbo.Staff (FullName, RoleName, Email, Phone) VALUES
('Priya Nair', 'Reservation Executive', 'priya.nair@blueorchid.com', '9100000001'),
('Manav Shah', 'Front Office Manager', 'manav.shah@blueorchid.com', '9100000002');

INSERT INTO dbo.PaymentMethod (MethodName) VALUES
('Cash'), ('Credit Card'), ('UPI'), ('Net Banking');

INSERT INTO dbo.Service (ServiceName, UnitPrice, IsActive) VALUES
('Breakfast Buffet', 650.00, 1),
('Airport Pickup', 1500.00, 1),
('Laundry', 450.00, 1),
('Spa Session', 2200.00, 1);

INSERT INTO dbo.Reservation (CustomerID, StaffID, CheckInDate, CheckOutDate, ReservationStatus, TaxRate) VALUES
(1, 1, '2026-06-01', '2026-06-04', 'Booked', 12.00),
(2, 1, '2026-06-03', '2026-06-05', 'Booked', 12.00),
(3, 2, '2026-06-08', '2026-06-12', 'CheckedIn', 12.00),
(4, 2, '2026-06-12', '2026-06-14', 'CheckedOut', 12.00),
(5, 1, '2026-06-20', '2026-06-22', 'Cancelled', 12.00);

INSERT INTO dbo.ReservationRoom (ReservationID, RoomID, AssignedRate) VALUES
(1, 1, 2500.00),
(2, 3, 4200.00),
(3, 5, 8000.00),
(4, 6, 6500.00),
(5, 2, 2500.00);

INSERT INTO dbo.ReservationService (ReservationID, ServiceID, Quantity, ChargedPrice, ServiceDate) VALUES
(1, 1, 3, 650.00, '2026-06-02'),
(1, 3, 1, 450.00, '2026-06-03'),
(2, 2, 1, 1500.00, '2026-06-03'),
(3, 4, 2, 2200.00, '2026-06-09'),
(4, 1, 2, 650.00, '2026-06-13');

INSERT INTO dbo.Payment (ReservationID, PaymentMethodID, Amount, PaymentStatus, ReferenceNo) VALUES
(1, 2, 6000.00, 'Success', 'PAY-1001'),
(2, 3, 3000.00, 'Pending', 'PAY-1002'),
(3, 4, 15000.00, 'Success', 'PAY-1003'),
(4, 1, 16000.00, 'Success', 'PAY-1004');

UPDATE dbo.Room
SET RoomStatus = 'Occupied'
WHERE RoomID = 5;

DELETE FROM dbo.Payment
WHERE ReferenceNo = 'PAY-1002' AND PaymentStatus = 'Pending';
GO
