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
            var exercises = await exercisesRepository.GetExercisesAsync();
            return View(exercises);
        }

        public async Task<ActionResult> Detail(int? id, int? routineId)
        {
            if (id == null || routineId == null)
                return HttpNotFound();

            var exercise = await exercisesRepository.GetAsync((int)id);

            return View(exercise);
        }
        
    }
}