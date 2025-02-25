using Microservice.Todos.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Todos.WebAPI.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
