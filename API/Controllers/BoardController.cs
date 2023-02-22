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

        [HttpPost("AddUser")]
        public async Task<ActionResult<UserInBoard>> AddUser(int boardId, int userId, int roleId)
        {

            using (AppDbContext context = new AppDbContext())
            {
                var board = await context.Boards.FindAsync(boardId);
                var user = await context.Users.FindAsync(userId);
                var role = await context.Roles.FindAsync(roleId);
                if (board != null && user != null && role != null && board.Id == role.Id)
                {
                    var userInBoard = new UserInBoard() { User = user, BoardRole = role };
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

        [HttpPost("AddRole")]
        public async Task<ActionResult<BoardRole>> AddRole(int boardId, string roleName)
        {

            using (AppDbContext context = new AppDbContext())
            {
                var board = await context.Boards.FindAsync(boardId);

                if (board != null)
                {
                    var role = new BoardRole() { Board = board, Name = roleName};
                    await context.Roles.AddAsync(role);
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

    }
}
