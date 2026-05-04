Use NFSDB;
CREATE TABLE NewEmployees (
    EmpID INT PRIMARY KEY,
    Name VARCHAR(50),
    Salary INT,
    DeptID INT
);



--Inserting values into NewEmployees table
INSERT INTO NewEmployees (EmpID, Name, Salary, DeptID)
    VALUES (1, 'John Doe', 60000, 101),
           (2, 'Jane Smith', 65000, 102),
           (3, 'Emily Davis', 70000, 101),
           (4, 'Michael Brown', 55000, 103),
           (5, 'Sarah Wilson', 62000, 102);


--Querying above table for all employees with salary greater than 60000 (without indexing on Salary column)
SELECT * FROM NewEmployees
WHERE Salary > 60000;




--creating an index on Salary column to optimize the query performance
CREATE INDEX idx_salary ON NewEmployees(Salary);



--Running the same Query again to see the performance improvement after indexing
SELECT * FROM NewEmployees
WHERE Salary > 60000;



--Viewing index usage statistics to confirm that the index is being utilized

EXECUTE sp_helpindex 'NewEmployees';




--Dropping the index after use to free up resources
DROP INDEX idx_salary ON NewEmployees; 






-- Rebuilding an index:
ALTER INDEX idx_salary ON NewEmployees REBUILD;

-- Reorganizing an index:
ALTER INDEX idx_salary ON NewEmployees REORGANIZE;

SET STATISTICS TIME ON;



SET STATISTICS IO ON ;
SET STATISTICS PROFILE ON ;








