using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.DataServices
{
    class BoardService : IBoardsService
    {
        public User user;
        BoardService(User user) 
        {
            this.user = user; 
        }

        public string GetBoardBody(int BoardId)
        {
            throw new NotImplementedException();
        }

        public ICollection<KanBoard> GetBoards()
        {
           return new List<KanBoard>() 
           {
                 new KanBoard { Id = 1, Creator = user, Description = "Описание подлиннее для проверки многострочности", Name = "Название досик" },
                 new KanBoard { Id = 1, Creator = user, Description = "Описание подлиннее для проверки многострочности", Name = "Название досик" }
           };
        }
    }
}
