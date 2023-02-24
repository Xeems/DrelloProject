﻿using DrelloProject.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
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
        Task<Board> GetBoard(int id);
    }
}
