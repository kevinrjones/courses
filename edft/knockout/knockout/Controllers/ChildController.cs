using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace knockout.Controllers
{
    public class Child
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ChildController : ApiController
    {
        // GET: api/Child
        public IEnumerable<Child> Get()
        {
            return new Child[] { new Child { Name = "Harry" }, new Child { Name = "Sam" }, new Child { Name = "Alex" }, };
        }

        // GET: api/Child/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Child
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Child/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Child/5
        public void Delete(int id)
        {
        }
    }
}
