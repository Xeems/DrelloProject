using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using System.Collections.ObjectModel;

namespace DrelloProject.ViewModels
{
    public partial class BoardPageSetingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<BoardRole> roles = new ObservableCollection<BoardRole>();

        [ObservableProperty]
        private Board currentBoard = new Board();

        [ObservableProperty]
        private string boardName;

        [ObservableProperty]
        private int boardId;

        [ObservableProperty]
        private string boardDescription;

        [ObservableProperty]
        private string roleName;

        [ObservableProperty]
        private BoardRole selectedRole;

        BoardDataService boardDataService = new BoardDataService();

        [RelayCommand]
        async void NewRoleBtn()
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
    }
}
