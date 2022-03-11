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
        private MuscleGroupsRepository _muscleGroupsRepository = null;

        public ExerciseController()
        {
            _exercisesRepository = new ExercisesRepository(Context);
            _muscleGroupsRepository = new MuscleGroupsRepository(Context);
        }

        public ActionResult Index()
        {
            var exercises = _muscleGroupsRepository.GetList();
            return View(exercises);
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