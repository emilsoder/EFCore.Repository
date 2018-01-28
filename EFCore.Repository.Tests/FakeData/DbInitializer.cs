using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository.Tests.FakeData
{
    public class DbInitializer
    {
        public static FakeDatabase CreateFakeDatabase()
        {
            var builder = new DbContextOptionsBuilder<FakeDatabase>();
            builder.UseInMemoryDatabase( "FakeDatabase");

            var context = new FakeDatabase(builder.Options);
            SeedDatabase(context);
            return context;
        }

        public static void SeedDatabase(FakeDatabase context)
        {
            context.Movies.Add(new MovieEntity { Title = "Never Say Never Again", ReleaseYear = 1983, Summary = "A SPECTRE agent has stolen two American nuclear warheads, and James Bond must find their targets before they are detonated." });
            context.Movies.Add(new MovieEntity { Title = "Diamonds Are Forever ", ReleaseYear = 1971, Summary = "A diamond smuggling investigation leads James Bond to Las Vegas, where he uncovers an evil plot involving a rich business tycoon." });
            context.Movies.Add(new MovieEntity {Title = "You Only Live Twice ", ReleaseYear = 1967, Summary = "Agent 007 and the Japanese secret service ninja force must find and stop the true culprit of a series of spacejackings before nuclear war is provoked." });
            context.SaveChanges();
        }
    }
}
