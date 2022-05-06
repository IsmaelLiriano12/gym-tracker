using GymTracker.ViewModels;
using GymTrackerShared.Commands;
using GymTrackerShared.Data;
using GymTrackerShared.Models;
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
        private readonly RoutinesRepository _routinesRepository = null;

        public ExerciseController()
        {
            _exercisesRepository = new ExercisesRepository(Context);
            _routinesRepository = new RoutinesRepository(Context);
        }

        public ActionResult Index()
        {
            var exercises = _exercisesRepository.GetList();
            return View(exercises);
        }

        public ActionResult Detail(int? id, int? routineId)
        {
            if (id == null || routineId == null)
                return HttpNotFound();

            var exercise = _exercisesRepository.Get((int)id, (int)routineId);

            return View(exercise);
        }

        public ActionResult Add(int routineId, int dayId)
        {
            var routine = _routinesRepository.Get(routineId);

            if (routine == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ExerciseDaysAddViewModel()
            {
                Routine = routine
            };

            viewModel.Init(Context, dayId);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ExerciseDaysAddViewModel viewModel)
        {
            //ValidateExerciseDay(viewModel);

            if (ModelState.IsValid)
            {
                var exercise = viewModel.Exercise;

                var progress = new ProgressiveOverload()
                {
                    DateCreated = DateTime.Now,
                    Weight = exercise.Weight,
                    Repetitions = exercise.Repetitions,
                    Sets = exercise.Sets
                };

                exercise.AddProgress(progress);

                _exercisesRepository.Add(exercise);                

                TempData["Message"] = $"{exercise.Name} was successfully added to the routine!";

                return RedirectToAction("Detail", "Routine", new { id = viewModel.RoutineId });
            }

            return View(viewModel);
        }

        public ActionResult Edit(int? id, int? routineId, int? dayId)
        {
            if (id == null || routineId == null || dayId == null) { return HttpNotFound(); }

            var exercise = _exercisesRepository.Get((int)id, (int)routineId);

            var viewModel = new ExerciseDaysAddViewModel()
            {
                Exercise = exercise,
                RoutineId = exercise.RoutineId,
            };

            viewModel.Init(Context, (int)dayId);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ExerciseDaysAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var exercise = viewModel.Exercise;
                exercise.RoutineId = viewModel.RoutineId;
                var progress = new AddProgressiveOverloadCommand(Context)
                    .Execute(exercise.Id, exercise.Weight, exercise.Repetitions, exercise.Sets);
                exercise.AddProgress(progress);

                _exercisesRepository.Update(exercise);

                return RedirectToAction("Detail", new { Id = viewModel.Exercise.Id, routineId = viewModel.RoutineId });
            }

            return View(viewModel);
        }

    }
}