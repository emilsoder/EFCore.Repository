using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.Repository.Demo.NetCoreWebApp.Models;

namespace EFCore.Repository.Demo.NetCoreWebApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository _repository;

        public MovieService(IRepository repository) => _repository = repository;

        public async Task<int> Add(Movie movie)
        {
            await _repository.AddAsync(movie);
            return await _repository.SaveChangesAsync();
        }

        public async Task<int> Remove(int id)
        {
            await _repository.RemoveAsync<Movie>(id);
            return await _repository.SaveChangesAsync();
        }

        public async Task<int> Update(Movie movie)
        {
            _repository.Update(movie);
            return await _repository.SaveChangesAsync();
        }

        public async Task<List<Movie>> Movies() => await _repository.ToListAsync<Movie>();
    }

}
