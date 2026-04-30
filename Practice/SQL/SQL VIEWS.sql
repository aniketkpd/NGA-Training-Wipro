USE mydb;

SELECT * FROM Persons;

GO

CREATE VIEW myview AS 
SELECT FirstName FROM Persons;

GO

SELECT * FROM myview;


GO

ALTER VIEW myview AS 
SELECT FirstName, City FROM Persons;

GO

SELECT * FROM myview;


