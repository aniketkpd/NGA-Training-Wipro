-- Case Study: Indexing Strategy in FinTech (Banking Platform)
-- Scenario
-- You are working as a Database Performance Engineer in a FinTech company handling:
-- 	• High-frequency transactions
-- 	• Fraud detection queries
-- 	• Real-time reporting dashboards
-- The system suffers from:
-- 	• Slow transaction lookups
-- 	• Delayed fraud detection
-- 	• Heavy reporting latency
-- You must design optimal indexing strategies based on query patterns.
-- Core Tables (Context)
-- 	• Transactions (TxnID, AccountID, Amount, TxnDate, Status, MerchantID)
-- 	• Accounts (AccountID, CustomerID, AccountType, Balance)
-- 	• Customers (CustomerID, Name, City, RiskScore)
-- FraudLogs (LogID, TxnID, RiskFlag, CreatedDate)



CREATE DATABASE dbforindex;
USE dbforindex;

-- Create Core Tables
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    City VARCHAR(50),
    RiskScore INT
);

CREATE TABLE Accounts (
    AccountID INT PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    AccountType VARCHAR(20),
    Balance DECIMAL(15,2)
);

CREATE TABLE Transactions (
    TxnID INT PRIMARY KEY,
    AccountID INT FOREIGN KEY REFERENCES Accounts(AccountID),
    Amount DECIMAL(15,2),
    TxnDate DATETIME,
    Status VARCHAR(20),
    MerchantID INT
);

CREATE TABLE FraudLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    TxnID INT FOREIGN KEY REFERENCES Transactions(TxnID),
    RiskFlag VARCHAR(10),
    CreatedDate DATETIME DEFAULT GETDATE()
);













-- Step 2 — Index Designs by Problem Area





-- Problem 1 — Slow Transaction Lookups

-- Lookup all transactions for an account
SELECT * FROM Transactions WHERE AccountID = 1001;

-- Lookup by date range
SELECT * FROM Transactions WHERE TxnDate BETWEEN '2024-01-01' AND '2024-03-31';

-- Lookup by status
SELECT * FROM Transactions WHERE Status = 'Failed';









-- Most common lookup: by AccountID
CREATE NONCLUSTERED INDEX idx_Txn_AccountID
ON Transactions(AccountID);

-- Date range queries for reporting
CREATE NONCLUSTERED INDEX idx_Txn_TxnDate
ON Transactions(TxnDate);

-- Filter by status (Failed, Pending, Success)
CREATE NONCLUSTERED INDEX idx_Txn_Status
ON Transactions(Status);

-- Composite: AccountID + TxnDate together (very common in banking)
CREATE NONCLUSTERED INDEX idx_Txn_Account_Date
ON Transactions(AccountID, TxnDate DESC);











-- Problem 2 — Delayed Fraud Detection

-- Find all flagged transactions
SELECT * FROM FraudLogs WHERE RiskFlag = 'High';

-- Join fraud logs with transactions for investigation
SELECT t.TxnID, t.Amount, t.TxnDate, f.RiskFlag
FROM Transactions t
JOIN FraudLogs f ON t.TxnID = f.TxnID
WHERE f.RiskFlag = 'High'
AND t.TxnDate >= DATEADD(DAY, -1, GETDATE());

-- Find high risk customers
SELECT c.CustomerID, c.Name, c.RiskScore
FROM Customers c
WHERE c.RiskScore > 80;









-- FraudLogs: filter by RiskFlag quickly
CREATE NONCLUSTERED INDEX idx_Fraud_RiskFlag
ON FraudLogs(RiskFlag);

-- FraudLogs: join with Transactions on TxnID
CREATE NONCLUSTERED INDEX idx_Fraud_TxnID
ON FraudLogs(TxnID);

-- FraudLogs: recent fraud detection (by date)
CREATE NONCLUSTERED INDEX idx_Fraud_CreatedDate
ON FraudLogs(CreatedDate DESC);

-- Composite: RiskFlag + CreatedDate for real-time fraud dashboard
CREATE NONCLUSTERED INDEX idx_Fraud_Flag_Date
ON FraudLogs(RiskFlag, CreatedDate DESC);

-- Customers: filter high risk scores fast
CREATE NONCLUSTERED INDEX idx_Customer_RiskScore
ON Customers(RiskScore DESC);











-- Problem 3 — Heavy Reporting Latency

-- Total transactions per merchant
SELECT MerchantID, COUNT(*), SUM(Amount)
FROM Transactions
GROUP BY MerchantID;

-- Account balance report by type
SELECT AccountType, AVG(Balance), COUNT(*)
FROM Accounts
GROUP BY AccountType;

-- City-wise customer risk report
SELECT City, AVG(RiskScore), COUNT(*)
FROM Customers
GROUP BY City;





-- Transactions: MerchantID for merchant-level reports
CREATE NONCLUSTERED INDEX idx_Txn_MerchantID
ON Transactions(MerchantID)
INCLUDE (Amount, Status);          -- INCLUDE avoids extra lookup

-- Accounts: AccountType for type-wise reports
CREATE NONCLUSTERED INDEX idx_Acc_AccountType
ON Accounts(AccountType)
INCLUDE (Balance);

-- Customers: City for geo reports
CREATE NONCLUSTERED INDEX idx_Customer_City
ON Customers(City)
INCLUDE (RiskScore);

-- Covering index for full transaction report query
CREATE NONCLUSTERED INDEX idx_Txn_Covering
ON Transactions(AccountID, TxnDate DESC)
INCLUDE (Amount, Status, MerchantID);















-- Step 3 — Sample Data to Test
-- Customers
INSERT INTO Customers VALUES (1, 'Alice', 'Mumbai', 45);
INSERT INTO Customers VALUES (2, 'Bob', 'Delhi', 85);
INSERT INTO Customers VALUES (3, 'Charlie', 'Mumbai', 92);
INSERT INTO Customers VALUES (4, 'Diana', 'Chennai', 30);

-- Accounts
INSERT INTO Accounts VALUES (101, 1, 'Savings', 50000.00);
INSERT INTO Accounts VALUES (102, 2, 'Current', 120000.00);
INSERT INTO Accounts VALUES (103, 3, 'Savings', 75000.00);
INSERT INTO Accounts VALUES (104, 4, 'Current', 30000.00);

-- Transactions
INSERT INTO Transactions VALUES (1001, 101, 5000.00, '2024-01-15', 'Success', 501);
INSERT INTO Transactions VALUES (1002, 102, 15000.00, '2024-01-16', 'Failed', 502);
INSERT INTO Transactions VALUES (1003, 103, 8000.00, '2024-01-17', 'Success', 501);
INSERT INTO Transactions VALUES (1004, 101, 2000.00, '2024-01-18', 'Pending', 503);
INSERT INTO Transactions VALUES (1005, 102, 50000.00, '2024-01-18', 'Success', 502);

-- FraudLogs
INSERT INTO FraudLogs VALUES (1001, 'High', GETDATE());
INSERT INTO FraudLogs VALUES (1002, 'Low', GETDATE());
INSERT INTO FraudLogs VALUES (1005, 'High', GETDATE());

-- Step 4 — Test Queries (verify indexes are helping)
-- T1: Transaction lookup by account (uses idx_Txn_AccountID)
SELECT * FROM Transactions WHERE AccountID = 101;

-- T2: Date range lookup (uses idx_Txn_TxnDate)
SELECT * FROM Transactions
WHERE TxnDate BETWEEN '2024-01-15' AND '2024-01-18';

-- T3: Failed transactions (uses idx_Txn_Status)
SELECT * FROM Transactions WHERE Status = 'Failed';

-- T4: Real-time fraud detection (uses idx_Fraud_Flag_Date)
SELECT t.TxnID, t.Amount, f.RiskFlag
FROM Transactions t
JOIN FraudLogs f ON t.TxnID = f.TxnID
WHERE f.RiskFlag = 'High'
AND f.CreatedDate >= DATEADD(DAY, -1, GETDATE());

-- T5: High risk customers (uses idx_Customer_RiskScore)
SELECT * FROM Customers WHERE RiskScore > 80;

-- T6: Merchant report (uses idx_Txn_MerchantID)
SELECT MerchantID, COUNT(*) AS TxnCount, SUM(Amount) AS TotalAmount
FROM Transactions
GROUP BY MerchantID;

-- T7: City-wise risk report (uses idx_Customer_City)
SELECT City, AVG(RiskScore) AS AvgRisk, COUNT(*) AS CustomerCount
FROM Customers
GROUP BY City;

-- Step 5 — Check Index Usage with Execution Plan
-- Turn on execution plan and run any query
SET STATISTICS IO ON;
SET STATISTICS TIME ON;

SELECT * FROM Transactions WHERE AccountID = 101;

-- Look for "Index Seek" (good) vs "Table Scan" (bad) in the output