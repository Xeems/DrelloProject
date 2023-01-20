using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.DataServices
{
    internal class ATaskService : IATaskService
    {
        public ICollection<ATask> GetTasksForBoard(int boardId)
        {
            return new List<ATask>() { new ATask() {Name = "Название задания", Description = "Очень длинное описание для проверки многострочности" },
                                       new ATask() {Name = "Название задания", Description = "Очень длинное описание для проверки многострочности" }};
        }
    }
}
