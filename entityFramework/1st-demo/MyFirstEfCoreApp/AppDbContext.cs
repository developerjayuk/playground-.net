using Microsoft.EntityFrameworkCore;

namespace MyFirstEfCoreApp
{
  public class AppDbContext : DbContext
  {
    private const string ConnectionString =            //#A
        @"Server=(localdb)\mssqllocaldb;
             Database=MyFirstEfCoreDb;
             Trusted_Connection=True";

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(ConnectionString); //#B
    }

    public DbSet<Book> Books { get; set; }
  }

  /********************************************************
  #A The connection string is used by the SQL Server database provider to find the database
  #B Using the SQL Server database provider’s UseSqlServer command sets up the options ready for creating the applications’s DBContext
   ********************************************************/
}