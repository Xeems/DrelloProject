using API.Models;
using DrelloApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("API/Tasks")]
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
        public async Task<ActionResult<List<ATask>>> GetTasks([FromRoute]int BoardId)
        {
            List<ATask> tasks = new List<ATask>();
            using (AppDbContext context = new())
            {
                tasks = await context.ATasks.Where(t => t.BoardId == BoardId)
                                            .ToListAsync();
            }
            return Ok(tasks);
        }
    }
}
