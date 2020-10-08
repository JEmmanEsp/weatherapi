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
    public class CurrentWeatherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrentWeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{location}/{units}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response<GetCurrentWeatherQuery>>> Get(string location, string units)
        {
            var result = await _mediator.Send(new GetCurrentWeatherQuery(location, units));
            return StatusCode(result.StatusCode, result);
        }
    }
}
