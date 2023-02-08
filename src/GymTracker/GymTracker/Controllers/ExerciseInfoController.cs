using GymTracker.ViewModels;
using GymTrackerShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    [RoutePrefix("exerciseinfo")]
    public class ExerciseInfoController : Controller
    {
        private readonly IWgerService wgerService;

        public ExerciseInfoController(IWgerService wgerService)
        {
            this.wgerService = wgerService;
        }

        [Route("exercises")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            var viewModel = new ExerciseInfoViewModel(wgerService);
            await viewModel.Init(id);

            if (viewModel.IsNull()) return HttpNotFound();

            return View(viewModel);
        }
    }
}
