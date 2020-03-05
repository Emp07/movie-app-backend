using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieWebApi.Models;

namespace MovieWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesContext _context;

        public MoviesController(MoviesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return _context.Movies.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
                return NotFound();

            return movie;
        }

        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id}, movie);
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
                return BadRequest();
            
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return NoContent();
        }
    }
}