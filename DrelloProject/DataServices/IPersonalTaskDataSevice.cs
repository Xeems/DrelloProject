using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.DataServices
{
    public interface IPersonalTaskDataSevice
    {
        Task<ObservableCollection<PersonalTask>> GetPersonalTasks(int userId);
        Task<bool> AddPesonalTask(PersonalTask task, int userId);
        Task DeletePersonalTak(int personalTaskId);
    }
}
