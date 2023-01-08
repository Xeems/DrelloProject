using DrelloAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();



app.Run();