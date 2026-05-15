-- Create the database if it doesn't exist
IF DB_ID('HotelReservationDB') IS NULL
    CREATE DATABASE HotelReservationDB;
GO

-- Connect to the database
USE HotelReservationDB;
GO

-- Drop existing tables if they exist
IF OBJECT_ID('dbo.Payment', 'U') IS NOT NULL DROP TABLE dbo.Payment;
IF OBJECT_ID('dbo.ReservationService', 'U') IS NOT NULL DROP TABLE dbo.ReservationService;
IF OBJECT_ID('dbo.ReservationRoom', 'U') IS NOT NULL DROP TABLE dbo.ReservationRoom;
IF OBJECT_ID('dbo.AuditLog', 'U') IS NOT NULL DROP TABLE dbo.AuditLog;
IF OBJECT_ID('dbo.Reservation', 'U') IS NOT NULL DROP TABLE dbo.Reservation;
IF OBJECT_ID('dbo.PaymentMethod', 'U') IS NOT NULL DROP TABLE dbo.PaymentMethod;
IF OBJECT_ID('dbo.Service', 'U') IS NOT NULL DROP TABLE dbo.Service;
IF OBJECT_ID('dbo.Room', 'U') IS NOT NULL DROP TABLE dbo.Room;
IF OBJECT_ID('dbo.RoomCategory', 'U') IS NOT NULL DROP TABLE dbo.RoomCategory;
IF OBJECT_ID('dbo.Staff', 'U') IS NOT NULL DROP TABLE dbo.Staff;
IF OBJECT_ID('dbo.Customer', 'U') IS NOT NULL DROP TABLE dbo.Customer;
IF OBJECT_ID('dbo.Hotel', 'U') IS NOT NULL DROP TABLE dbo.Hotel;
GO


-- Hotel table to store hotel details
CREATE TABLE dbo.Hotel (
    HotelID INT IDENTITY(1,1) CONSTRAINT PK_Hotel PRIMARY KEY,
    HotelName VARCHAR(100) NOT NULL,
    AddressLine VARCHAR(200) NOT NULL,
    City VARCHAR(80) NOT NULL,
    StateName VARCHAR(80) NOT NULL,
    Phone VARCHAR(15) NOT NULL CONSTRAINT UQ_Hotel_Phone UNIQUE,
    Email VARCHAR(120) NOT NULL CONSTRAINT UQ_Hotel_Email UNIQUE
);



-- RoomCategory table to store room category details
CREATE TABLE dbo.RoomCategory (
    CategoryID INT IDENTITY(1,1) CONSTRAINT PK_RoomCategory PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL CONSTRAINT UQ_RoomCategory_Name UNIQUE,
    BaseRate DECIMAL(10,2) NOT NULL CONSTRAINT CK_RoomCategory_BaseRate CHECK (BaseRate > 0),
    Capacity INT NOT NULL CONSTRAINT CK_RoomCategory_Capacity CHECK (Capacity BETWEEN 1 AND 6),
    Description VARCHAR(200) NULL
);




-- Room table to store room details
CREATE TABLE dbo.Room (
    RoomID INT IDENTITY(1,1) CONSTRAINT PK_Room PRIMARY KEY,
    HotelID INT NOT NULL,
    CategoryID INT NOT NULL,
    RoomNumber VARCHAR(10) NOT NULL,
    FloorNo INT NOT NULL CONSTRAINT CK_Room_Floor CHECK (FloorNo BETWEEN 1 AND 50),
    RoomStatus VARCHAR(20) NOT NULL CONSTRAINT DF_Room_Status DEFAULT ('Available'),
    CONSTRAINT UQ_Room_Hotel_RoomNumber UNIQUE (HotelID, RoomNumber),
    CONSTRAINT CK_Room_Status CHECK (RoomStatus IN ('Available', 'Occupied', 'Maintenance', 'Inactive')),
    CONSTRAINT FK_Room_Hotel FOREIGN KEY (HotelID) REFERENCES dbo.Hotel(HotelID),
    CONSTRAINT FK_Room_Category FOREIGN KEY (CategoryID) REFERENCES dbo.RoomCategory(CategoryID)
);




-- Customer table to store customer details
CREATE TABLE dbo.Customer (
    CustomerID INT IDENTITY(1,1) CONSTRAINT PK_Customer PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(120) NOT NULL CONSTRAINT UQ_Customer_Email UNIQUE,
    Phone VARCHAR(15) NOT NULL CONSTRAINT UQ_Customer_Phone UNIQUE,
    IdentityProofType VARCHAR(30) NOT NULL,
    IdentityProofNo VARCHAR(50) NOT NULL CONSTRAINT UQ_Customer_Identity UNIQUE,
    CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Customer_CreatedAt DEFAULT (SYSDATETIME())
);



CREATE TABLE dbo.Staff (
    StaffID INT IDENTITY(1,1) CONSTRAINT PK_Staff PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    RoleName VARCHAR(50) NOT NULL,
    Email VARCHAR(120) NOT NULL CONSTRAINT UQ_Staff_Email UNIQUE,
    Phone VARCHAR(15) NOT NULL CONSTRAINT UQ_Staff_Phone UNIQUE,
    IsActive BIT NOT NULL CONSTRAINT DF_Staff_IsActive DEFAULT (1)
);

CREATE TABLE dbo.Reservation (
    ReservationID INT IDENTITY(1,1) CONSTRAINT PK_Reservation PRIMARY KEY,
    CustomerID INT NOT NULL,
    StaffID INT NOT NULL,
    BookingDate DATETIME2 NOT NULL CONSTRAINT DF_Reservation_BookingDate DEFAULT (SYSDATETIME()),
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    ReservationStatus VARCHAR(20) NOT NULL CONSTRAINT DF_Reservation_Status DEFAULT ('Booked'),
    TaxRate DECIMAL(5,2) NOT NULL CONSTRAINT DF_Reservation_TaxRate DEFAULT (12.00),
    CONSTRAINT CK_Reservation_Date CHECK (CheckOutDate > CheckInDate),
    CONSTRAINT CK_Reservation_Status CHECK (ReservationStatus IN ('Booked', 'CheckedIn', 'CheckedOut', 'Cancelled', 'NoShow')),
    CONSTRAINT CK_Reservation_Tax CHECK (TaxRate BETWEEN 0 AND 28),
    CONSTRAINT FK_Reservation_Customer FOREIGN KEY (CustomerID) REFERENCES dbo.Customer(CustomerID),
    CONSTRAINT FK_Reservation_Staff FOREIGN KEY (StaffID) REFERENCES dbo.Staff(StaffID)
);

CREATE TABLE dbo.ReservationRoom (
    ReservationRoomID INT IDENTITY(1,1) CONSTRAINT PK_ReservationRoom PRIMARY KEY,
    ReservationID INT NOT NULL,
    RoomID INT NOT NULL,
    AssignedRate DECIMAL(10,2) NOT NULL CONSTRAINT CK_ReservationRoom_Rate CHECK (AssignedRate > 0),
    CONSTRAINT UQ_ReservationRoom UNIQUE (ReservationID, RoomID),
    CONSTRAINT FK_ReservationRoom_Reservation FOREIGN KEY (ReservationID) REFERENCES dbo.Reservation(ReservationID),
    CONSTRAINT FK_ReservationRoom_Room FOREIGN KEY (RoomID) REFERENCES dbo.Room(RoomID)
);

CREATE TABLE dbo.Service (
    ServiceID INT IDENTITY(1,1) CONSTRAINT PK_Service PRIMARY KEY,
    ServiceName VARCHAR(80) NOT NULL CONSTRAINT UQ_Service_Name UNIQUE,
    UnitPrice DECIMAL(10,2) NOT NULL CONSTRAINT CK_Service_Price CHECK (UnitPrice >= 0),
    IsActive BIT NOT NULL CONSTRAINT DF_Service_IsActive DEFAULT (1)
);

CREATE TABLE dbo.ReservationService (
    ReservationServiceID INT IDENTITY(1,1) CONSTRAINT PK_ReservationService PRIMARY KEY,
    ReservationID INT NOT NULL,
    ServiceID INT NOT NULL,
    Quantity INT NOT NULL CONSTRAINT CK_ReservationService_Quantity CHECK (Quantity > 0),
    ChargedPrice DECIMAL(10,2) NOT NULL CONSTRAINT CK_ReservationService_ChargedPrice CHECK (ChargedPrice >= 0),
    ServiceDate DATE NOT NULL,
    CONSTRAINT FK_ReservationService_Reservation FOREIGN KEY (ReservationID) REFERENCES dbo.Reservation(ReservationID),
    CONSTRAINT FK_ReservationService_Service FOREIGN KEY (ServiceID) REFERENCES dbo.Service(ServiceID)
);

CREATE TABLE dbo.PaymentMethod (
    PaymentMethodID INT IDENTITY(1,1) CONSTRAINT PK_PaymentMethod PRIMARY KEY,
    MethodName VARCHAR(40) NOT NULL CONSTRAINT UQ_PaymentMethod_Name UNIQUE
);

CREATE TABLE dbo.Payment (
    PaymentID INT IDENTITY(1,1) CONSTRAINT PK_Payment PRIMARY KEY,
    ReservationID INT NOT NULL,
    PaymentMethodID INT NOT NULL,
    PaymentDate DATETIME2 NOT NULL CONSTRAINT DF_Payment_Date DEFAULT (SYSDATETIME()),
    Amount DECIMAL(10,2) NOT NULL CONSTRAINT CK_Payment_Amount CHECK (Amount > 0),
    PaymentStatus VARCHAR(20) NOT NULL CONSTRAINT DF_Payment_Status DEFAULT ('Success'),
    ReferenceNo VARCHAR(50) NOT NULL CONSTRAINT UQ_Payment_Reference UNIQUE,
    CONSTRAINT CK_Payment_Status CHECK (PaymentStatus IN ('Success', 'Pending', 'Failed', 'Refunded')),
    CONSTRAINT FK_Payment_Reservation FOREIGN KEY (ReservationID) REFERENCES dbo.Reservation(ReservationID),
    CONSTRAINT FK_Payment_Method FOREIGN KEY (PaymentMethodID) REFERENCES dbo.PaymentMethod(PaymentMethodID)
);

CREATE TABLE dbo.AuditLog (
    AuditLogID BIGINT IDENTITY(1,1) CONSTRAINT PK_AuditLog PRIMARY KEY,
    TableName VARCHAR(80) NOT NULL,
    ActionType VARCHAR(20) NOT NULL,
    RecordID INT NULL,
    ActionDate DATETIME2 NOT NULL CONSTRAINT DF_AuditLog_ActionDate DEFAULT (SYSDATETIME()),
    ActionBy SYSNAME NOT NULL CONSTRAINT DF_AuditLog_ActionBy DEFAULT (SUSER_SNAME()),
    Description VARCHAR(400) NULL
);

ALTER TABLE dbo.Customer
ADD CONSTRAINT CK_Customer_Email CHECK (Email LIKE '%_@_%._%');
GO
