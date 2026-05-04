USE mydb;


-- show all tables
SELECT name 
FROM sys.tables;



SELECT * FROM student_records;



SELECT name, marks,
CASE
	WHEN marks > 90 THEN 'Grade A'
	WHEN marks <= 90 AND marks > 80 THEN 'Grade B'
	WHEN marks <= 80 AND marks > 70 THEN 'Grade C'
	WHEN marks <= 70 AND marks > 60 THEN 'Grade D'
	WHEN marks <= 60 AND marks > 50 THEN 'Grade E'
	WHEN marks <= 50 AND marks > 40 THEN 'Grade F'
	ELSE 'Fail'
END AS grades
FROM student_records;












-- Null functions
-- COALESCE()
-- ISNULL() 

CREATE TABLE Products 
(
    PId        INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price      DECIMAL(10, 2),
    InStock    INT,
    InOrder    INT
);

INSERT INTO Products (PId, ProductName, Price, InStock, InOrder) VALUES
(1, 'Jarlsberg',  10.45, 16, 15),
(2, 'Mascarpone', 32.56, 23, NULL),
(3, 'Gorgonzola', 15.67,  9, 20);



SELECT * FROM Products;


-- if any value in calculation has null, whole calculation will lead to a null
SELECT ProductName, Price * (InStock + InOrder)
FROM Products;



-- The COALESCE() function is the preferred standard for handling potential NULL values.
SELECT ProductName, Price * (InStock + COALESCE(InOrder, 0))
FROM Products;



-- 1. ISNULL — replaces NULL with a fallback value
SELECT ProductName, ISNULL(InOrder, 0) AS InOrder FROM Products;


-- 2. COALESCE — returns first non-NULL from a list of values
SELECT ProductName, COALESCE(InOrder, InStock, 0) AS InOrder FROM Products;





-- 3. IS NULL / IS NOT NULL — filter rows
SELECT * FROM Products WHERE InOrder IS NULL;
SELECT * FROM Products WHERE InOrder IS NOT NULL;