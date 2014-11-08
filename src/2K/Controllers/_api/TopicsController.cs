using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using K2.Core.Entity;
using _2K.Core.Context;
using _2K.Core.Entity;

namespace _2K.Controllers._api
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using K2.Core.Entity;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Topic>("Topics");
    builder.EntitySet<Post>("Posts"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class TopicsController : ODataController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: odata/Topics
        [EnableQuery]
        public IQueryable<Topic> GetTopics()
        {
            return db.Topics;
        }

        // GET: odata/Topics(5)
        [EnableQuery]
        public SingleResult<Topic> GetTopic([FromODataUri] int key)
        {
            return SingleResult.Create(db.Topics.Where(topic => topic.ItemId == key));
        }

        // PUT: odata/Topics(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Topic> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Topic topic = await db.Topics.FindAsync(key);
            if (topic == null)
            {
                return NotFound();
            }

            patch.Put(topic);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(topic);
        }

        // POST: odata/Topics
        public async Task<IHttpActionResult> Post(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Topics.Add(topic);
            await db.SaveChangesAsync();

            return Created(topic);
        }

        // PATCH: odata/Topics(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Topic> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Topic topic = await db.Topics.FindAsync(key);
            if (topic == null)
            {
                return NotFound();
            }

            patch.Patch(topic);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(topic);
        }

        // DELETE: odata/Topics(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Topic topic = await db.Topics.FindAsync(key);
            if (topic == null)
            {
                return NotFound();
            }

            db.Topics.Remove(topic);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Topics(5)/Posts
        [EnableQuery]
        public IQueryable<Post> GetPosts([FromODataUri] int key)
        {
            return db.Topics.Where(m => m.ItemId == key).SelectMany(m => m.Posts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopicExists(int key)
        {
            return db.Topics.Count(e => e.ItemId == key) > 0;
        }
    }
}
