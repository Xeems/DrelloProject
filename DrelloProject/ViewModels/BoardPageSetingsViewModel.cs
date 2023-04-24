using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.View;
using System.Collections.ObjectModel;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(CurrentUser), nameof(CurrentUser)), 
     QueryProperty(nameof(CurrentBoard),nameof(CurrentBoard))]
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
        private UserInBoard selectedUser = new UserInBoard();


        BoardDataService boardDataService = new BoardDataService();

        [RelayCommand]
        async void PageLoaded()
        {
            if(CurrentBoard.Id != 0)
            {
                Users = await boardDataService.GetUsersInBoard(CurrentBoard.Id);
                BoardName = currentBoard.Name;
                BoardDescription = currentBoard.Description;
                BoardId = currentBoard.Id;
                Roles = await boardDataService.GetRoles(CurrentBoard.Id);
            }
        
        }

        [RelayCommand]
        async void NewRole()
        { 
            if (CurrentBoard.Id == 0)
                roles.Add(new BoardRole { Name = roleName, RoleHEXColor = ColorList.GetRandomColor() });
            else
            {
                var role = new BoardRole { Name = roleName, BoardId = CurrentBoard.Id, RoleHEXColor = ColorList.GetRandomColor() };
                Roles = await boardDataService.AddRole(currentBoard.Id, role);
            }
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
            if (CurrentBoard.Id == 0)
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
            if (CurrentBoard.Id == 0)
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                string text = "Сначала сохраните настройки доски";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(text, duration, fontSize);

                await toast.Show(cancellationTokenSource.Token);
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(UserList)}",
                        new Dictionary<string, object>
                        {
                            ["CurrentBoard"] = currentBoard
                        });
            }
        }

        [RelayCommand]
        async void SelectRole()
        {
            if(SelectedUser != null)
            {
                Users = await boardDataService.GiveRole(CurrentBoard.Id, SelectedUser.Id, SelectedRole.Id);

                SelectedUser = null;                               
            }
            if (SelectedRole == null)
                return;
        }
        [RelayCommand]
        async void SelectUser()
        {
            if (SelectedUser == null)
            {
                SelectedRole = null;
            }
        }

    }
}
