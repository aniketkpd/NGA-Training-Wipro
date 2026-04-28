-- creating db
CREATE DATABASE mydb;

--using db
USE mydb;

--creating table
CREATE TABLE Persons 
(
  PersonID int PRIMARY KEY,
  LastName varchar(255) NOT NULL,
  FirstName varchar(255),
  Address varchar(255),
  City varchar(255)
);

-- Inserting data in table
INSERT INTO Persons
VALUES 
(1,'ln1', 'fn1', 'address1','city1'),
(2,'ln2', 'fn2', 'address2','city2'),
(3,'ln3', 'fn3 ', 'address3','city3'),
(4,'ln4', 'fn4', 'address4','city4');

--showing data
SELECT *
FROM Persons;




