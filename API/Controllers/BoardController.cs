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
                UserInBoard exsitingUser = await context.UserInBoards.FirstOrDefaultAsync(u => u.UserId == userId && u.BoardId == boardId);

                if (exsitingUser == null)
                {
                    var userInBoard = new UserInBoard() { UserId = userId, BoardId = boardId};
                    await context.UserInBoards.AddAsync(userInBoard);
                    await context.SaveChangesAsync();
                }
                else
                { 
                    await context.Database.CloseConnectionAsync();
                    return BadRequest("Пользователь уже добавлен на доску");
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

                foreach (string role in roles)
                {
                    BoardRole boardRole = new BoardRole() {Name = role, BoardId = boardId };
                    boardRoles.Add(boardRole);
                }

                await context.Roles.AddRangeAsync(boardRoles);
                await context.SaveChangesAsync();

                return Ok(boardRoles);
            }            
        }

        [HttpGet("{boardId}/GetUsersInBoard")]
        public async Task<ActionResult<List<UserInBoard>>> GetUsersInBoard([FromRoute] int boardId)
        {
            List<UserInBoard> boardMembers = new List<UserInBoard>();

            using (AppDbContext context = new AppDbContext())
            {
                boardMembers = await context.UserInBoards.Include(u => u.User)
                                                         .Include(u => u.BoardRole)
                                                         .Where(u => u.BoardId == boardId)
                                                         .ToListAsync();
            }
            foreach (UserInBoard user in boardMembers)
            {
                user.User.PasswordSalt = null;
                user.User.PasswordHash = null;
                user.User.Login = null;

            }

            return Ok(boardMembers);
        }

        [HttpGet("{userId}/GetBoardsByUser")]
        public async Task<ActionResult<List<Board>>> GetBoardsByUser(int userId)
        {
            List<Board> boards = new List<Board>();
            using (AppDbContext context = new AppDbContext()) 
            {
               boards = await context.UserInBoards.Where(u => u.UserId == userId)
                                              .Select(b => b.Board)
                                              .ToListAsync();

            }

            return Ok(boards);
        }

        [HttpGet("{boardId}/GetRoles")]
        public async Task<ActionResult<List<BoardRole>>> GetRoles(int boardId)
        {
            List<BoardRole> roles;
            using (AppDbContext context = new AppDbContext())
            {              
                roles = await context.Roles.Where(r => r.BoardId == boardId).ToListAsync();
            }

            return Ok(roles);
        }

        [HttpPost("{boardId}/AddRole")]
        public async Task<ActionResult<List<BoardRole>>> AddRole(BoardRole role, int boardId)
        {
            List<BoardRole> roles;
            using (AppDbContext context = new AppDbContext())
            {
                context.Roles.Add(role);
                context.SaveChanges();
                roles = await context.Roles.Where(r => r.BoardId == boardId).ToListAsync();
            }
            return Ok(roles);
        }

        [HttpGet("{boardId}/{userInBoardId}/GiveRole/{boardRoleId}")]
        public async Task<ActionResult<List<UserInBoard>>> GiveRole(int boardId, int userInBoardId, int boardRoleId )
        { 
            List<UserInBoard> users;
            using(AppDbContext context = new AppDbContext())
            {
                var UserInBoard = await context.UserInBoards.FindAsync(userInBoardId);
                UserInBoard.RoleId = boardRoleId;
                context.SaveChanges();

                users = await context.UserInBoards.Include(u => u.User)
                                                  .Include(u => u.BoardRole)
                                                  .Where(u => u.BoardId == boardId)
                                                  .ToListAsync();
                foreach (var user in users) 
                {
                    user.User.PasswordHash = null;
                    user.User.PasswordSalt = null;
                    user.User.Login = null;
                }
            }
            return Ok(users);
        }

    }
}
