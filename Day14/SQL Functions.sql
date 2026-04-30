USE NFSDB;

GO


-- creating table
CREATE TABLE Employees
(
    EmpID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    Salary INT
);

GO


-- inserting data
INSERT INTO Employees VALUES (1, 'John', 'Doe', 'IT', 50000);
INSERT INTO Employees VALUES (2, 'Jane', 'Smith', 'HR', 60000);
INSERT INTO Employees VALUES (3, 'Amit', 'Sharma', 'IT', 80000);
INSERT INTO Employees VALUES (4, 'Sara', 'Khan', 'Finance', 75000);

-- showing data
SELECT * FROM Employees;

GO



-- SCALAR function
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

-- Scalar function
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





GO

-- an Inline TVF to return EMP from HR dept
CREATE FUNCTION dbo.GetEmployeebyDept(@Dept VARCHAR(50))
RETURNS TABLE
AS

RETURN
(
    SELECT EmpID,
    FirstName,
    LastName,
    Department,
    Salary
    FROM Employees
    WHERE Department = @dept
);


GO


-- calling above funcion
SELECT * FROM dbo.GetEmployeebyDept('HR');
SELECT * FROM dbo.GetEmployeebyDept('IT');





---------------------------------------------------------------------
GO














----------- Using Scalar function ---------

-- annual salary
CREATE FUNCTION dbo.GetAnnualSalary(@Salary INT)
RETURNS INT
AS
BEGIN
    RETURN @Salary * 12;
END;


GO


-- CALLING
SELECT  dbo.GETFULLNAME(FirstName, LastName) AS FullName, 
        dbo.GetAnnualSalary(Salary) AS AnnualSalary
FROM Employees;





GO

-- getting name based on salary
CREATE FUNCTION dbo.GetNameBySalary
(
    @Salary INT,
    @entervalue INT
)
RETURNS VARCHAR(100)

AS
BEGIN
    IF @Salary > @entervalue
        RETURN 'Eligible';
    
    RETURN 'Not Eligible';
END;


GO



-- CALLING
SELECT dbo.GETFULLNAME(FirstName, LastName) AS FullName,
       Salary,
       dbo.GetNameBySalary(Salary, 60000) AS Status
FROM Employees;




GO



-- Bonus based on department
CREATE FUNCTION dbo.CalculateDeptBonus
(
    @Dept VARCHAR(50),
    @Salary INT
)
RETURNS INT

AS
BEGIN
    RETURN 
        CASE 
            WHEN @Dept = 'IT' THEN @Salary * 15 / 100
            WHEN @Dept = 'HR' THEN @Salary * 12 / 100
            ELSE @Salary * 10 / 100
        END;
END;



GO



-- CALLING
SELECT dbo.GETFULLNAME(FirstName, LastName) AS FullName,
       Department,
       Salary,
       dbo.CalculateDeptBonus(Department, Salary) AS Bonus
FROM Employees;






GO

----------- Using Inline TVF function ---------

-- getting annual salary
CREATE FUNCTION dbo.GetAnnualSalaryTVF()
RETURNS TABLE
AS
RETURN
(
    SELECT dbo.GETFULLNAME(FirstName, LastName) AS FullName,
           Salary,
           Salary * 12 AS AnnualSalary
    FROM Employees
);



GO


-- calling
SELECT * FROM dbo.GetAnnualSalaryTVF();




GO




-- getting name based on salary
CREATE FUNCTION dbo.GetEmployeesBySalary
(
    @entervalue INT
)
RETURNS TABLE

AS
RETURN
(
    SELECT dbo.GETFULLNAME(FirstName, LastName) AS FullName , LastName, Salary
    FROM Employees
    WHERE Salary > @entervalue
);








GO

-- calling
SELECT * FROM dbo.GetEmployeesBySalary(60000);



GO



-- getting bonus based on department
CREATE FUNCTION dbo.GetBonusByDept()
RETURNS TABLE
AS
RETURN
(
    SELECT 
        dbo.GETFULLNAME(FirstName, LastName) AS FullName,
        Department,
        Salary,
        CASE
            WHEN Department = 'IT' THEN Salary * 15 / 100
            WHEN Department = 'HR' THEN Salary * 12 / 100
            ELSE Salary * 10 / 100
        END AS Bonus
    FROM Employees
);




GO

-- calling

SELECT * FROM dbo.GetBonusByDept();