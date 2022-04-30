using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    public class RoutineController : BaseController
    {
        private readonly RoutinesRepository _routinesRepository = null;
        private readonly ExerciseDaysRepository _exerciseDaysRepository = null;
        public RoutineController() 
        {
            _routinesRepository = new RoutinesRepository(Context);
            _exerciseDaysRepository = new ExerciseDaysRepository(Context);
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

            var routine = _routinesRepository.Get((int)id);

            return View(routine);
        }

        public ActionResult Add()
        {
            var routine = new Routine();
            return View(routine);
        }

        [HttpPost]
        public ActionResult Add(Routine routine)
        {
            //ValidateRoutine(routine);

            if (ModelState.IsValid)
            {
                _routinesRepository.Add(routine);

                for (int i = 1; i <= routine.NumberOfDays; i++)
                {
                    var exerciseDay = new ExerciseDay()
                    {
                        RoutineId = routine.Id,
                        TrainingDayId = i,
                        ExerciseId = i
                    };
                    _exerciseDaysRepository.Add(exerciseDay);
                }

                return RedirectToAction("Detail", new { id = routine.Id});
            }

            return View(routine);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var routine = _routinesRepository.Get((int)id);
            return View(routine);
        }

        [HttpPost]
        public ActionResult Edit(int id, string name)
        {
            var routine = _routinesRepository.Get(id);
            //ValidateRoutine(routine);

            if (ModelState.IsValid)
            {
                routine.Name = name;
                _routinesRepository.Update(routine);
                return RedirectToAction("Index");
            }

            return View(routine);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var routine = _routinesRepository.Get((int)id);

            if (routine == null)
            {
                return HttpNotFound();
            }

            return View(routine);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _routinesRepository.Delete(id);

            TempData["Message"] = "The routine was successfully deleted";

            return RedirectToAction("Index");
        }

        private void ValidateRoutine(Routine routine)
        {
            throw new NotImplementedException();
        }
    }
}