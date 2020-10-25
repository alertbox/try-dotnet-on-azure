using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Management.Todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private static readonly IList<TodoItem> Store = new List<TodoItem>(CreateTodos());

        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TodoItem> Get(string q = "")
        {
            return string.IsNullOrWhiteSpace(q) ? Store : Store.Where((item) => item.Title.Contains(q, StringComparison.InvariantCultureIgnoreCase));
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            IEnumerable<TodoItem> result = Store.Where((item) => item.Id == id);
            return result.Any() ? Ok(result) : NotFound(new { id });
        }

        [HttpPost]
        public CreatedResult Create(TodoItem item)
        {
            item.Id = Store.Last().Id + 1;
            Store.Add(item);
            return Created($"todos/id/{item.Id}", item);
        }

        [HttpPut("id/{id}")]
        public void Update([FromRoute]int id, [FromBody]TodoItem todo)
        {
            Store.Single((item) => item.Id == id).Title = todo.Title;
        }

        [HttpDelete("id/{id}")]
        public void Delete([FromRoute]int id)
        {
            Store.Single((item) => item.Id == id).Completed = true;
        }

        private static IEnumerable<TodoItem> CreateTodos()
        {
            string[] Summaries = new[]
            {
                "Feed the fish", "Eat the tweet", "Chew the gum", "Song a sing", "Talk the walk", "Nice the mice", "Foo the bar", "Face the book", "Dung the gram", "Choak the chicken"
            };
            Random rng = new Random();

            return Enumerable.Range(1, 10).Select(index => new TodoItem
            {
                Id = index,
                Title = Summaries[rng.Next(Summaries.Length)],
                Completed = rng.Next(-20, 55) % 2 == 0
            })
            .ToArray();
        }
    }
}
