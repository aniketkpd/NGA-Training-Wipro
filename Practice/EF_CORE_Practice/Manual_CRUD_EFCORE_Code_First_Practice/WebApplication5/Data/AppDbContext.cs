using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class AppDbContext : DbContext
    {

        // This constructor is used to pass connecting string to EFCore class DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        //This property is used to create database table
        public DbSet<StudentModel> Student  { get; set; }
    }
}
