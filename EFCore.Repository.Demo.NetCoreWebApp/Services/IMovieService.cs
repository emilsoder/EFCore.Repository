using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.Repository.Demo.NetCoreWebApp.Models;

namespace EFCore.Repository.Demo.NetCoreWebApp.Services
{
    public interface IMovieService
    {
        Task<int> Add(Movie movie);
        Task<int> Remove(int id);
        Task<int> Update(Movie movie);

        Task<List<Movie>> Movies();
    }
}