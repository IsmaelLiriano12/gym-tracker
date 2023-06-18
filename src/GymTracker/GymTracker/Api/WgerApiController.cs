using GymTrackerShared.ApiModels;
using GymTrackerShared.Data;
using GymTrackerShared.Models;
using GymTrackerShared.Models.WgerModels;
using GymTrackerShared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace GymTracker.Api
{
    [RoutePrefix("api/wger")]
    public class WgerApiController : ApiController
    {
        private readonly IWgerService service;
        private readonly IIngredientsRepository ingredientsRepository;

        public WgerApiController(IWgerService service, IIngredientsRepository ingredientsRepository)
        {
            this.service = service;
            this.ingredientsRepository = ingredientsRepository;
        }

        [Route("exercisebaseinfo")]
        [HttpGet]
        public async Task<IHttpActionResult> GetExerciseBaseInfoCollection(int? variations = null)
        {
            try
            {
                var result = await service.GetExerciseBaseInfoCollectionAsync(variations);

                if (result == null)
                    return InternalServerError();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("exercisebaseinfo/suggestions/{name}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetExerciseBaseInfoSuggestions(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return BadRequest();

                var result = await service.GetExerciseBaseInfoSuggetionsAsync(name);

                if (result == null || result.Count() == 0)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("exercisebaseinfo/{id:int}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetExerciseBaseInfo(int id)
        {
            try
            {
                var result = await service.GetExerciseBaseInfoAsync(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("ingredients/{name}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetIngredientsSuggestions(string name)
        {
            try
            {
                var result = await service.GetIngredientSuggestionResultAsync(name);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("ingredients/{id:int}", Name = "GetIngredient")]
        [HttpGet]
        public async Task<IHttpActionResult> GetIngredient(int id)
        {
            try
            {
                var result = await ingredientsRepository.GetIngredientAsync(id);

                if(result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("ingredients")]
        [HttpPost]
        public async Task<IHttpActionResult> PostIngredient([FromBody] IngredientModel model, string date = null)
        {
            try
            {
                var nutritionFacts = await service.GetNutritionFactsAsync(model.WgerNutritionResultId, model.Amount);

                var ingredient = new Ingredient()
                {
                    NutritionFactsId = model.WgerNutritionResultId,
                    Name = model.Name,
                    NutritionFacts = nutritionFacts,
                    Meal = model.Meal,
                    Amount = model.Amount,
                    CreationDate = date == null ? Convert.ToDateTime(DateTime.Now.ToShortDateString()) : Convert.ToDateTime(date)
                };

                ingredientsRepository.Add(ingredient);
                await ingredientsRepository.SaveChangesAsync();

                return CreatedAtRoute("GetIngredient", new { id = ingredient.Id}, ingredient);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
