using API.Models;
using DrelloApi;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("API/User/")]
    [ApiController]
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetBoards")]
        public async Task<ActionResult<List<Board>>> GetBoards(int userId)
        {
            List<Board> boards = null;

            return Ok(boards);
        }

        [HttpGet("{userId}/GetPersonalTasks")]
        public async Task<ActionResult<List<PersonalTask>>> GetPersonalTasks([FromRoute]int userId)
        {
            List<PersonalTask> tasks = null;

            using(AppDbContext context = new AppDbContext())
            {
                tasks = context.PersonalTasks.Where(u => u.PersonalTaskOwnerId == userId).ToList();
            }

            return Ok(tasks);
        }

        [HttpPost("{userId}/AddPersonalTask")]
        public async Task<ActionResult<bool>> AddPersonalTasks([FromRoute] int userId, PersonalTask task)
        {
            task.PersonalTaskOwnerId = userId;

            try 
            {
                using (AppDbContext context = new AppDbContext())
                {
                    await context.PersonalTasks.AddAsync(task); 
                    await context.SaveChangesAsync();
                }
                return Ok(true);
            }
            catch (Exception ex) 
            { return BadRequest(false); }           
        }

        [HttpDelete("DeletePersonalTask/{taskId}")]
        public async Task<ActionResult<bool>> DeletePersonalTasks([FromRoute] int taskId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    PersonalTask task = context.PersonalTasks.Find(taskId);
                    context.PersonalTasks.Remove(task);
                    await context.SaveChangesAsync();
                }
                return Ok(true);
            }
            catch (Exception ex)
            { return BadRequest(false); }
        }
    }
}
