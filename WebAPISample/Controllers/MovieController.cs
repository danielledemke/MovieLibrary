using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;
        }
        // GET api/movie
        [HttpGet]
        public IActionResult Get()
        {
            // Retrieve all movies from db logic
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var selectedMovie = _context.Movies.Where(m => m.MovieId == id).SingleOrDefault();
            // Retrieve movie by id from db logic
            // return Ok(movie);
            return Ok(selectedMovie);
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody]Movie value)
        {
            // Create movie in db logic
            value = new Movie();
            _context.Movies.Add(value);
            _context.SaveChangesAsync();
            return Ok(value);
        }

        // PUT api/movie
        [HttpPut]
        public IActionResult Put([FromBody] Movie movie)
        {
            // Update movie in db logic
            //updatedMovie.Title = movie.Title;
            var updatedMovie = _context.Movies.Where(m => m.MovieId == movie.MovieId).SingleOrDefault();
            updatedMovie.Title = movie.Title;
            updatedMovie.Director = movie.Director;
            updatedMovie.Genre = movie.Genre;
            _context.SaveChangesAsync();
            return Ok(updatedMovie);
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete movie from db logic
            var movieToDelete = _context.Movies.Where(m => m.MovieId == id).SingleOrDefault();
            _context.Remove(movieToDelete);
            _context.SaveChangesAsync();
            return Ok();
        }
    }
}