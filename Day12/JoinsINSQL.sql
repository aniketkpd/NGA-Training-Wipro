use NFSDB;

--  creating a table customer with columns ID, Name, Age, City
--  Rule 1: Always include a primary key in your table design to ensure data integrity and efficient querying.
--  Rule 2: Use appropriate data types for each column to optimize storage and performance. 
--  For example, use VARCHAR for text data and INT for numeric data.float or DECIMAL for decimal numbers.
--  Date type for date values,Binary for binary data, and so on.
--  Rule 3: Consider adding  constraints(mandatory) such as NOT NULL, UNIQUE, or CHECK to enforce data integrity and business rules.
--  Rule 4: Avoid using reserved keywords as column names to prevent potential conflicts and improve readability.
--  Rule 5: Use meaningful and descriptive column names to enhance readability and maintainability of the database schema.

CREATE TABLE Customers
(
    Id INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    City VARCHAR(50)
);


INSERT INTO Customers (Id, Name, Age, City) VALUES (1, 'John Doe', 30, 'New York');
INSERT INTO Customers (Id, Name, Age, City) VALUES (2, 'Jane Smith', 25, 'Los Angeles');
INSERT INTO Customers (Id, Name, Age, City) VALUES (3, 'Alice Johnson', 28, 'Chicago');
INSERT INTO Customers (Id, Name, Age, City) VALUES (4, 'Bob Brown', 35, 'Houston');
INSERT INTO Customers (Id, Name, Age, City) VALUES (5, 'Charlie Davis', 32, 'Phoenix');
INSERT INTO Customers (Id, Name, Age, City) VALUES (6, 'David Wilson', 40, 'San Francisco');



-- for implementing join we should have two tables with some common column
CREATE TABLE Orders
(
    OrderId INT PRIMARY KEY,
    CustomerId INT,
    OrderDate DATE,
    Amount DECIMAL(10, 2),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);

INSERT INTO Orders (OrderId, CustomerId, OrderDate, Amount) VALUES (1, 1, '2024-01-01', 100.00);
INSERT INTO Orders (OrderId, CustomerId, OrderDate, Amount) VALUES (2, 2, '2024-01-02', 150.00);
INSERT INTO Orders (OrderId, CustomerId, OrderDate, Amount) VALUES (3, 3, '2024-01-03', 200.00);
INSERT INTO Orders (OrderId, CustomerId, OrderDate, Amount) VALUES (4, 1, '2024-01-04', 250.00);
INSERT INTO Orders (OrderId, CustomerId, OrderDate, Amount) VALUES (5, 2, '2024-01-05', 300.00);






-- INNER JOIN (only matching records)
SELECT 
    c.Name AS CustomerName,
    o.OrderId,
    o.OrderDate,
    o.Amount
FROM Customers c
INNER JOIN Orders o 
ON c.Id = o.CustomerId;




-- LEFT JOIN (all customers + matching orders)

SELECT 
    c.Name AS CustomerName,
    o.OrderId,
    o.OrderDate,
    o.Amount
FROM Customers c
LEFT JOIN Orders o 
ON c.Id = o.CustomerId;


-- RIGHT JOIN (all orders + matching customers)

SELECT 
    c.Name AS CustomerName,
    o.OrderId,
    o.OrderDate,
    o.Amount
FROM Orders o
RIGHT JOIN Customers c 
ON o.CustomerId = c.Id;

--FULL OUTER JOIN (everything from both tables)

SELECT 
    c.Name AS CustomerName,
    o.OrderId,
    o.OrderDate,
    o.Amount
FROM Customers c
FULL OUTER JOIN Orders o 
ON c.Id = o.CustomerId;


-- CROSS JOIN (all combinations)

SELECT 
    c.Name AS CustomerName,
    o.OrderId
FROM Customers c
CROSS JOIN Orders o;

--SELF JOIN (example: same city customers)

SELECT 
    c1.Name AS Customer1,
    c2.Name AS Customer2,
    c1.City
FROM Customers c1
JOIN Customers c2 
ON c1.City = c2.City AND c1.Id <> c2.Id;