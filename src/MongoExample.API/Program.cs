using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Options;
using MongoExample.API.Presenters;
using MongoExample.Core.Boundaries;
using MongoExample.Core.Boundaries.DataAccess;
using MongoExample.Core.Boundaries.UseCases.CreateCar;
using MongoExample.Core.UseCases;
using MongoExample.Infrastructure;
using MongoExample.Infrastructure.DataAccess;
using MongoExample.Infrastructure.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton(p => p.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddTransient<MongoDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddScoped<CreateCarPresenter>();
builder.Services.AddScoped<ICreateCarOutputPort, CreateCarPresenter>(x => x.GetRequiredService<CreateCarPresenter>());

builder.Services.AddScoped<ICreateCarUseCase, CreateCarUseCase>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IDateTime, SystemDateTime>();
builder.Services.AddScoped<ICarFactory, CarFactory>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthorization();

app.MapControllers();

app.Run();
