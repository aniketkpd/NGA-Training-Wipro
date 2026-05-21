# Online Book Store API

This assignment implements a RESTful ASP.NET Core API for books and authors. Testing is done with Swagger UI only, as requested. Postman and Fiddler are not required and are not used.

## Run the API

```powershell
dotnet run
```

Open Swagger UI:

```text
https://localhost:7224/swagger
```

You can also use the HTTP URL from the project settings:

```text
http://localhost:5068/swagger
```

If the port shown in the terminal is different, use that port and add `/swagger`.

## Swagger Testing Checklist

Use the **Try it out** button in Swagger for each endpoint.

| Requirement | Swagger endpoint |
| --- | --- |
| Get all books | `GET /api/books` |
| Get book by ID | `GET /api/books/{id}` |
| Create book | `POST /api/books` |
| Update book | `PUT /api/books/{id}` |
| Delete book | `DELETE /api/books/{id}` |
| Get all authors | `GET /api/authors` |
| Get author by ID | `GET /api/authors/{id}` |
| Create author | `POST /api/authors` |
| Update author | `PUT /api/authors/{id}` |
| Delete author | `DELETE /api/authors/{id}` |
| Get all books by author | `GET /api/authors/{authorId}/books` |

## Example JSON Bodies

Create author:

```json
{
  "name": "Jane Austen",
  "bio": "English novelist."
}
```

Create book:

```json
{
  "title": "Pride and Prejudice",
  "authorId": 3,
  "publicationYear": 1813
}
```

Update book:

```json
{
  "title": "Nineteen Eighty-Four",
  "authorId": 1,
  "publicationYear": 1949
}
```

## Expected Swagger Results

- Successful `GET` requests return `200 OK` with JSON.
- Successful `POST` requests return `201 Created` with the created JSON object.
- Successful `PUT` requests return `200 OK` with the updated JSON object.
- Successful `DELETE` requests return `204 No Content`.
- Invalid body data returns `400 Bad Request`.
- Missing books or authors return `404 Not Found`.
- Responses use `Content-Type: application/json` when a response body is returned.
