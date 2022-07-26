using GymTracker.ViewModels;
using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExercisesRepository exercisesRepository;
        private readonly AddProgressiveOverload addProgressiveOverload;

        public ExerciseController(IExercisesRepository exercisesRepository, AddProgressiveOverload addProgressiveOverload)
        {
            this.exercisesRepository = exercisesRepository;
            this.addProgressiveOverload = addProgressiveOverload;
        }

        public async Task<ActionResult> Index()
        {
            var exercises = await exercisesRepository.GetList();
            return View(exercises);
        }

        public async Task<ActionResult> Detail(int? id, int? routineId)
        {
            if (id == null || routineId == null)
                return HttpNotFound();

            var exercise = await exercisesRepository.Get((int)id);

            return View(exercise);
        }

        public ActionResult Add(int? routineId)
        {
            if (routineId == null)
            {
                return HttpNotFound();
            }

            var exercise = new Exercise()
            {
                RoutineId = (int)routineId
            };

            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Exercise exercise)
        {
            AreSetsAndRepsGreaterThanZero(exercise);

            if (ModelState.IsValid)
            {
                var progress = new ProgressiveOverload()
                {
                    DateCreated = DateTime.Now,
                    Weight = exercise.Weight,
                    Repetitions = exercise.Repetitions,
                    Sets = exercise.Sets
                };

                exercise.AddProgress(progress);

                await exercisesRepository.Add(exercise);

                TempData["Message"] = $"{exercise.Name} was successfully added to the routine!";

                return RedirectToAction("Detail", "Routine", new { id = exercise.RoutineId });
            }

            return View(exercise);
        }

       

        public async Task<ActionResult> Edit(int? id, int? routineId)
        {
            if (id == null || routineId == null) 
            { 
                return HttpNotFound(); 
            }

            var exercise = await exercisesRepository.Get((int)id);

            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Exercise exercise)
        {
            AreSetsAndRepsGreaterThanZero(exercise);

            if (ModelState.IsValid)
            {
                var progress = await addProgressiveOverload
                    .Execute(exercise.Id, exercise.Weight, exercise.Repetitions, exercise.Sets);

                exercise.AddProgress(progress);

                await exercisesRepository.Update(exercise);

                return RedirectToAction("Detail", new { Id = exercise .Id, routineId = exercise.RoutineId });
            }

            return View(exercise);
        }

        public async Task<ActionResult> Delete(int? id, int? routineId)
        {
            if (id == null || routineId == null)
            {
                return HttpNotFound();
            }

            var exercise = await exercisesRepository.Get((int)id);

            if (exercise == null)
            {
                return HttpNotFound();
            }

            return View(exercise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, int routineId)
        {
            await exercisesRepository.Delete(id);

            TempData["Message"] = "The exercise was successfully deleted";

            return RedirectToAction("Detail", "Routine", new { id = routineId});
        }

        private void AreSetsAndRepsGreaterThanZero(Exercise exercise)
        {
            if (exercise.Sets <= 0)
            {
                ModelState.AddModelError("Sets", "The number of sets must be greater than 0");
            }

            if (exercise.Repetitions <= 0)
            {
                ModelState.AddModelError("Repetitions", "The number of reps must be greater than 0");
            }
        }

    }
}