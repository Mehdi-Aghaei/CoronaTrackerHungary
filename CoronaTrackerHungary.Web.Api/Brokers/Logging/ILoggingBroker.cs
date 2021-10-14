﻿using System;

namespace CoronaTrackerHungary.Web.Api.Brokers.Logging
{
    public interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogTrace(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogEror(Exception exception);
        void LogCritical(Exception exception );

    }
}