using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace College.Controllers
{
    public class CollegeMenuController : Controller
    {
        // GET: CollegeMenu
        public ActionResult OpenCollegeMenu()
        {
            return View("CollegeMenu");
        }
    }
}