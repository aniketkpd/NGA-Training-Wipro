using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Intro;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=localhost\SQLEXPRESS;Database=Blogging;Trusted_Connection=True;TrustServerCertificate=True");
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; } = "";
    public int Rating { get; set; }

    public List<Post> Posts { get; set; } = new();
}

public class Post
{
    public int PostId { get; set; }

    public string Title { get; set; } = "";
    public string Content { get; set; } = "";

    public int BlogId { get; set; }
    public Blog Blog { get; set; } = null!;
}

class Program
{
    static void Main()
    {
        Console.WriteLine("EF Core Ready");
    }
}