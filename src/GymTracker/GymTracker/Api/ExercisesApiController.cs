using AutoMapper;
using GymTrackerShared.ApiModels;
using GymTrackerShared.Data;
using GymTrackerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GymTracker.Api
{
    [RoutePrefix("api/exercises")]
    public class ExercisesApiController : ApiController
    {
        private readonly IExercisesRepository exercisesRepository;
        private readonly AddProgressiveOverload addProgressiveOverload;
        private readonly IMapper mapper;

        public ExercisesApiController
            (IExercisesRepository exercisesRepository, AddProgressiveOverload addProgressiveOverload, IMapper mapper)
        {
            this.exercisesRepository = exercisesRepository;
            this.addProgressiveOverload = addProgressiveOverload;
            this.mapper = mapper;
        }

        //[Route()]
        //public async Task<IHttpActionResult> Get()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex);
        //    }
        //}

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put([FromUri]int id, [FromBody]ExerciseModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exercise = await exercisesRepository.Get(id);
                    if (exercise == null) return NotFound();

                    mapper.Map(model, exercise);

                    var progress = await addProgressiveOverload
                        .Execute(exercise.Id, exercise.Weight, exercise.Repetitions, exercise.Sets);

                    exercise.AddProgress(progress);

                    await exercisesRepository.Update(exercise);

                    return Ok(mapper.Map<ExerciseModel>(exercise));
                }
            }
            catch (Exception)
            {

                return InternalServerError();
            }

            return BadRequest();
        }
    }
}