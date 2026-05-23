USE mydb;

SELECT * FROM Persons;

CREATE INDEX myindex
ON Persons(City);

CREATE UNIQUE INDEX myindex2
ON Persons(City);

SELECT City FROM Persons;

DROP INDEX Persons.myindex;

DROP INDEX Persons.myindex2;


SELECT City FROM Persons;

