using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MovieWebApi.Models
{
    public class MoviesContextFactory : IDesignTimeDbContextFactory<MoviesContext>
    {
        public MoviesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoviesContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=StrongPassword;database=moviesDB;");

            return new MoviesContext(optionsBuilder.Options);
        }
    }
}