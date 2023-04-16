using CommunityToolkit.Maui.Views;
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
    public partial class BoardPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Board board;

        [ObservableProperty]
        private ObservableCollection<ATask> aTasks = new ObservableCollection<ATask>();

        private BoardTaskDataService _taskDataService = new BoardTaskDataService();


        [RelayCommand]
        async void Back() 
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        [RelayCommand]
        async void PageLoaded() 
        {
            ATasks = await _taskDataService.GetTasks(Board.Id);
        }

        [RelayCommand]
        async void Settings()
        {///////////////////////////////////
            await Shell.Current.GoToAsync($"{nameof(BoardPageSetings)}",
                        new Dictionary<string, object>
                        {
                            ["CurrentBoard"] = Board
                        });
        }

        [RelayCommand]
        async void NewTask() 
        { 
           await Shell.Current.GoToAsync($"{nameof(NewTaskPage)}",
                        new Dictionary<string, object>
                        {
                            ["Board"] = Board
                        });
        }
    }
}
