using AutoMapper;
using GymTracker.ApiModels;
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
    [RoutePrefix("api/routines")]
    public class RoutinesApiController : ApiController
    {
        private readonly IRoutinesRepository repository;
        private readonly IMapper mapper;

        public RoutinesApiController(IRoutinesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await repository.GetRoutinesAsync(includeExercises: false);

                if (result == null) return NotFound();

                var mappedResult = mapper.Map<IEnumerable<RoutineModel>>(result);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("{id:int}", Name ="GetRoutine")]
        public async Task<IHttpActionResult> Get(int id, bool includeExercises = false)
        {
            try
            {
                var result = await repository.GetAsync(id, includeExercises);
                if (result == null) return NotFound();

                var mappedResult = mapper.Map<RoutineModel>(result);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route()]
        public async Task<IHttpActionResult> Post([FromBody]RoutineModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mappedResult = mapper.Map<RoutineModel, Routine>(model);

                    repository.Add(mappedResult);

                    if (await repository.SaveChangesAsync() == false)
                    {
                        return BadRequest();
                    }

                    var newModel = mapper.Map<RoutineModel>(mappedResult);

                    return CreatedAtRoute("GetRoutine", new { id = newModel.Id }, newModel);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return BadRequest();
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]RoutineModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await repository.GetAsync(id, false);
                    if (result == null) return NotFound();

                    mapper.Map(model, result);

                    repository.Update(result);

                    if (await repository.SaveChangesAsync() == false)
                    {
                        return BadRequest();
                    }

                    return Ok(mapper.Map<RoutineModel>(result));
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return BadRequest();
        }
    }
}