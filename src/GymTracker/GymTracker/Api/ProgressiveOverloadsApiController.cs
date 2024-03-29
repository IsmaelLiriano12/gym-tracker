﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using GymTrackerShared.Data;

namespace GymTracker.Api
{
    [RoutePrefix("api/exercises/{exerciseId}/progresses")]
    public class ProgressiveOverloadsApiController : ApiController
    {
        private readonly IProgressiveOverloadRepository repository;

        public ProgressiveOverloadsApiController(IProgressiveOverloadRepository repository)
        {
            this.repository = repository;
        }

        [Route()]
        public async Task<IHttpActionResult> Get(int exerciseId)
        {
            try
            {
                var result = await repository.GetProgressiveOverloads(exerciseId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
