using System;
using System.Collections.Generic;
using System.Text;
using Weatherapp.Application.Infrastructure.Services;
using NLog;

namespace Weatherapp.Infrastructure.Services
{
    public class Loggin : ILoggin
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
