USE NFSDB;


CREATE TABLE Accounts 
(
    AccountId INT PRIMARY KEY,
    Balance INT NOT NULL
);

INSERT INTO Accounts (AccountId, Balance)
VALUES
(1, 5000),
(2, 3000);


-- US-TCL-1: Transfer ₹1000 from Account 1 to Account 2
BEGIN TRANSACTION;

UPDATE Accounts
SET Balance = Balance - 1000
WHERE AccountId = 1;

UPDATE Accounts
SET Balance = Balance + 1000
WHERE AccountId = 2;

COMMIT;

SELECT * FROM Accounts;




-- Reset data for next case
UPDATE Accounts SET Balance = 5000 WHERE AccountId = 1;
UPDATE Accounts SET Balance = 3000 WHERE AccountId = 2;





-- US-TCL-2: Transfer fails, rollback everything
BEGIN TRANSACTION;

UPDATE Accounts
SET Balance = Balance - 1000
WHERE AccountId = 1;

UPDATE Accounts
SET Balance = Balance + 1000
WHERE AccountId = 99;

ROLLBACK;

SELECT * FROM Accounts;



-- Reset data for next case
UPDATE Accounts SET Balance = 5000 WHERE AccountId = 1;
UPDATE Accounts SET Balance = 3000 WHERE AccountId = 2;





-- US-TCL-3: Partial rollback using savepoint
BEGIN TRANSACTION;

UPDATE Accounts
SET Balance = Balance - 500
WHERE AccountId = 1;

SAVE TRANSACTION SavePoint1;

UPDATE Accounts
SET Balance = Balance + 500
WHERE AccountId = 99;

ROLLBACK TRANSACTION SavePoint1;

COMMIT;

SELECT * FROM Accounts;



-- Reset data for next case
UPDATE Accounts SET Balance = 5000 WHERE AccountId = 1;
UPDATE Accounts SET Balance = 3000 WHERE AccountId = 2;





-- US-TCL-4: Deposit ₹2000 into Account 2
BEGIN TRANSACTION;

UPDATE Accounts
SET Balance = Balance + 2000
WHERE AccountId = 2;

COMMIT;

SELECT * FROM Accounts;



-- Reset data for next case
UPDATE Accounts SET Balance = 5000 WHERE AccountId = 1;
UPDATE Accounts SET Balance = 3000 WHERE AccountId = 2;






--US-TCL-5: Multiple operations with selective rollback
BEGIN TRANSACTION;

UPDATE Accounts
SET Balance = Balance - 1000
WHERE AccountId = 1;

SAVE TRANSACTION SavePoint1;

UPDATE Accounts
SET Balance = Balance + 500
WHERE AccountId = 2;

UPDATE Accounts
SET Balance = Balance + 500
WHERE AccountId = 99;

ROLLBACK TRANSACTION SavePoint1;

COMMIT;

SELECT * FROM Accounts;