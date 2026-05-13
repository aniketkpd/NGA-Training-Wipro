// this will act as a bridge between application and database 
//It is reisponsible for DB communication  
//it tracks entity changes 
using Microsoft.EntityFrameworkCore;
using StudentEFCoreDemo.Models;



namespace StudentEFCoreDemo.Data
{
    public class  AppDbContext : DbContext
    {
         public AppDbContext(
        DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> students{get; set;}
        // above preporty is used for accessing student class memebers as properties 
    }
}