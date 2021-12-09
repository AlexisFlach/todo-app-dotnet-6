using Todoapp.Data;
using Todoapp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Todoapp.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApiDbContext _context;

        public TodoRepository(ApiDbContext ctx)
        {
            _context = ctx;
        }

        public async Task CreateTodo(Todo data)
        {
            await _context.Todos.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> GetTodo(int id) => await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await _context.Todos.ToListAsync();

        }

        public async Task UpdateTodo(Todo data)
        {
            var todo = await this.GetTodo(data.Id);
            _context.Entry(todo).CurrentValues.SetValues(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodo(int id)
        {
            var existingTodo = await _context.Todos.SingleOrDefaultAsync(x => x.Id == id);
            _context.Todos.Remove(existingTodo);
            await _context.SaveChangesAsync();
        }
    }
}