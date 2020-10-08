using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Weatherapp.Domain.Entities.CurrentModel;
using Weatherapp.Application.Common;

namespace Weatherapp.Application.Current.Queries
{
    public class GetCurrentWeatherQuery : IRequest<Response<CurrentResponse>>
    {
    }
}
