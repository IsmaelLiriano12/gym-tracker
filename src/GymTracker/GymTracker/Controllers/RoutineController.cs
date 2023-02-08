using GymTracker.ViewModels;
using GymTrackerShared.Data;
using GymTrackerShared.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    [Authorize]
    [RoutePrefix("my-routine")]
    public class RoutineController : Controller
    {
        private readonly IRoutinesRepository routinesRepository;
        private readonly IExercisesStatsRepository exercisesRepository;

        public RoutineController(IRoutinesRepository routinesRepository, IExercisesStatsRepository exercisesRepository) 
        {
            this.routinesRepository = routinesRepository;
            this.exercisesRepository = exercisesRepository;
        }

        [Route()]
        public async Task<ActionResult> Detail()
        {
            var routine = await routinesRepository.GetAsync(User.Identity.GetUserId(), true);

            if (routine == null) return HttpNotFound();

            var viewModel = new RoutineDetailViewModel(exercisesRepository)
            {
                Routine = routine
            };

            await viewModel.Init(routine.Id);

            return View(viewModel);
        }

        private void ValidateRoutine(Routine routine)
        {
            throw new NotImplementedException();
        }
    }
}