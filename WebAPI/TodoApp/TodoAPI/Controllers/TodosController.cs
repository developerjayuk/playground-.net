using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoLibrary.DataAccess;
using TodoLibrary.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoData _data;

        public TodosController(ITodoData data)
        {
            _data = data;
        }

        private int GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userId);
        }

        // GET: api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> Get()
        {

            // TODO: update to check userid is valid
            var todos = await _data.GetAllAssigned(GetUserId());

            return Ok(todos);
        }

        // GET api/todos/5
        [HttpGet("{todoId}")]
        public async Task<ActionResult<TodoModel>> Get(int todoId)
        {
            var todo = await _data.GetOneAssigned(GetUserId(), todoId);
        
            return Ok(todo);
        }


        // POST api/todos
        [HttpPost]
        public async Task<ActionResult<TodoModel>> Post([FromBody] string task)
        {
            var todo = await _data.Create(GetUserId(), task);

            return Ok(todo);
        }

        // PUT api/todos/5
        [HttpPut("{todoId}")]
        public async Task<ActionResult> Put(int todoId, [FromBody] string task)
        {
            await _data.UpdateTask(GetUserId(), todoId, task);
            return NoContent();
        }

        // PUT api/todos/5/complete
        [HttpPut("{todoId}/complete")]
        public async Task<ActionResult> Complete(int todoId)
        {
            await _data.CompleteTodo(GetUserId(), todoId);
            return NoContent();
        }

        // DELETE api/todos/5
        [HttpDelete("{todoId}")]
        public async Task<ActionResult> Delete(int todoId)
        {
            await _data.Delete(GetUserId(), todoId);
            return NoContent();
        }
    }
}
