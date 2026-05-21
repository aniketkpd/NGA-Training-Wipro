using OnlineBookStoreApi.Dtos;
using OnlineBookStoreApi.Models;

namespace OnlineBookStoreApi.Data;

public sealed class BookStoreRepository
{
    private readonly object _syncRoot = new();
    private readonly List<Author> _authors = [];
    private readonly List<Book> _books = [];
    private int _nextAuthorId = 1;
    private int _nextBookId = 1;

    public BookStoreRepository()
    {
        var orwell = AddAuthor(new CreateAuthorRequest
        {
            Name = "George Orwell",
            Bio = "English novelist and essayist."
        });

        var lee = AddAuthor(new CreateAuthorRequest
        {
            Name = "Harper Lee",
            Bio = "American novelist."
        });

        AddBook(new CreateBookRequest
        {
            Title = "1984",
            AuthorId = orwell.Id,
            PublicationYear = 1949
        });

        AddBook(new CreateBookRequest
        {
            Title = "To Kill a Mockingbird",
            AuthorId = lee.Id,
            PublicationYear = 1960
        });
    }

    public IReadOnlyList<Book> GetBooks()
    {
        lock (_syncRoot)
        {
            return _books.Select(CloneBook).ToList();
        }
    }

    public Book? GetBook(int id)
    {
        lock (_syncRoot)
        {
            var book = _books.FirstOrDefault(book => book.Id == id);
            return book is null ? null : CloneBook(book);
        }
    }

    public Book? AddBook(CreateBookRequest request)
    {
        lock (_syncRoot)
        {
            var author = _authors.FirstOrDefault(author => author.Id == request.AuthorId);
            if (author is null)
            {
                return null;
            }

            var book = new Book
            {
                Id = _nextBookId++,
                Title = request.Title.Trim(),
                AuthorId = author.Id,
                AuthorName = author.Name,
                PublicationYear = request.PublicationYear
            };

            _books.Add(book);
            return CloneBook(book);
        }
    }

    public Book? UpdateBook(int id, UpdateBookRequest request)
    {
        lock (_syncRoot)
        {
            var book = _books.FirstOrDefault(book => book.Id == id);
            var author = _authors.FirstOrDefault(author => author.Id == request.AuthorId);

            if (book is null || author is null)
            {
                return null;
            }

            book.Title = request.Title.Trim();
            book.AuthorId = author.Id;
            book.AuthorName = author.Name;
            book.PublicationYear = request.PublicationYear;

            return CloneBook(book);
        }
    }

    public bool DeleteBook(int id)
    {
        lock (_syncRoot)
        {
            var book = _books.FirstOrDefault(book => book.Id == id);
            return book is not null && _books.Remove(book);
        }
    }

    public IReadOnlyList<Author> GetAuthors()
    {
        lock (_syncRoot)
        {
            return _authors.Select(CloneAuthor).ToList();
        }
    }

    public Author? GetAuthor(int id)
    {
        lock (_syncRoot)
        {
            var author = _authors.FirstOrDefault(author => author.Id == id);
            return author is null ? null : CloneAuthor(author);
        }
    }

    public Author AddAuthor(CreateAuthorRequest request)
    {
        lock (_syncRoot)
        {
            var author = new Author
            {
                Id = _nextAuthorId++,
                Name = request.Name.Trim(),
                Bio = request.Bio?.Trim()
            };

            _authors.Add(author);
            return CloneAuthor(author);
        }
    }

    public Author? UpdateAuthor(int id, UpdateAuthorRequest request)
    {
        lock (_syncRoot)
        {
            var author = _authors.FirstOrDefault(author => author.Id == id);
            if (author is null)
            {
                return null;
            }

            author.Name = request.Name.Trim();
            author.Bio = request.Bio?.Trim();

            foreach (var book in _books.Where(book => book.AuthorId == id))
            {
                book.AuthorName = author.Name;
            }

            return CloneAuthor(author);
        }
    }

    public bool DeleteAuthor(int id)
    {
        lock (_syncRoot)
        {
            var author = _authors.FirstOrDefault(author => author.Id == id);
            if (author is null)
            {
                return false;
            }

            _books.RemoveAll(book => book.AuthorId == id);
            return _authors.Remove(author);
        }
    }

    public IReadOnlyList<Book>? GetBooksByAuthor(int authorId)
    {
        lock (_syncRoot)
        {
            if (_authors.All(author => author.Id != authorId))
            {
                return null;
            }

            return _books
                .Where(book => book.AuthorId == authorId)
                .Select(CloneBook)
                .ToList();
        }
    }

    private static Author CloneAuthor(Author author) => new()
    {
        Id = author.Id,
        Name = author.Name,
        Bio = author.Bio
    };

    private static Book CloneBook(Book book) => new()
    {
        Id = book.Id,
        Title = book.Title,
        AuthorId = book.AuthorId,
        AuthorName = book.AuthorName,
        PublicationYear = book.PublicationYear
    };
}
