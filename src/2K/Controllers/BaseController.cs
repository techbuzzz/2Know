using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _2K.Core.Context;

namespace _2K.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class BaseController:Controller
    {
        private DatabaseContext _db;
        public DatabaseContext Db { get { return _db; } }

        public BaseController()
        {
            _db = new DatabaseContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _db.Dispose();
        }

        protected new RedirectToRouteResult RedirectToAction(string actionName)
        {
            TempData["IsRedirect"] = true;
            return base.RedirectToAction(actionName);
        }
        protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues)
        {
            TempData["IsRedirect"] = true;
            return base.RedirectToAction(actionName, controllerName, routeValues);
        }

        protected override RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues)
        {
            TempData["IsRedirect"] = true;
            return base.RedirectToActionPermanent(actionName, controllerName, routeValues);
        }
    }
}