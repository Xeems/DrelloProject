using CommunityToolkit.Mvvm.ComponentModel;
using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(CurrentUser),nameof(CurrentUser))]
    public partial class UserSettingsViewModel : ObservableObject 
    {
        [ObservableProperty]
        private User currentUser = new();

        public UserSettingsViewModel()
        {
            
        }
    }
    
}
