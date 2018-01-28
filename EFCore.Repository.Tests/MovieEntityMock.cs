using System.Collections.Generic;
using EFCore.Repository.Tests.FakeData;

namespace EFCore.Repository.Tests
{
    public class MovieEntityMock
    {
        public static MovieEntity Movie => new MovieEntity
        {
            Title = "Pineapple Express",
            ReleaseYear = 2005,
            Summary = "A very funny movie (comedy/action)"
        };

        public static List<MovieEntity> Movies(int count)
        {
            var lst = new List<MovieEntity>();
            for (var i = 0; i < count; i++)
                lst.Add(Movie);
            return lst;
        }
    }
}
