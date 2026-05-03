USE NFSDB;

INSERT INTO Employees (EmpID, FirstName, LastName, Department, Salary)
VALUES (11, 'Rohit', 'Verma', 'Finance', 90000);

UPDATE Departments
SET Location = 'Delhi'
WHERE DeptName = 'Finance';

SELECT * FROM Employees;
SELECT * FROM Departments;


-- T1 — Salary > overall average
SELECT FirstName
FROM  Employees
WHERE Salary > (
    SELECT AVG(Salary)
    FROM  Employees
);



-- T2 — Employees in departments located in 'Delhi'
SELECT FirstName
FROM  Employees
WHERE Department IN (
    SELECT DeptName
    FROM  Departments
    WHERE Location = 'Delhi'
);


-- T3 — Salary = max salary
SELECT FirstName
FROM  Employees
WHERE Salary = (
    SELECT MAX(Salary)
    FROM  Employees
);


-- T4 — Salary > department average (correlated)
SELECT FirstName
FROM  Employees E
WHERE Salary > (
    SELECT AVG(Salary)
    FROM  Employees
    WHERE Department = E.Department
);


--  T5 — Highest paid in each department
SELECT FirstName, Department, Salary
FROM  Employees E
WHERE Salary = (
    SELECT MAX(Salary)
    FROM  Employees
    WHERE Department = E.Department
);



-- T6 — Departments where avg salary > company avg
SELECT Department
FROM  Employees
GROUP BY Department
HAVING AVG(Salary) > (
    SELECT AVG(Salary)
    FROM  Employees
);

-- T7 — Rewrite T4 using JOIN
SELECT E.FirstName
FROM  Employees E
JOIN (
    SELECT Department, AVG(Salary) AS AvgSalary
    FROM  Employees
    GROUP BY Department
) D
ON E.Department = D.Department
WHERE E.Salary > D.AvgSalary;


-- T8 — Rewrite T5 using JOIN
SELECT E.FirstName, E.Department, E.Salary
FROM  Employees E
JOIN (
    SELECT Department, MAX(Salary) AS MaxSalary
    FROM  Employees
    GROUP BY Department
) D
ON E.Department = D.Department 
AND E.Salary = D.MaxSalary;





-- T9 — Salary > dept avg AND location = 'Delhi'
SELECT E.FirstName, D.DeptName, E.Salary
FROM  Employees E
JOIN  Departments D
ON E.Department = D.DeptName
JOIN (
    SELECT Department, AVG(Salary) AS AvgSalary
    FROM  Employees
    GROUP BY Department
) A
ON E.Department = A.Department
WHERE E.Salary > A.AvgSalary
AND D.Location = 'Delhi';