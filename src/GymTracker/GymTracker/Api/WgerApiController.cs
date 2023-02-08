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

        public WgerApiController(IWgerService service)
        {
            this.service = service;
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
        public async Task<IHttpActionResult> GetExerciseBaseInfoSugegstions(string name)
        {
            try
            {
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
    }
}
