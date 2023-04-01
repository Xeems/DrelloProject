using API.Models;
using DrelloApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("API/Tasks/")]
    [ApiController]
    public class BoardTasksController : Controller
    {
        private IConfiguration _configuration;
        public BoardTasksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("AddTask")]
        public async Task<ActionResult<ATask>> AddTask(ATask atask)
        {
            ATask task = atask;

            using (AppDbContext context = new AppDbContext())
            {
                await context.AddAsync(task);
                await context.SaveChangesAsync();
            }

            return Ok(task);
        }

        [HttpGet("GetTasks/{BoardId}")]
        public async Task<ActionResult<List<Task>>> GetTasks(int BoardId)
        {
            List<ATask> tasks;
            using (AppDbContext context = new AppDbContext())
            {
               tasks = context.ATasks.Where(t => t.BoardId == BoardId)
                                     .Select(t => new ATask { t.Id, t.Name, t.RequiredRole, t.BoardId})
                                     .ToList();
            }
            return Ok(tasks);
        }
    }
}
