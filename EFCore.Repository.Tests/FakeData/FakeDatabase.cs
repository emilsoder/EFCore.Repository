using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository.Tests.FakeData
{
    public class FakeDatabase : DbContext
    {
        public FakeDatabase(DbContextOptions options) : base(options) { }

        public DbSet<MovieEntity> Movies { get; set; }
    }
}
