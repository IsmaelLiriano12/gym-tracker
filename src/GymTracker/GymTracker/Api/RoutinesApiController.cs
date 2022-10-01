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
                var result = await repository.GetList(includeExercises: false);

                if (result == null) return NotFound();

                var mappedResult = mapper.Map<IEnumerable<RoutineModel>>(result);

                return Ok(mappedResult);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}