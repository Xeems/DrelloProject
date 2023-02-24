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
        public async Task<ActionResult<ICollection<Board>>> GetBoards(int userId)
        {
            ICollection<Board> boards = null;

            return Ok(boards);
        }

        [HttpGet("/{userId}/GetPersonalTasks")]
        public async Task<ActionResult<ICollection<PersonalTask>>> GetPersonalTasks([FromRoute]int userId)
        {
            ICollection<PersonalTask> tasks = null;

            using(AppDbContext context = new AppDbContext())
            {
                tasks = context.PersonalTasks.Where(u => u.PersonalTaskOwnerId == userId).ToList();
            }

            return Ok(tasks);
        }
    }
}
