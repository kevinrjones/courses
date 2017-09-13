using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BooksService.Controllers
{
    public class Movie
    {
        public string Title { get; set; }
        public string Quote { get; set; }
    }

    public class MoviesController : ApiController
    {
        static readonly List<Movie> Movies = new List<Movie>
        {
            new Movie{Title = "Jaws", Quote = "It's not about a shark"},
            new Movie{Title = "Tinker,Tailor, Soldier, Spy", Quote = "It's not about spying"}
        }; 

        // GET api/values
        public IEnumerable<Movie> Get()
        {
            return Movies;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            if (id > 2)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Movies[id -1]);            
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
