using Microsoft.AspNetCore.Mvc;
using Mock_CA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mock_CA1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        //Static Field
        //In-memory collection of Movies
        private static List<Movie> mList = new List<Movie>()
        {
            new  Movie(){ID = 1, Title = "The Groods", Genre = Genres.Animation, Date = DateTime.Now, AvgRating = 7.5 },
            new  Movie(){ID = 2, Title = "Bad Boys", Genre = Genres.Adventure, Date = DateTime.Now, AvgRating = 8 },
            new  Movie(){ID = 3, Title = "Greyhound", Genre = Genres.Action, Date = DateTime.Now, AvgRating = 8.2 },
            new  Movie(){ID = 4, Title = "Snatch", Genre = Genres.Crime, Date = DateTime.Now, AvgRating = 8.3}
            
        };


        //GET, POST, PUT, DELETE Api Methods


        //Return data about all movies in the catalogue, sorted in descending order of Data
        // GET: api/<MovieController>
        [HttpGet]
        public List<Movie> Get()
        {
            return mList.OrderByDescending(m=> m.Date).Select(m=>m).ToList();
        }

        //Return data about a specific movie as specified using a movie ID
        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
           return mList.SingleOrDefault(m => m.ID == id);
        }

        //Return a list of Movie IDs and Titles for movies containing a specified keyword in the title
        // GET api/<MovieController>/GetMovies/rood
        [HttpGet("GetMovies/{keyword}")]
        public List<Movie> GetMovies(string keyword)
        {
            return mList.Where(m => m.Title.ToLower().Contains(keyword.ToLower())).ToList();
        }











        //No requirements for POST, PUT or DELETE

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
