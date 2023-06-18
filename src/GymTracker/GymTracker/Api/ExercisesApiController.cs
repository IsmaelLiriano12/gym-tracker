using AutoMapper;
using GymTrackerShared.ApiModels;
using GymTrackerShared.Data;
using GymTrackerShared.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static GymTrackerShared.Models.Routine;

namespace GymTracker.Api
{
    [RoutePrefix("api/exercises")]
    public class ExercisesApiController : ApiController
    {
        private readonly IExercisesStatsRepository repository;
        private readonly IProgressiveOverloadRepository pogressiveOverloadRepository;
        private readonly IRoutinesRepository routinesRepository;
        private readonly IMapper mapper;

        public ExercisesApiController
            (IExercisesStatsRepository repository, 
            IProgressiveOverloadRepository pogressiveOverloadRepository,
            IRoutinesRepository routinesRepository,
            IMapper mapper)
        {
            this.repository = repository;
            this.pogressiveOverloadRepository = pogressiveOverloadRepository;
            this.routinesRepository = routinesRepository;
            this.mapper = mapper;
        }

        [Route("{id:int}", Name = "GetExercise")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var result = await repository.GetAsync(id);
                if (result == null) return NotFound();

                var mappedResult = mapper.Map<ExerciseStats, ExerciseStatsModel>(result);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [Route()]
        public async Task<IHttpActionResult> Post([FromBody] ExerciseInfoModel exerciseInfoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var routine = await routinesRepository.GetAsync(User.Identity.GetUserId(), false);

                    var exerciseStats = new ExerciseStats()
                    {
                        ExerciseBaseId = exerciseInfoModel.ExerciseBaseId,
                        RoutineId = routine.Id,
                        Name = exerciseInfoModel.Name,
                        Weight = 0,
                        Repetitions = 0,
                        Sets = 0,
                        DayOfTraining = exerciseInfoModel.TrainingDay
                    };

                    repository.Add(exerciseStats);

                    await repository.SaveChangesAsync();

                    var progress = await pogressiveOverloadRepository.AddAndSaveAsync(exerciseStats);

                    //exerciseStats.AddProgress(progress);

                    
                    var newModel = mapper.Map<ExerciseStats, ExerciseStatsModel>(exerciseStats);

                    return CreatedAtRoute("GetExercise", new { routineId = exerciseStats.RoutineId, id = exerciseStats.Id }, newModel);
                    
                }
                
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return BadRequest();
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]ExerciseStatsModel model)
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
                        return Ok(mapper.Map<ExerciseStatsModel>(exercise));
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