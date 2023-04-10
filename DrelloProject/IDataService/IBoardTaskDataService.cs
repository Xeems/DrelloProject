using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.IDataService
{
    public interface IBoardTaskDataService
    {
        public Task<ObservableCollection<ATask>> GetTasks(int BoardId);
        public Task<bool> NewTask(ATask aTask);
    }
}
