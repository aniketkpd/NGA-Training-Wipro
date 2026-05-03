use NFSDB;


GO


 CREATE TABLE Departments 
(
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(50),
    Location VARCHAR(50)
);

GO

INSERT INTO Departments
VALUES
(1, 'IT', 'Delhi'),
(2, 'HR', 'Mumbai'),
(3, 'Finance', 'Delhi');

GO


SELECT * FROm Departments;
SELECT * FROm Employees;


GO




-- basic Sub Query based on above tables 
-- Show employees who are earning more than average salary 




SELECT FirstName, Salary FROM dbo.Employees
WHERE Salary > (SELECT AVG(Salary) FROM dbo.Employees);

GO

-- Subquery with In operator
-- Employees who are from Delhi 



SELECT FIRSTName, Department FROM dbo.Employees
WHERE Department IN (SELECT DeptName FROM dbo.Departments WHERE Location = 'Delhi');

GO


-- Correlated Sub Query
-- Show employees whose salary is greater than the average salary of their department

SELECT FirstName, Salary, Department FROM dbo.Employees E
WHERE Salary >
(SELECT AVG(Salary)
 FROM dbo.Employees
 WHERE Department = E.Department);


GO



 -- above query can be implemented using joins also

SELECT E.FirstName, E.Salary, E.Department FROM dbo.Employees E
JOIN dbo.Departments D ON E.Department = D.DeptName
WHERE E.Salary >
(SELECT AVG(Salary) FROM dbo.Employees
 WHERE Department = E.Department);



 GO






 CREATE TRIGGER trg_UpdateDepartmentLocation
ON Employees
AFTER INSERT
AS
BEGIN
    UPDATE D
    SET D.Location = 'Updated Location'
    FROM Departments D
    JOIN inserted I ON D.DeptName = I.Department
END;







GO





--2) Insert a new employee to test the trigger
INSERT INTO dbo.Employees (EmpID, FirstName, LastName, Department, Salary)
VALUES (10, 'John', 'Snow', 'IT', 50000);