using Microservice.Categories.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Categories.WebAPI.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
