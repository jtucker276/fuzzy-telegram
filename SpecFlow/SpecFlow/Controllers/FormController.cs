using SpecFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpecFlow.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [HttpGet]
        public ActionResult Create()
        {
            var vm = new FormViewModel();

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public ActionResult Update(FormViewModel postedModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUpdate", postedModel);
            }

            return View("View", postedModel);
        }
    }
}