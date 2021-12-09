using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todoapp.Entities;

namespace Todoapp.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public virtual DbSet<Todo> Todos { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> opt) : base(opt)
        {

        }
    }
}