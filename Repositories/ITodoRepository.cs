using Todoapp.Entities;

namespace Todoapp.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodos();

        Task<Todo> GetTodo(int id);

        Task CreateTodo(Todo todo);

        Task UpdateTodo(Todo todo);

        Task DeleteTodo(int id);
    }
}