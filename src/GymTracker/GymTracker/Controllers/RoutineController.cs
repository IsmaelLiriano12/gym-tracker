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
            var routines = await routinesRepository.GetList(includeExercises: true);

            return View(routines);
        }

        public async Task<ActionResult> Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var routine = await routinesRepository.Get((int)id);

            var viewModel = new RoutineDetailViewModel(exercisesRepository)
            {
                Routine = routine
            };

            await viewModel.Init(routine.Id);

            return View(viewModel);
        }

        public ActionResult Add()
        {
            var routine = new Routine();
            return View(routine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Routine routine)
        {
            //ValidateRoutine(routine);

            if (ModelState.IsValid)
            {
                await routinesRepository.Add(routine);

                return RedirectToAction("Detail", new { id = routine.Id });
            }

            return View(routine);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var routine = await routinesRepository.Get((int)id);
            return View(routine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, string name)
        {
            var routine = await routinesRepository.Get(id);
            //ValidateRoutine(routine);

            if (ModelState.IsValid)
            {
                routine.Name = name;
                await routinesRepository.Update(routine);
                return RedirectToAction("Index");
            }

            return View(routine);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var routine = await routinesRepository.Get((int)id);

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
            await routinesRepository.Delete(id);

            TempData["Message"] = "The routine was successfully deleted";

            return RedirectToAction("Index");
        }

        private void ValidateRoutine(Routine routine)
        {
            throw new NotImplementedException();
        }
    }
}