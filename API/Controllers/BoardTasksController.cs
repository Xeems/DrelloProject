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
            task.ExecutorUserId = null;
            using (AppDbContext context = new AppDbContext())
            {
                await context.ATasks.AddAsync(task);
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
                tasks = await context.ATasks.Include(t => t.RequiredRole)
                                            .Include(t => t.ExecutorUser)
                                            .Where(t => t.BoardId == BoardId)
                                            .ToListAsync();
            }
            return Ok(tasks);
        }

        [HttpGet("{TaskId}/TakeTask/{ExecutorId}")]
        public async Task<ActionResult<ATask>> TakeTask(int TaskId, int ExecutorId)
        {
            ATask task = new ATask();
            try
            {
                using (AppDbContext context = new())
                {
                    task = await context.ATasks.FirstOrDefaultAsync(t => t.Id == TaskId);
                    task.ExecutorUserId = ExecutorId;
                    task.Status += 1;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            { 
                return BadRequest(ex); 
            }
            return Ok();
        }
    }
}
