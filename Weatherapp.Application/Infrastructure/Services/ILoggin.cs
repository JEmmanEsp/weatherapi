using System;
using System.Collections.Generic;
using System.Text;

namespace Weatherapp.Application.Infrastructure.Services
{
    public interface ILoggin
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
