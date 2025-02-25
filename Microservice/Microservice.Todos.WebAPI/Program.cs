using Microservice.Todos.WebAPI.Context;
using Microservice.Todos.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("MyDb");
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/todos/add", (AppDbContext context, string work) =>
{
    Todo todo = new Todo { Work = work };
    context.Todos.Add(todo);
    context.SaveChanges();
    return new {Message = "Todo added successfully" };
});

app.MapGet("/todos/getall", (AppDbContext context) =>
{
    var todos = context.Todos.ToList();
    return todos;
});

app.Run();
