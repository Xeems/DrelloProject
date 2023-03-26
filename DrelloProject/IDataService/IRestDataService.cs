using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.IDataService
{
    public interface IRestDataService
    {
        Task<User> GetUserAsync(User user);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<ObservableCollection<User>> FindUsers(string userName);
    }
}
