USE mydb;


CREATE TABLE student_records 
(
    id INT PRIMARY KEY,
    name VARCHAR(100),
    subject VARCHAR(50),
    marks INT,
    grade VARCHAR(5)
);

INSERT INTO student_records (id, name, subject, marks, grade) VALUES
(1, 'Aarav Sharma',  'Mathematics',  92, 'A'),
(2, 'Priya Patel',   'Physics',      78, 'B'),
(3, 'Rohan Mehta',   'Chemistry',    55, 'C'),
(4, 'Sneha Rao',     'Biology',      88, 'A'),
(5, 'Vikram Nair',   'English',      43, 'F'),
(6, 'Ananya Joshi',  'Computer Sci', 97, 'A+');



SELECT * FROM student_records;




-- Copying table
-- SELECT INTO - create a new table + fill data from an existing table
SELECT * INTO goodstudents
FROM student_records
WHERE marks >  90;



-- showing new table
SELECT * FROM goodstudents;


SELECT * INTO emptyschemaofstudent_records
FROM student_records
where name = null;

SELECT * FROM emptyschemaofstudent_records;



-- INSERT INTO SELECT - Copy data to existing table

INSERT INTO emptyschemaofstudent_records
SELECT * FROM student_records
WHERE grade <> 'A';

SELECT * FROM emptyschemaofstudent_records;



