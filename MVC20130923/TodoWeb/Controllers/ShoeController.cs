using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TodoWeb.Controllers
{
    public class Shoe
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string Style { get; set; }
    }


    public class ShoeController : ApiController
    {
        // GET api/shoe

        static readonly List<Shoe> Shoes = new List<Shoe> { new Shoe { Id = 1, Size = 44, Color = "Maroon", Style = "Desert Boot" }, new Shoe { Id = 2, Size = 36, Color = "Pink", Style = "Converse" } };

        public IEnumerable<Shoe> Get()
        {
            return Shoes;
        }

        // GET api/shoe/5
        public Shoe Get(int id)
        {
            return Shoes.First(s => s.Id == id);
        }

        // POST api/shoe
        public void Post(Shoe shoe)
        {
            shoe.Id = Shoes.Count + 1;
            Shoes.Add(shoe);
        }

        // PUT api/shoe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/shoe/5
        public void Delete(int id)
        {
        }
    }
}
