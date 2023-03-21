using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.ViewModels
{
    public partial class UserListViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<User> userList = new ObservableCollection<User>();

        [ObservableProperty]
        private string userName;

        public UserListViewModel()
        {
            
        }

        [RelayCommand]
        async void BackToSettings()
        {

        }

        [RelayCommand]
        async void FindUsers()
        {

        }
    }
}
