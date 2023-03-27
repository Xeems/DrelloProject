using API.Models;
using DrelloApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("API/Boards/")]
    [ApiController]
    public class BoardController : Controller
    {
        public static User user = new User();
        public static Board board = new Board();
        private IConfiguration _configuration;

        public BoardController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Board>> Create(Board board)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    await context.Boards.AddAsync(board);
                    await context.SaveChangesAsync();
                }

                return Ok(board);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }                           
        }

        [HttpGet("{boardId}/AddUserToBoard/{userId}")]
        public async Task<ActionResult<UserInBoard>> AddUserToBoard(int userId, int boardId)
        {

            using (AppDbContext context = new AppDbContext())
            {
                var user = await context.Users.FindAsync(userId);
                var board = await context.Boards.FindAsync(boardId);
                if (board != null && user != null)
                {
                    var userInBoard = new UserInBoard() { User = user, Board = board};
                    await context.UserInBoards.AddAsync(userInBoard);
                    await context.SaveChangesAsync();
                }
                else
                { 
                    await context.Database.CloseConnectionAsync();
                    return BadRequest();
                }
            }

            return Ok();
        }

        [HttpPost("{boardId}/AddRoles")]
        public async Task<ActionResult<BoardRole>> AddRoles(ICollection<string> roles, [FromRoute]int boardId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                List<BoardRole> boardRoles = new List<BoardRole>();
                board = await context.Boards.FindAsync(boardId);

                foreach (string role in roles)
                {
                    BoardRole boardRole = new BoardRole() {Name = role, Board = board };
                    boardRoles.Add(boardRole);
                }

                await context.Roles.AddRangeAsync(boardRoles);
                await context.SaveChangesAsync();

                return Ok(boardRoles);
            }            
        }

        [HttpGet("{boardId}/GetBoardMembers")]
        public async Task<ActionResult<List<UserInBoard>>> GetBoardMembers([FromRoute] int boardId)
        {
            List<UserInBoard> boardMembers = null;

            using (AppDbContext context = new AppDbContext())
            {

            }

            return Ok(boardMembers);
        }

        [HttpGet("{userId}/GetBoardsByUser")]
        public async Task<ActionResult<List<Board>>> GetBoards(int userId)
        {
            List<Board> boards = null;
            using (AppDbContext context = new AppDbContext()) 
            {
                boards = await context.Boards.Where(u => u. == userId).ToList();
            }

            return Ok(boards);
        }

    }
}
