using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.View;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;

namespace DrelloProject.ViewModels
{
    public partial class BoardPageSetingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Board currentBoard = new Board();

        [ObservableProperty]
        private string boardName;

        [ObservableProperty]
        private int boardId;

        [ObservableProperty]
        private string boardDescription;

        [ObservableProperty]
        private ObservableCollection<BoardRole> roles = new ObservableCollection<BoardRole>();

        [ObservableProperty]
        private string roleName;

        [ObservableProperty]
        private BoardRole selectedRole;

        [ObservableProperty]
        private ObservableCollection<UserInBoard> users = new ObservableCollection<UserInBoard>();

        [ObservableProperty]
        private User selectedUser = new User();

        BoardDataService boardDataService = new BoardDataService();

        public BoardPageSetingsViewModel()
        {
            //Users = boardDataService.GetUsersInBoard(1);
        }

        [RelayCommand]
        async void NewRole()
        {
            roles.Add(new BoardRole { Name = roleName });
        }
        
        [RelayCommand]
        async void DeleteRoleBtn()
        {

        }

        [RelayCommand]
        async void BackBtn()
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        [RelayCommand]
        async void CheckBtn()
        {
            if (BoardId == 0)
            {
                int creatorId = 1;
                Board board = new Board() { Name = BoardName, Description = BoardDescription, CreatorId = creatorId };
                CurrentBoard = await boardDataService.AddBoard(board);

                var roles = await boardDataService.AddBoardRoles(Roles, currentBoard);
            }
            
            else ; 

        }

        [RelayCommand]
        async void AddUser()
        {
            await Shell.Current.GoToAsync(nameof(UserList));
        }
    }
}
