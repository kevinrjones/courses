using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData.Extensions;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.Http.OData.Routing;
using CricketEF;
using Microsoft.Data.OData;
using System.Data.Entity;

namespace CricketWeb.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. 
     
    Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using CricketEF;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Player>("Players");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
     
    */
    public class PlayersController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        readonly CricketEntities _cricketContext = new CricketEntities();

        // GET: odata/Players
        [EnableQuery]
        public IHttpActionResult GetPlayers(ODataQueryOptions<Player> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var players = _cricketContext.Players;
            return Ok<IEnumerable<Player>>(players);
        }

        // GET: odata/Players(5)
        [EnableQuery]
        public IHttpActionResult GetPlayer([FromODataUri] int key, ODataQueryOptions<Player> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            var player = (from p in _cricketContext.Players
                          where p.Id == key
                          select p).First();
            return Ok(player);

        }

        // PUT: odata/Players(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Player> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.
            var player = (from p in _cricketContext.Players
                          where p.Id == key
                          select p).First();

            delta.Put(player);

            // TODO: Save the patched entity.

            // return Updated(player);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Players
        public IHttpActionResult Post(Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(player);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Players(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Player> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.
            var player = (from p in _cricketContext.Players
                          where p.Id == key
                          select p).First();

            // Attach to EF to get change tracking
            _cricketContext.Players.Attach(player);
            // patch the entity
            delta.Patch(player);
            player.Id = key;
            
            _cricketContext.SaveChanges();
            return Updated(player);
        }

        // DELETE: odata/Players(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        protected override void Dispose(bool disposing)
        {
            _cricketContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
