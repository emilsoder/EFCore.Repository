using System.Linq;
using EFCore.Repository.Demo.NetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository.Demo.NetCoreWebApp.Data
{
    public class DbSeeder
    {
        public static void SeedDatabase(FakeDatabase _context)
        {
            if (_context.Movies.Any()) return;
            _context.Database.EnsureCreated();
            _context.Movies.Add(new Movie { Title = "Never Say Never Again", ReleaseYear = 1983, Summary = "A SPECTRE agent has stolen two American nuclear warheads, and James Bond must find their targets before they are detonated." });
            _context.Movies.Add(new Movie { Title = "Diamonds Are Forever ", ReleaseYear = 1971, Summary = "A diamond smuggling investigation leads James Bond to Las Vegas, where he uncovers an evil plot involving a rich business tycoon." });
            _context.Movies.Add(new Movie { Title = "You Only Live Twice ", ReleaseYear = 1967, Summary = "Agent 007 and the Japanese secret service ninja force must find and stop the true culprit of a series of spacejackings before nuclear war is provoked." });
            _context.SaveChanges();
        }
    }
}
