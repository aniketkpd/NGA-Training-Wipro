# BookStoreADOApp

ASP.NET Core MVC bookstore assignment using ADO.NET.

## What is included

- CRUD operations for books.
- `SqlConnection`, `SqlCommand`, and `SqlDataReader` for connected data access.
- `SqlDataAdapter`, `DataSet`, and `DataTable` for disconnected data access.
- Stored procedures for add, update, and delete.
- Parameterized commands to help prevent SQL injection.
- Basic validation for title, author, and price.

## Database setup

1. Open SQL Server Management Studio.
2. Connect to `localhost\SQLEXPRESS`.
3. Run `DatabaseSetup.sql`.
4. Confirm that `appsettings.json` points to `BookStoreDB`.

## Run

Open the solution in Visual Studio and run the `BookStoreADOApp` project.
