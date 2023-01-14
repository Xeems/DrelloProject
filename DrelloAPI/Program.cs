using DrelloAPI.Data;
using DrelloAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("drello/API/Users/{Login}-{Password}", async (AppDBContext context,string Login, string Password) => 
{
    var items = await context.Users.Where(u => u.Login == Login)
                                   .Where(u => u.Password == Password)
                                   .FirstOrDefaultAsync();

    return Results.Ok(items);
});

app.MapPost("drello/API/Users", async (AppDBContext context, User user) =>
{
    await context.Users.AddAsync(user);
    await context.SaveChangesAsync();

    return Results.Created($"drello/API/Users{user.Id}", user);
});

app.MapPut("drello/API/Users/{id}", async (AppDBContext context,int id, User user) =>
{
    var UserModel = await context.Users.FirstOrDefaultAsync(t =>t.Id== id);
    if (UserModel == null)
    { 
        return Results.NotFound(); 
    }      

    user.Id = id;
    UserModel.Name = user.Name;
    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("drello/API/Users/{id}", async (AppDBContext context, int id) =>
{
    var UserModel = await context.Users.FirstOrDefaultAsync(t => t.Id == id);
    if (UserModel == null)
    {
        return Results.NotFound();
    }

    context.Users.Remove(UserModel);
    await context.SaveChangesAsync();

    return Results.NoContent();
});

//https://localhost:7113
//http://localhost:5115
app.Run();