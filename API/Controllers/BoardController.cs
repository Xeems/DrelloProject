using API.Models;
using DrelloApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("API/Boards/")]
    [ApiController]
    public class BoardController : Controller
    {
        public static User user = new User();
        public static KanBoard board = new KanBoard();
        private IConfiguration _configuration;

        public BoardController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<KanBoard>> Create(KanBoard request, int creatorId)
        {
            var board = request;
            board.CreatorId = creatorId;

            using (AppDbContext context = new AppDbContext())
            {
                await context.Boards.AddAsync(board);
                await context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<KanBoard>> AddUser(int boardId, User user)
        {

            using (AppDbContext context = new AppDbContext())
            {
                var board = await context.Boards.FindAsync(boardId);
                if (board != null)
                {
                    board.Members.Add(user);
                    await context.SaveChangesAsync();
                }
                else
                    return BadRequest();
            }

            return Ok();
        }



    }
}
