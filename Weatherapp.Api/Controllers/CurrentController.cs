using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weatherapp.Application.Common;
using Weatherapp.Application.Current.Queries;
using Weatherapp.Domain.Entities.CurrentModel;
using MediatR;

namespace Weatherapp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<GetCurrentWeatherQuery>>> Get()
        {
            var result = await _mediator.Send(new GetCurrentWeatherQuery());
            return StatusCode(result.StatusCode, result);
        }
    }
}
