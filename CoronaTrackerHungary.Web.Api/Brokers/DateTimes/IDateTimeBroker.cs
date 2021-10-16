using System;

namespace CoronaTrackerHungary.Web.Api.Brokers.DateTimes
{
    public interface IDateTimeBroker{
        DateTimeOffset GetCurrentDateTime();
    }

}