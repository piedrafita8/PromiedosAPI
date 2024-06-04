using PromiedosApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using PromiedosApi.Application.Interfaces;
using PromiedosApi.Application.Services;
using PromiedosApi.Domain.Interfaces;
using PromiedosApi.Infrastructure.Repositories;
using PromiedosApi.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PromiedosContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application services
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();
builder.Services.AddScoped<IStadiumService, StadiumService>();

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