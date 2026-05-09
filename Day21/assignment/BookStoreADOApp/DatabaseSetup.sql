IF DB_ID('BookStoreDB') IS NULL
BEGIN
    CREATE DATABASE BookStoreDB;
END
GO

USE BookStoreDB;
GO

IF OBJECT_ID('dbo.Books', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Books
    (
        Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Books PRIMARY KEY,
        Title NVARCHAR(100) NOT NULL,
        AuthorName NVARCHAR(100) NOT NULL,
        Price DECIMAL(10,2) NOT NULL
    );
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_AddBook
    @Title NVARCHAR(100),
    @AuthorName NVARCHAR(100),
    @Price DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.Books (Title, AuthorName, Price)
    VALUES (@Title, @AuthorName, @Price);
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_UpdateBook
    @Id INT,
    @Title NVARCHAR(100),
    @AuthorName NVARCHAR(100),
    @Price DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Books
    SET Title = @Title,
        AuthorName = @AuthorName,
        Price = @Price
    WHERE Id = @Id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_DeleteBook
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Books
    WHERE Id = @Id;
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Books)
BEGIN
    INSERT INTO dbo.Books (Title, AuthorName, Price)
    VALUES
        ('Clean Code', 'Robert C. Martin', 499.00),
        ('The Pragmatic Programmer', 'Andrew Hunt', 599.00),
        ('C# in Depth', 'Jon Skeet', 699.00);
END
GO
