using GymTracker.ViewModels;
using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    public class RoutineController : Controller
    {
        private readonly IRoutinesRepository routinesRepository;
        private readonly IExercisesRepository exercisesRepository;

        public RoutineController(IRoutinesRepository routinesRepository, IExercisesRepository exercisesRepository) 
        {
            this.routinesRepository = routinesRepository;
            this.exercisesRepository = exercisesRepository;
        }

        public ActionResult Index()
        {
            var routines = routinesRepository.GetList();

            return View(routines);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var routine = routinesRepository.Get((int)id);

            var viewModel = new RoutineDetailViewModel()
            {
                Routine = routine
            };

            viewModel.Init(exercisesRepository, routine.Id);

            return View(viewModel);
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
                routinesRepository.Add(routine);

                return RedirectToAction("Detail", new { id = routine.Id });
            }

            return View(routine);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var routine = routinesRepository.Get((int)id);
            return View(routine);
        }

        [HttpPost]
        public ActionResult Edit(int id, string name)
        {
            var routine = routinesRepository.Get(id);
            //ValidateRoutine(routine);

            if (ModelState.IsValid)
            {
                routine.Name = name;
                routinesRepository.Update(routine);
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

            var routine = routinesRepository.Get((int)id);

            if (routine == null)
            {
                return HttpNotFound();
            }

            return View(routine);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            routinesRepository.Delete(id);

            TempData["Message"] = "The routine was successfully deleted";

            return RedirectToAction("Index");
        }

        private void ValidateRoutine(Routine routine)
        {
            throw new NotImplementedException();
        }
    }
}