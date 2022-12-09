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
    [RoutePrefix("routines")]
    public class RoutineController : Controller
    {
        private readonly IRoutinesRepository routinesRepository;
        private readonly IExercisesRepository exercisesRepository;

        public RoutineController(IRoutinesRepository routinesRepository, IExercisesRepository exercisesRepository) 
        {
            this.routinesRepository = routinesRepository;
            this.exercisesRepository = exercisesRepository;
        }

        public async Task<ActionResult> Index()
        {
            var routines = await routinesRepository.GetRoutinesAsync(includeExercises: true);

            return View(routines);
        }

        [Route("{id:int}", Name = "RoutinesDetails")]
        public async Task<ActionResult> Detail(int id)
        {
            var routine = await routinesRepository.GetAsync((int)id, true);

            if (routine == null) return HttpNotFound();

            var viewModel = new RoutineDetailViewModel(exercisesRepository)
            {
                Routine = routine
            };

            await viewModel.Init(routine.Id);

            return View(viewModel);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var routine = await routinesRepository.GetAsync((int)id, false);

            if (routine == null)
            {
                return HttpNotFound();
            }

            return View(routine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var routine = await routinesRepository.GetAsync(id, true);

            routinesRepository.Delete(routine);

            if (await routinesRepository.SaveChangesAsync() == false)
            {
                return View();
            }

            TempData["Message"] = "The routine was successfully deleted";

            return RedirectToAction("Index");
        }

        private void ValidateRoutine(Routine routine)
        {
            throw new NotImplementedException();
        }
    }
}