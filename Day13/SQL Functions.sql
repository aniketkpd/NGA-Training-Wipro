USE NFSDB;

GO

CREATE TABLE Employees
(
    EmpID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    Salary INT
);

GO

INSERT INTO Employees VALUES (1, 'John', 'Doe', 'IT', 50000);
INSERT INTO Employees VALUES (2, 'Jane', 'Smith', 'HR', 60000);
INSERT INTO Employees VALUES (3, 'Amit', 'Sharma', 'IT', 80000);
INSERT INTO Employees VALUES (4, 'Sara', 'Khan', 'Finance', 75000);


SELECT * FROM Employees;

GO

-- USING SCALAR
CREATE FUNCTION GETFULLNAME 
(
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50)
)

RETURNS VARCHAR(101)

AS
BEGIN
    RETURN @FirstName + ' ' + @LastName
END;

GO



-- CALLING
SELECT 
    EmpID,
    dbo.GETFULLNAME(FirstName, LastName) AS FullName,
    Department,
    Salary
FROM Employees;







GO

-- Using TVF

CREATE  FUNCTION dbo.CalculateBonus(@Salary INT)
RETURNS INT
AS
BEGIN
    RETURN @Salary * 10/100;
END;


GO

-- CALLING

SELECT FirstName, Salary, dbo.CalculateBonus(Salary) AS Bonus
FROM Employees;







