using Microsoft.EntityFrameworkCore;
using Todoapp.Entities;

namespace Todoapp.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Todo> Todos { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> opt) : base(opt)
        {

        }
    }
}