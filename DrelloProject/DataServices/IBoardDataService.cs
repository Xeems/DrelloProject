using DrelloProject.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.DataServices
{
    public interface IBoardDataService
    {
        Task<ICollection<Board>> GetBoardsByUser(int UserId);
        Task<Board> AddBoard(Board board);
        Task<BoardRole> AddBoardRoles(ICollection<BoardRole> boardRoles, Board board);
        Task<ObservableCollection<UserInBoard>> GetUsersInBoard(int BoardId);
        Task<Board> GetBoard(int id);
    }
}
