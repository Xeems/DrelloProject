using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.DataServices
{
    public interface IRestDataService
    {
        Task<User> GetUserAsync(User user);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
