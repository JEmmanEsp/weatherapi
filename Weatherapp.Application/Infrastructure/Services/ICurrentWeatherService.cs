using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weatherapp.Domain.Entities.CurrentModel;

namespace Weatherapp.Application.Infrastructure.Services
{
    public interface ICurrentWeatherService
    {
        Task<CurrentResponse> GetCurrent(string location, string units);
    }
}
