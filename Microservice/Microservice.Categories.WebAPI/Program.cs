using Microservice.Categories.WebAPI.Context;
using Microservice.Categories.WebAPI.Dto;
using Microservice.Categories.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/categories/getall", async (AppDbContext context, CancellationToken cancellationToken) =>
{
    var categories = await context.Categories.ToListAsync(cancellationToken);
    return categories;
});

app.MapPost("/categories/add", async (AppDbContext context, CreateCategoryDto request, CancellationToken cancellationToken) =>
{
    var category = new Category { Name = request.Name };
    await context.Categories.AddAsync(category, cancellationToken);
    var result = await context.SaveChangesAsync(cancellationToken);
    if (result.Equals(1))
    {
        return "Category added successfully";
    }
    return "Category could not be added";
});

app.Run();
