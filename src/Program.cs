using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using src.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Connect = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<DbConnect>(options => options.UseMySql(
    Connect,
    ServerVersion.AutoDetect(Connect)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
