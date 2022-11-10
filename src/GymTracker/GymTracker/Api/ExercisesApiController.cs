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
    [RoutePrefix("api/routines/{routineId}/exercises")]
    public class ExercisesApiController : ApiController
    {
        private readonly IExercisesRepository exercisesRepository;
        private readonly AddProgressiveOverload addProgressiveOverload;
        private readonly IMapper mapper;

        public ExercisesApiController
            (IExercisesRepository exercisesRepository, 
            AddProgressiveOverload addProgressiveOverload, 
            IMapper mapper)
        {
            this.exercisesRepository = exercisesRepository;
            this.addProgressiveOverload = addProgressiveOverload;
            this.mapper = mapper;
        }

        [Route("{id:int}", Name = "GetExercise")]
        public async Task<IHttpActionResult> Get(int routineId, int id)
        {
            try
            {
                var result = await exercisesRepository.GetAsync(id);
                if (result == null) return NotFound();

                var mappedResult = mapper.Map<Exercise, ExerciseModel>(result);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [Route()]
        public async Task<IHttpActionResult> Post(int routineId, [FromBody]ExerciseModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mappedResult = mapper.Map<ExerciseModel, Exercise>(model);

                    exercisesRepository.Add(mappedResult);

                    var progress = await addProgressiveOverload
                           .Execute(mappedResult.Id, mappedResult.Weight, mappedResult.Repetitions, mappedResult.Sets);

                    mappedResult.AddProgress(progress);

                    if (await exercisesRepository.SaveChangesAsync() == false)
                    {
                        return BadRequest();
                    }

                    var newModel = mapper.Map<Exercise, ExerciseModel>(mappedResult);

                    return CreatedAtRoute("GetExercise", new { routineId = newModel.RoutineId, id = mappedResult.Id }, newModel);
                }
                else
                {
                    return BadRequest(ModelState);
                }
                
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int routineId, int id, [FromBody]ExerciseModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exercise = await exercisesRepository.GetAsync(id);
                    if (exercise == null) return NotFound();

                    mapper.Map(model, exercise);

                    var progress = await addProgressiveOverload
                        .Execute(exercise.Id, exercise.Weight, exercise.Repetitions, exercise.Sets);

                    exercise.AddProgress(progress);

                    exercisesRepository.Update(exercise);

                    if (await exercisesRepository.SaveChangesAsync() == false)
                    {
                        return BadRequest();
                    }

                    return Ok(mapper.Map<ExerciseModel>(exercise));
                }
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }

            return BadRequest();
        }
    }
}