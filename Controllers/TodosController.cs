using Microsoft.AspNetCore.Mvc;
using Todoapp.Entities;
using Todoapp.Repositories;

namespace Todoapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TodosController : ControllerBase
    {

        public readonly ITodoRepository _repo;

        public TodosController(ITodoRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _repo.GetTodos();

            return Ok(todos);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetTodo(int id)
        {
            var item = await _repo.GetTodo(id);
            if (item is null)
                return NotFound();
            return Ok(item);
        }
        [HttpPost]

        public async Task<IActionResult> CreateTodo(Todo data)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Something went wrong") { StatusCode = 500 };
            }

            await _repo.CreateTodo(data);

            return CreatedAtAction("GetTodo", new { data.Id }, data);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateTodo(int id, Todo todo)
        {

            var existingItem = await _repo.GetTodo(id);
            if (existingItem is null)
                return NotFound();
            existingItem.Title = todo.Title;
            existingItem.Description = todo.Description;
            existingItem.IsDone = todo.IsDone;

            await _repo.UpdateTodo(existingItem);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var existingTodo = await GetTodo(id);

            if (existingTodo is null)
                return NotFound();

            await _repo.DeleteTodo(id);
            return Ok(existingTodo);
        }

    }
}