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
    [Authorize]
    [RoutePrefix("routines/{routineId}/exercises")]
    public class ExerciseController : Controller
    {
        private readonly IExercisesRepository exercisesRepository;

        public ExerciseController(IExercisesRepository exercisesRepository)
        {
            this.exercisesRepository = exercisesRepository;
        }

        [Route()]
        public async Task<ActionResult> Index()
        {
            var exercises = await exercisesRepository.GetExercisesAsync();
            return View(exercises);
        }

        [Route("{id:int}", Name = "Detail")]
        public async Task<ActionResult> Detail(int id)
        {
            var exercise = await exercisesRepository.GetAsync((int)id);

            if (exercise == null) return HttpNotFound();

            return View(exercise);
        }
        
    }
}