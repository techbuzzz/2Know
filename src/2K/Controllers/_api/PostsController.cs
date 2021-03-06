﻿using System;
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
using _2K.Core.Context;
using _2K.Core.Entity;

namespace _2K.Controllers._api
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using _2K.Core.Entity;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Post>("Posts");
    builder.EntitySet<PostComment>("Comments"); 
    builder.EntitySet<PostFile>("PostFiles"); 
    builder.EntitySet<Tag>("Tags"); 
    builder.EntitySet<Topic>("Topics"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PostsController : ODataController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: odata/Posts
        [EnableQuery]
        public IQueryable<Post> GetPosts()
        {
            return db.Posts;
        }

        // GET: odata/Posts(5)
        [EnableQuery]
        public SingleResult<Post> GetPost([FromODataUri] int key)
        {
            return SingleResult.Create(db.Posts.Where(post => post.ItemId == key));
        }

        // PUT: odata/Posts(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Post> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Post post = await db.Posts.FindAsync(key);
            if (post == null)
            {
                return NotFound();
            }

            patch.Put(post);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(post);
        }

        // POST: odata/Posts
        public async Task<IHttpActionResult> Post(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            await db.SaveChangesAsync();

            return Created(post);
        }

        // PATCH: odata/Posts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Post> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Post post = await db.Posts.FindAsync(key);
            if (post == null)
            {
                return NotFound();
            }

            patch.Patch(post);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(post);
        }

        // DELETE: odata/Posts(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Post post = await db.Posts.FindAsync(key);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Posts(5)/Comments
        [EnableQuery]
        public IQueryable<PostComment> GetComments([FromODataUri] int key)
        {
            return db.Posts.Where(m => m.ItemId == key).SelectMany(m => m.Comments);
        }

        // GET: odata/Posts(5)/Files
        [EnableQuery]
        public IQueryable<PostFile> GetFiles([FromODataUri] int key)
        {
            return db.Posts.Where(m => m.ItemId == key).SelectMany(m => m.Files);
        }

        // GET: odata/Posts(5)/Tags
        [EnableQuery]
        public IQueryable<Tag> GetTags([FromODataUri] int key)
        {
            return db.Posts.Where(m => m.ItemId == key).SelectMany(m => m.Tags);
        }

        // GET: odata/Posts(5)/Topic
        [EnableQuery]
        public SingleResult<Topic> GetTopic([FromODataUri] int key)
        {
            return SingleResult.Create(db.Posts.Where(m => m.ItemId == key).Select(m => m.Topic));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int key)
        {
            return db.Posts.Count(e => e.ItemId == key) > 0;
        }
    }
}
