using GymTrackerShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    public class RoutineController : BaseController
    {
        private RoutinesRepository _routinesRepository = null;
        public RoutineController() 
        {
            _routinesRepository = new RoutinesRepository(Context);
        }

        public ActionResult Index()
        {
            var routines = _routinesRepository.GetList();

            return View(routines);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var routine = _routinesRepository.Get(1);

            return View(routine);
        }
    }
}