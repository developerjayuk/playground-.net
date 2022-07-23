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
        private readonly ILogger<TodosController> _logger;

        public TodosController(ITodoData data, ILogger<TodosController> logger)
        {
            _data = data;
            _logger = logger;
        }

        private int GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return userId is null ? 0 : int.Parse(userId);
        }

        private string GetRequestInfo(HttpRequest request, int? userId)
        {
            return $"{request.Method} {request.Path} for UserId:{userId}";
        }

        // GET: api/todos
        [HttpGet(Name = "GetAllTodos")]
        public async Task<ActionResult<IEnumerable<TodoModel>>> Get()
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest();
            }

            var requestInfo = GetRequestInfo(Request, userId);
            _logger.LogInformation("{requestInfo} request", requestInfo);

            try
            {
                var todos = await _data.GetAllAssigned(userId);
                return Ok(todos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{requestInfo} failed", requestInfo);
                return BadRequest();
            }
        }

        // GET api/todos/5
        [HttpGet("{todoId}", Name = "GetOneTodo")]
        public async Task<ActionResult<TodoModel>> Get(int todoId)
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest(); 
            }

            var requestInfo = GetRequestInfo(Request, userId);
            _logger.LogInformation("{requestInfo} request", requestInfo);

            try
            {
                var todo = await _data.GetOneAssigned(userId, todoId);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{requestInfo} failed for {todoId}", requestInfo, todoId);
                return BadRequest();
            }

        }

        // POST api/todos
        [HttpPost(Name = "CreateTodo")]
        public async Task<ActionResult<TodoModel>> Post([FromBody] string task)
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest();
            }

            var requestInfo = GetRequestInfo(Request, userId);
            _logger.LogInformation("{requestInfo} request", requestInfo);

            try
            {
                var todo = await _data.Create(userId, task);
                return Ok(todo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{requestInfo} failed with {task}", requestInfo, task);
                return BadRequest();
            }
        }

        // PUT api/todos/5
        [HttpPut("{todoId}", Name = "UpdateTodo")]
        public async Task<ActionResult> Put(int todoId, [FromBody] string task)
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest();
            }

            var requestInfo = GetRequestInfo(Request, userId);
            _logger.LogInformation("{requestInfo} request", requestInfo);

            try
            {
                await _data.UpdateTask(userId, todoId, task);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{requestInfo} failed for {todoId} with {task}",
                    requestInfo, todoId, task);
                return BadRequest();
            }
        }

        // PUT api/todos/5/complete
        [HttpPut("{todoId}/complete", Name = "CompleteTodo")]
        public async Task<ActionResult> Complete(int todoId)
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest();
            }

            var requestInfo = GetRequestInfo(Request, userId);
            _logger.LogInformation("{requestInfo} request", requestInfo);

            try
            {
                await _data.CompleteTodo(userId, todoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{requestInfo} failed for {todoId}",
                    requestInfo, todoId);
                return BadRequest();
            }

        }

        // DELETE api/todos/5
        [HttpDelete("{todoId}", Name = "DeleteTodo")]
        public async Task<ActionResult> Delete(int todoId)
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest();
            }
            
            var requestInfo = GetRequestInfo(Request, userId);
            _logger.LogInformation("{requestInfo} request", requestInfo);

            try
            {
                await _data.Delete(userId, todoId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{requestInfo} failed for {todoId}",
                    requestInfo, todoId);
                return BadRequest();
            }
        }
    }
}
