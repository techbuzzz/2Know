using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using K2.Core.ViewModel.Post;
using PagedList;
using _2K.Core.Entity;

namespace _2K.Controllers
{
    public class PostController : BaseController
    {
        // GET: Post
        public async Task<ActionResult> Index(PostListViewModel postListViewModel,int? page)
        {
            IQueryable<Post> posts = Db.Posts;
            int itemsPerPage = 25;
            int pageNumber = page ?? 1;
            var postsView = posts.Select(p => new PostListViewModel.PostListItemViewModel()
            {
                CommentCount = p.Comments.Count,
                CreatedBy = "SMT",
                ItemId = p.ItemId,
                Title = p.Title,
                Votes = 100
            });
            postListViewModel.GridData = postsView;
            postListViewModel.TotalCount = postsView.Count();
            var itemsList = await postListViewModel.GridData.ToListAsync();
            //return View(postsView.ToPagedList(pageNumber, itemsPerPage));
            return View(itemsList.ToPagedList(pageNumber: page ?? 1,pageSize: 10));
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
