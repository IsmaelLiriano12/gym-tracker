using GymTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    public class RoutineController : BaseController
    {
        public RoutineController() 
        {
        }

        public ActionResult Detail(int? id)
        {
            return View();
        }
    }
}