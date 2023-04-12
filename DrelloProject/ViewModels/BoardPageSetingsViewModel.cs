using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.View;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.ObjectModel;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(CurrentUser), nameof(CurrentUser))]
    public partial class BoardPageSetingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Board currentBoard = new Board();

        [ObservableProperty]
        private User currentUser = new User();

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
                Board board = new Board() { Name = BoardName, Description = BoardDescription, CreatorId = CurrentUser.Id };
                CurrentBoard = await boardDataService.AddBoard(board);

                var roles = await boardDataService.AddBoardRoles(Roles, currentBoard);

                await boardDataService.AddUserToBoard(CurrentUser.Id,CurrentBoard.Id);
            }
            
            else ; 

        }

        [RelayCommand]
        async void AddUser()
        {
            await Shell.Current.GoToAsync($"{nameof(UserList)}",
                        new Dictionary<string, object>
                        {
                            ["CurrentBoard"] = currentBoard
                        });
        }
    }
}
