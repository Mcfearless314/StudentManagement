using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentManagement.Database;


public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=StudentManagement;Trusted_Connection=True;");
        return new AppDbContext(optionsBuilder.Options);
    }
}