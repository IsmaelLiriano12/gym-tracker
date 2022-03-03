using GymTrackerShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    public class ExerciseController : BaseController
    {
        private ExercisesRepository _exercisesRepository = null;

        public ExerciseController()
        {
            _exercisesRepository = new ExercisesRepository(Context);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var exercise = _exercisesRepository.Get((int)id);

            return View(exercise);
        }
    }
}