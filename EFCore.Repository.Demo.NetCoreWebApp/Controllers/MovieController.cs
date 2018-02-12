using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repository.Demo.NetCoreWebApp.Models;
using EFCore.Repository.Demo.NetCoreWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Repository.Demo.NetCoreWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService) => _movieService = movieService;

        [HttpGet("list")]
        public async Task<List<Movie>> List()
        {
            return await _movieService.Movies();
        }

        [HttpPost("add")]
        public async Task<int> Add(Movie movie)
        {
            return movie != null ? await _movieService.Add(movie) : 0;
        }

        [HttpGet("remove/{id?}")]
        public async Task<int> Remove(int? id)
        {
            return id.HasValue ? await _movieService.Remove(id.Value) : 0;
        }

        [HttpPost("update")]
        public async Task<int> Update(Movie movie)
        {
            return movie != null ? await _movieService.Update(movie) : 0;
        }
    }
}