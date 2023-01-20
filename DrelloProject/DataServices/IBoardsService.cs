using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.DataServices
{
    public interface IBoardsService
    {
        public ICollection<KanBoard> GetBoards();
        public string GetBoardBody(int BoardId);
    }
}
