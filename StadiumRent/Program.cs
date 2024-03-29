using Microsoft.EntityFrameworkCore;
using StadiumRent.BLL.Implementations;
using StadiumRent.BLL.Interfaces;
using StadiumRent.DAL;
using StadiumRent.DAL.Interfaces;
using StadiumRent.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("MEMORY"));
builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();
builder.Services.AddScoped<IStadiumServices, StadiumService>();

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
