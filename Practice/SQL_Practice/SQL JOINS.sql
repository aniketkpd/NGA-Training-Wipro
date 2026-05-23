-- STEP 1 — Create Database
CREATE DATABASE JoinPracticeDB;
GO

USE JoinPracticeDB;
GO


-- STEP 2 — Create Tables
CREATE TABLE Students 
(
    StudentID INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT
);

CREATE TABLE Courses 
(
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(50)
);

CREATE TABLE Enrollments 
(
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT
);



-- STEP 3 — Insert Data

-- Students
INSERT INTO Students VALUES
(1, 'Amit', 20),
(2, 'Neha', 22),
(3, 'Rahul', 21),
(4, 'Priya', 23),
(5, 'Karan', 24),
(6, 'Rohit', 25),
(7, 'Anjali', 21),
(8, 'Vikram', 23),
(9, 'Pooja', 20),
(10, 'Arjun', 22);

-- Courses
INSERT INTO Courses VALUES
(101, 'SQL'),
(102, 'Python'),
(103, 'Java'),
(104, 'C#'),
(105, 'JavaScript'),
(106, 'Data Science'),
(107, 'Machine Learning');

-- Enrollments
INSERT INTO Enrollments VALUES
(1, 1, 101),
(2, 1, 102),
(3, 2, 101),
(4, 3, 103),
(5, 6, 101),
(6, 6, 106),
(7, 7, 102),
(8, 7, 107),
(9, 8, 103),
(10, 8, 105),
(11, 1, 106),
(12, 2, 107),

-- edge cases
(13, 999, 101),   -- invalid student
(14, 2, 999);     -- invalid course



SELECT * FROM Students;
SELECT * FROM Courses;
SELECT * FROM Enrollments;



-- INNER JOIN
-- Only matching data from both tables

SELECT S.Name, C.CourseName
FROM Students AS S
INNER JOIN Enrollments AS E 
ON S.StudentID = E.StudentID
INNER JOIN Courses C 
ON E.CourseID = C.CourseID;


SELECT * 
FROM courses AS c
JOIN enrollments AS e
ON c.CourseID = e.CourseID;


SELECT * 
FROM enrollments AS e
JOIN courses AS c
ON c.CourseID = e.CourseID;




SELECT s.Name ,c.CourseName
FROM enrollments AS e
JOIN courses AS c
ON c.CourseID = e.CourseID
JOIN students AS s
ON s.StudentID = e.StudentID;



SELECT *
FROM enrollments AS e
JOIN courses AS c
ON c.CourseID = e.CourseID
JOIN students AS s
ON s.StudentID = e.StudentID;

-- LEFT JOIN
-- All from LEFT table + matching from right
SELECT *
FROM enrollments AS e
LEFT JOIN courses AS c
ON c.CourseID = e.CourseID
LEFT JOIN students AS s
ON s.StudentID = e.StudentID;


-- RIGHT JOIN
-- All from RIGHT table + matching from left
SELECT *
FROM enrollments AS e
RIGHT JOIN courses AS c
ON c.CourseID = e.CourseID
RIGHT JOIN students AS s
ON s.StudentID = e.StudentID;


-- FULL OUTER JOIN
-- Everything from both sides
SELECT *
FROM enrollments AS e
FULL OUTER JOIN courses AS c
ON c.CourseID = e.CourseID
FULL OUTER JOIN students AS s
ON s.StudentID = e.StudentID;


-- CROSS JOIN
-- Every combination (no condition)
SELECT *
FROM enrollments AS e
CROSS JOIN courses AS c;
