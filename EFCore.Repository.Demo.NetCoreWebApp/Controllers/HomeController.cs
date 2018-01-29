using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCore.Repository.Demo.NetCoreWebApp.Models;

namespace EFCore.Repository.Demo.NetCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository) => _repository = repository;

        public async Task<IActionResult> Index()
        {
            var model = await _repository.ToListAsync<Movie>();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (movie == null) return LocalRedirect("/");

            await _repository.AddAsync(movie);
            await _repository.SaveChangesAsync();

            return LocalRedirect("/");
        }

         public async Task<IActionResult> Remove(int? id)
        {
            if (!id.HasValue) return LocalRedirect("/");

            await _repository.RemoveAsync<Movie>(x => x.Id == id);
            await _repository.SaveChangesAsync();

            return LocalRedirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Update( Movie movie)
        {
            if (movie == null) return LocalRedirect("/");

            _repository.Update(movie);
            await _repository.SaveChangesAsync();

            return LocalRedirect("/");
        }
    }
}
