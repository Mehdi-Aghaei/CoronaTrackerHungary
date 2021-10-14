using Microsoft.Extensions.Logging;
using System;

namespace CoronaTrackerHungary.Web.Api.Brokers.Logging
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;
        public LoggingBroker(ILogger<LoggingBroker> logger)=>
            this.logger = logger;
        
        public void LogCritical(Exception exception)=>
            this.logger.LogCritical(exception,exception.Message);

        public void LogDebug(string message) =>
            this.logger.LogDebug(message);

        public void LogEror(Exception exception) =>
            this.logger.LogError(exception, exception.Message);

        public void LogInformation(string message) =>
            this.logger.LogInformation(message);

        public void LogTrace(string message) =>
            this.logger.LogTrace(message);

        public void LogWarning(string message) =>
            this.logger.LogWarning(message);
        
        }
}
