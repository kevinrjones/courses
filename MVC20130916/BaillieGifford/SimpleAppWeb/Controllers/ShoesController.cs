using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleAppWeb.Controllers
{

    public class Shoe
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
    }

    public class ShoesController : ApiController
    {
        static readonly List<Shoe> Shoes = new List<Shoe>
        {
            new Shoe{Id=1, Color="Maroon", Size = 44},
            new Shoe{Id = 2, Color="Black", Size = 43},
            new Shoe{Id = 3, Color="Blue", Size=38}
        };

        // GET api/shoes
        public IEnumerable<Shoe> Get()
        {
            return Shoes;
        }

        // GET api/shoes/5
        public Shoe Get(int id)
        {
            return Shoes.First(s => s.Id == id);
        }

        // POST api/shoes
        public void Post(Shoe value)
        {
            value.Id = new Random().Next();
            Shoes.Add(value);
        }

        // PUT api/shoes/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/shoes/5
        public void Delete(int id)
        {
        }
    }
}
