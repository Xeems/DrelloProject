using DrelloProject.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.IDataService
{
    public interface IBoardDataService
    {
        Task<ObservableCollection<Board>> GetBoardsByUser(int UserId);
        Task<Board> AddBoard(Board board);
        Task<BoardRole> AddBoardRoles(ICollection<BoardRole> boardRoles, Board board);
        Task<ObservableCollection<BoardRole>> AddRole(int boardId, BoardRole boardRole);
        Task<ObservableCollection<UserInBoard>> GetUsersInBoard(int BoardId);
        Task<Board> GetBoard(int Boardid);
        Task<bool> AddUserToBoard(int UserId, int BoardId);
        Task<ObservableCollection<BoardRole>> GetRoles(int BoardId);
        Task<ObservableCollection<UserInBoard>> GiveRole(int BoardId, int UserInBoardId, int RoleId);
    }
}
