using CoronaTrackerHungary.Web.Api.Brokers.APIs;
using CoronaTrackerHungary.Web.Api.Brokers.Loggings;
using CoronaTrackerHungary.Web.Api.Brokers.Storages;
using CoronaTrackerHungary.Web.Api.Services.Foundations.Countries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddHttpClient();
builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());
builder.Services.AddDbContext<StorageBroker>();
// BROKERS
builder.Services.AddTransient<IApiBroker, ApiBroker>();
builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
// SERVICES
builder.Services.AddTransient<ICountryService, CountryService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
