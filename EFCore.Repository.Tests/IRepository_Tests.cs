using System;
using System.Threading.Tasks;
using EFCore.Repository.Tests.FakeData;
using Xunit;

namespace EFCore.Repository.Tests
{
    public class IRepository_Tests
    {
        private readonly IRepository _repository;

        public IRepository_Tests()
        {
            var _context = DbInitializer.CreateFakeDatabase();
            _repository = new RepositoryBase(_context);
        }


        [Fact]
        public void Add_One()
        {
            // Arrange
            var movie = MovieEntityMock.Movie;

            // Act
            _repository.Add(movie);
            var result = _repository.SaveChanges();

            // Assert
            Assert.True(result == 1);
        }

        [Fact]
        public void Add_Many()
        {
            // Arrange
            var movies = MovieEntityMock.Movies(5);

            // Act
            _repository.Add(movies);
            var result = _repository.SaveChanges();

            // Assert
            Assert.True(result == 5);
        }

        [Fact]
        public void Remove_One_Entity()
        {
            // Arrange
            var movie = First_Test();

            // Act
            _repository.Remove(movie);
            var result = _repository.SaveChanges();

            // Assert
            Assert.True(result == 1);
        }

        [Fact]
        public void Remove_One_ById()
        {
            // Arrange
            var movie = First_Test();

            // Act
            _repository.Remove<MovieEntity>(movie.Id);
            var result = _repository.SaveChanges();

            // Assert
           Assert.True(result == 1);
        }

        [Fact]
        public MovieEntity First_Test()
        {
            // Act
            var result = _repository.First<MovieEntity>();

            // Assert
            Assert.NotNull(result);

            return result;
        }

        [Fact]
        public async Task Add_One_Async()
        {
            // Arrange
            var movie = MovieEntityMock.Movie;

            // Act
            await _repository.AddAsync(movie);
            var result = await _repository.SaveChangesAsync();

            // Assert
            Assert.True(result == 1);
        }

        [Fact]
        public async Task Add_Many_Async()
        {
            // Arrange
            var movies = MovieEntityMock.Movies(5);

            // Act
            await _repository.AddAsync(movies);
            var result = await _repository.SaveChangesAsync();

            // Assert
            Assert.True(result == 5);
        }
    }
}
