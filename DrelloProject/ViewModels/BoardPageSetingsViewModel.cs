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
    public partial class BoardPageSetingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<BoardRole> roles = new ObservableCollection<BoardRole>();

        [ObservableProperty]
        private string boardName;

        [ObservableProperty]
        private string boardDescription;

        [ObservableProperty]
        private string roleName;

        [ObservableProperty]
        private BoardRole selectedRole;

        [RelayCommand]
        async void NewRoleBtn()
        {
            roles.Add(new BoardRole { Name = roleName });
        }
        
        [RelayCommand]
        async void DeleteRoleBtn()
        {

        }
    }
}
