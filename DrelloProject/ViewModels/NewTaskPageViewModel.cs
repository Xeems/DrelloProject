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
    [QueryProperty(nameof(Board), nameof(Board))]
    public partial class NewTaskPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Board board;

        [ObservableProperty]
        private string taskName;

        [ObservableProperty]
        private ObservableCollection<BoardRole> roles;

        [ObservableProperty]
        private BoardRole selectedRole;

        private BoardDataService boardDataService = new BoardDataService();
        private BoardTaskDataService boardTaskDataService = new BoardTaskDataService();

        [RelayCommand]
        async void PageLoaded() 
        {
            Roles = await boardDataService.GetRoles(Board.Id);
        }

        [RelayCommand]
        async void Back()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async void Accept()
        {
            ATask aTask = new ATask() {BoardId = Board.Id, Name = TaskName, RequiredRoleId = SelectedRole.Id };
            await boardTaskDataService.NewTask(aTask);
        }
    }
}
