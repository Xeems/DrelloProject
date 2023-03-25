using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(CurrentBoard), nameof(CurrentBoard))]
    public partial class UserListViewModel : ObservableObject
    {
        [ObservableProperty]
        Board currentBoard;

        [ObservableProperty]
        private ObservableCollection<User> userList = new ObservableCollection<User>();

        [ObservableProperty]
        private string userName;

        private RestDataService restDataService = new RestDataService();

        private BoardDataService boardDataService = new BoardDataService();

        public UserListViewModel()
        {
            
        }

        [RelayCommand]
        async void BackToSettings()
        {
            await Shell.Current.GoToAsync(nameof(BoardPageSetings));
        }

        [RelayCommand]
        async void AddUser(User user)
        {
            var response = await boardDataService.AddUserToBoard(user.Id, currentBoard.Id);
        }

        [RelayCommand]
        async void FindUsers(User user)
        {
            UserList = await restDataService.FindUsers(userName);
        }
    }
}
