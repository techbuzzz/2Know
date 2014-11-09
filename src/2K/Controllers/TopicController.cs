using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _2K.Core.Entity;
using _2K.Core.ViewModel.Topic;

namespace _2K.Controllers
{
    public class TopicController : BaseController
    {
        // GET: Topic
        public ActionResult Index()
        {
            return View();
        }

        // GET: Topic/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var allPosts = await Db.Posts.Where(p => p.TopicId == id).ToListAsync();
            var vm = new TopicDetailsViewModel(allPosts);
            Topic topic = await Db.Topics.FindAsync(id);
            vm.Title = topic.Title;
            vm.Content = topic.Content;
            return View(vm);
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            return View(new TopicNewViewModel());
        }

        // POST: Topic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TopicNewViewModel vm)
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

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Topic/Edit/5
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

        // GET: Topic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topic/Delete/5
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
