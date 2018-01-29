using EFCore.Repository.Demo.NetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository.Demo.NetCoreWebApp.Data
{
    public class FakeDatabase : DbContext
    {
        public FakeDatabase(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
