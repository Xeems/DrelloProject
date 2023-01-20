using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.DataServices
{
    internal interface IATaskService
    {
        public ICollection<ATask> GetTasksForBoard(int boardId);
    }
}
