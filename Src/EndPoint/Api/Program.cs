using Application.Interfaces;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Polly;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetSection("ConnectionString:MySqlConnectionString").Value; 
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseMySQL(connectionString);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFlightsService, FlightsService>();
builder.Services.AddScoped<IAirportsService, AirportsService>();

builder.Services.AddHttpClient("Aviationstack", client =>
{
    client.BaseAddress = new Uri("http://api.aviationstack.com/v1/");
})
.AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
{
    TimeSpan.FromSeconds(1),
    TimeSpan.FromSeconds(5),
    TimeSpan.FromSeconds(10)
}));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Features.Airport.Command.GetAirportsCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Features.Flight.Command.GetFlightsCommand).Assembly));


var app = builder.Build();


using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ProjectContext>();
    await dbContext.Database.MigrateAsync();
}



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
