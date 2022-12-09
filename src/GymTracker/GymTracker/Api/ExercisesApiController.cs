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
        private readonly IExercisesRepository repository;
        private readonly IPogressiveOverloadRepository pogressiveOverloadRepository;
        private readonly IMapper mapper;

        public ExercisesApiController
            (IExercisesRepository repository, 
            IPogressiveOverloadRepository pogressiveOverloadRepository,
            IMapper mapper)
        {
            this.repository = repository;
            this.pogressiveOverloadRepository = pogressiveOverloadRepository;
            this.mapper = mapper;
        }

        [Route("{id:int}", Name = "GetExercise")]
        public async Task<IHttpActionResult> Get(int routineId, int id)
        {
            try
            {
                var result = await repository.GetAsync(id);
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

                    mappedResult.RoutineId = routineId;

                    repository.Add(mappedResult);

                    var progress = await pogressiveOverloadRepository.AddAndSaveAsync(mappedResult);

                    mappedResult.AddProgress(progress);

                    if (await repository.SaveChangesAsync())
                    {
                        var newModel = mapper.Map<Exercise, ExerciseModel>(mappedResult);

                        return CreatedAtRoute("GetExercise", new { routineId = mappedResult.RoutineId, id = mappedResult.Id }, newModel);
                    }
                }
                
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return BadRequest();
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int routineId, int id, [FromBody]ExerciseModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var exercise = await repository.GetAsync(id);
                    if (exercise == null) return NotFound();

                    mapper.Map(model, exercise);

                    var progress = await pogressiveOverloadRepository.AddAndSaveAsync(exercise);

                    exercise.AddProgress(progress);

                    repository.Update(exercise);

                    if (await repository.SaveChangesAsync())
                    {
                        return Ok(mapper.Map<ExerciseModel>(exercise));
                    }
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