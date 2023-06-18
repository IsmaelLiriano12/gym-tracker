using GymTrackerShared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GymTracker.Controllers
{
    [RoutePrefix("diary")]
    public class DiaryController : Controller
    {
        private readonly IIngredientsRepository ingredientsRepository;

        public DiaryController(IIngredientsRepository ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
        }

        [Route()]
        public async Task<ActionResult> Index(string date)
        {
            var meals = await ingredientsRepository.GetIngredientsPerMeal(date);

            return View(meals);
        }
    }
}
