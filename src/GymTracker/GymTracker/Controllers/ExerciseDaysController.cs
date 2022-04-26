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
    public class ExerciseDaysController : BaseController
    {
        private RoutinesRepository _routinesRepository = null;
        private ExercisesRepository _exercisesRepository = null;
        private ExerciseDaysRepository _exerciseDaysRepository = null;
        private TrainingDaysRepository _trainingDaysRepository = null;

        public ExerciseDaysController()
        {
            _routinesRepository = new RoutinesRepository(Context);
            _exercisesRepository= new ExercisesRepository(Context);
            _exerciseDaysRepository = new ExerciseDaysRepository(Context);
            _trainingDaysRepository = new TrainingDaysRepository(Context);
        }

        public ActionResult Detail(int? id, int? routineId, int? dayId)
        {
            if (id == null || routineId == null || dayId == null) { return HttpNotFound(); }

            var exerciseDay = _exerciseDaysRepository.Get((int)id, (int)routineId, (int)dayId);

            return View(exerciseDay);
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

            viewModel.Init(Context, _trainingDaysRepository, dayId);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(ExerciseDaysAddViewModel viewModel)
        {
            //ValidateExerciseDay(viewModel);

            if (ModelState.IsValid)
            {
                var exercise = viewModel.Exercise;

                _exercisesRepository.Add(exercise);

                var exerciseDay = new ExerciseDay()
                {
                    RoutineId = viewModel.RoutineId,
                    TrainingDayId = viewModel.TrainingDayId,
                    ExerciseId = exercise.Id
                };
                _exerciseDaysRepository.Add(exerciseDay);

                TempData["Message"] = $"{exercise.Name} was successfully added to the routine!";

                return RedirectToAction("Detail", "Routine", new { id = viewModel.RoutineId});
            }

            return View(viewModel);
        }

        public ActionResult Edit(int? id, int? routineId, int? dayId)
        {
            if (id == null || routineId == null || dayId == null) { return HttpNotFound(); }

            var exerciseDay = _exerciseDaysRepository.Get((int)id, (int)routineId, (int)dayId);

            var viewModel = new ExerciseDaysAddViewModel()
            {
                Exercise = exerciseDay.Exercise,
                RoutineId = exerciseDay.RoutineId,
            };

            viewModel.Init(Context, _trainingDaysRepository, (int)dayId);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ExerciseDaysAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _exercisesRepository.Update(viewModel.Exercise);

                return RedirectToAction("Detail", new { Id = viewModel.Exercise.Id, routineId = viewModel.RoutineId, dayId = viewModel.TrainingDayId });
            }

            return View(viewModel);
        }

        private ActionResult GetExerciseDayEntity(int? id, int? routineId, int? dayId)
        {
            if (id == null || routineId == null || dayId == null) { return HttpNotFound(); }

            var exerciseDay = _exerciseDaysRepository.Get((int)id, (int)routineId, (int)dayId);

            return View(exerciseDay);
        }

        private void ValidateExerciseDay(ExerciseDaysAddViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}