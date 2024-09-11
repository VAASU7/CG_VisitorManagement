using Microsoft.EntityFrameworkCore;
using VisitorManagemment;


namespace VisitorManagemment;

public class  DBContext:DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {}

    public DbSet<Technical>Technical{get;set;} 
   // public DbSet<Non_Technical>Non_Technical{get;set;}   

}

