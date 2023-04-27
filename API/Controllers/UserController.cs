using API.Models;
using DrelloApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{userId}/GetCurrentUser")]
        public async Task<ActionResult<List<PersonalTask>>> GetCurrentUser([FromRoute] int userId)
        {
            User user = new();

            using (AppDbContext context = new AppDbContext())
            {
                user = await context.Users.FindAsync(userId);
            }

            if (user != null)
            {
                user.PasswordSalt = null;
                user.PasswordHash = null;
            }
            else
                return BadRequest();

            return Ok(user);
        }

        [HttpGet("{userId}/GetPersonalTasks")]
        public async Task<ActionResult<List<PersonalTask>>> GetPersonalTasks([FromRoute]int userId)
        {
            List<PersonalTask> tasks = null;

            using(AppDbContext context = new AppDbContext())
            {
                tasks = context.PersonalTasks.Where(u => u.UserId == userId).ToList();
            }

            return Ok(tasks);
        }

        [HttpPost("{userId}/AddPersonalTask")]
        public async Task<ActionResult<bool>> AddPersonalTasks([FromRoute] int userId, PersonalTask task)
        {
            task.UserId = userId;

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

        [HttpGet("FindUsers/{userName}")]
        public async Task<ActionResult<List<User>>> FindUsers(string userName)
        {
            List<User> users;

            using (AppDbContext context = new AppDbContext())
            {
                users = context.Users.Where(n =>EF.Functions.Like(n.UserName, $"%{userName}%"))
                                     .Select(n => new User { UserName = n.UserName, Id = n.Id })   
                                     .ToList();
            }
            return Ok(users);
        }
    }
}
