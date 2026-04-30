USE mydb;

SELECT * FROM Persons;

GO

CREATE PROCEDURE myprocedure
	@City varchar(255)
AS
BEGIN
	SELECT * FROM Persons
	WHERE City = @City;
END;


Go

EXEC myprocedure @City = 'city1';