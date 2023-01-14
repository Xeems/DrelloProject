using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.Models
{
    public partial class User : ObservableObject
    {
        [ObservableProperty]
        int id;
        
        [ObservableProperty]
        string name;
        
        [ObservableProperty]
        string login;

        [ObservableProperty]
        string password;
    }
}
