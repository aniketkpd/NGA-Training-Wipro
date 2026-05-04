--SQL Case Study: Triggers Scenario
--You are working as a Database Engineer. The organization wants to enforce data integrity, audit tracking, and business rules automatically using Triggers.
--You must design triggers on Employees and Departments tables to handle real-time validations and logging.

--Additional Table Required (Audit Table)
--Audit Table Structure
--CREATE TABLE EmployeeAudit (
--   AuditID INT IDENTITY(1,1) PRIMARY KEY,
--   EmpID INT,
--   ActionType VARCHAR(10),
--   OldSalary INT,
--   NewSalary INT,
--   ActionDate DATETIME DEFAULT GETDATE()
--);









CREATE TABLE Departments (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50),
    Location VARCHAR(50)
);

CREATE TABLE Employees (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(50),
    Salary INT,
    DeptID INT FOREIGN KEY REFERENCES Departments(DeptID)
);

CREATE TABLE EmployeeAudit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    EmpID INT,
    ActionType VARCHAR(10),
    OldSalary INT,
    NewSalary INT,
    ActionDate DATETIME DEFAULT GETDATE()
);





GO


-- T1 — Prevent insertion of employees with salary < 30000
CREATE TRIGGER trg_PreventLowSalaryInsert
ON Employees
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE Salary < 30000)
    BEGIN
        PRINT 'Insert rejected: Salary must be at least 30000.';
        ROLLBACK;
        RETURN;
    END

    INSERT INTO Employees (EmpID, EmpName, Salary, DeptID)
    SELECT EmpID, EmpName, Salary, DeptID FROM inserted;
END;



GO



-- T2 — Log every new employee insertion into audit table
CREATE TRIGGER trg_LogEmployeeInsert
ON Employees
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeAudit (EmpID, ActionType, OldSalary, NewSalary)
    SELECT EmpID, 'INSERT', NULL, Salary
    FROM inserted;
END;

GO


-- T3 — Prevent salary reduction of more than 20%
CREATE TRIGGER trg_PreventSalaryReduction
ON Employees
INSTEAD OF UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN deleted d ON i.EmpID = d.EmpID
        WHERE i.Salary < d.Salary * 0.80
    )
    BEGIN
        PRINT 'Update rejected: Salary cannot be reduced by more than 20%.';
        ROLLBACK;
        RETURN;
    END

    UPDATE e
    SET e.EmpName = i.EmpName,
        e.Salary  = i.Salary,
        e.DeptID  = i.DeptID
    FROM Employees e
    JOIN inserted i ON e.EmpID = i.EmpID;
END;

GO



-- T4 — Log salary changes whenever an employee's salary is updated
CREATE TRIGGER trg_LogSalaryChange
ON Employees
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeAudit (EmpID, ActionType, OldSalary, NewSalary)
        SELECT i.EmpID, 'UPDATE', d.Salary, i.Salary
        FROM inserted i
        JOIN deleted d ON i.EmpID = d.EmpID
        WHERE i.Salary <> d.Salary;
    END
END;


GO


-- T5 — Prevent deletion of employees from the 'IT' department
CREATE TRIGGER trg_PreventITDeletion
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM deleted d
        JOIN Departments dept ON d.DeptID = dept.DeptID
        WHERE dept.DeptName = 'IT'
    )
    BEGIN
        PRINT 'Delete rejected: Employees from IT department cannot be deleted.';
        ROLLBACK;
        RETURN;
    END

    DELETE FROM Employees
    WHERE EmpID IN (SELECT EmpID FROM deleted);
END;

GO



-- T6 — Log deletion of employees in audit table
CREATE TRIGGER trg_LogEmployeeDelete
ON Employees
AFTER DELETE
AS
BEGIN
    INSERT INTO EmployeeAudit (EmpID, ActionType, OldSalary, NewSalary)
    SELECT EmpID, 'DELETE', Salary, NULL
    FROM deleted;
END;



GO

-- T7 — Restrict inserting employees into departments in a restricted location
CREATE TRIGGER trg_RestrictDeptLocationInsert
ON Employees
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Departments d ON i.DeptID = d.DeptID
        WHERE d.Location = 'New York'  -- replace with actual restricted location
    )
    BEGIN
        PRINT 'Insert rejected: Cannot assign employee to a department in restricted location.';
        ROLLBACK;
        RETURN;
    END

    INSERT INTO Employees (EmpID, EmpName, Salary, DeptID)
    SELECT EmpID, EmpName, Salary, DeptID FROM inserted;
END;








-- Insert sample data
-- Insert Departments
INSERT INTO Departments VALUES (1, 'IT', 'New York');
INSERT INTO Departments VALUES (2, 'HR', 'London');
INSERT INTO Departments VALUES (3, 'Finance', 'Mumbai');

-- Insert Employees (valid ones to start with)
INSERT INTO Employees VALUES (101, 'Alice', 50000, 2);
INSERT INTO Employees VALUES (102, 'Bob', 60000, 3);
INSERT INTO Employees VALUES (103, 'Charlie', 75000, 1);  -- IT dept





-- Test each trigger
-- T1 — Should REJECT (salary < 30000)
INSERT INTO Employees VALUES (104, 'David', 20000, 2);
-- Expected: "Insert rejected: Salary must be at least 30000."



-- T1 — Should PASS
INSERT INTO Employees VALUES (104, 'David', 40000, 2);
-- Expected: Row inserted successfully



-- T2 — Check audit log after valid insert
SELECT * FROM EmployeeAudit;
-- Expected: A row with EmpID=104, ActionType='INSERT', OldSalary=NULL, NewSalary=40000



-- T3 — Should REJECT (salary reduced by more than 20%)
-- Bob's current salary is 60000, 20% of 60000 = 12000, so floor is 48000
UPDATE Employees SET Salary = 40000 WHERE EmpID = 102;
-- Expected: "Update rejected: Salary cannot be reduced by more than 20%."



-- T3 — Should PASS (reduction within 20%)
UPDATE Employees SET Salary = 55000 WHERE EmpID = 102;
-- Expected: Salary updated successfully




-- T4 — Check audit log after valid salary update
SELECT * FROM EmployeeAudit;
-- Expected: A row with EmpID=102, ActionType='UPDATE', OldSalary=60000, NewSalary=55000







-- T5 — Should REJECT (Charlie is in IT dept)
DELETE FROM Employees WHERE EmpID = 103;
-- Expected: "Delete rejected: Employees from IT department cannot be deleted."








-- T5 — Should PASS (Bob is in Finance, not IT)
DELETE FROM Employees WHERE EmpID = 102;
-- Expected: Row deleted successfully




-- T6 — Check audit log after valid delete
SELECT * FROM EmployeeAudit;
-- Expected: A row with EmpID=102, ActionType='DELETE', OldSalary=55000, NewSalary=NULL


-- T7 — Should REJECT (IT dept is in New York = restricted location)
INSERT INTO Employees VALUES (105, 'Eve', 45000, 1);
-- Expected: "Insert rejected: Cannot assign employee to a department in restricted location."




-- T7 — Should PASS (HR dept is in London, not restricted)
INSERT INTO Employees VALUES (105, 'Eve', 45000, 2);
-- Expected: Row inserted successfully



-- Final audit table check
SELECT * FROM EmployeeAudit ORDER BY ActionDate;