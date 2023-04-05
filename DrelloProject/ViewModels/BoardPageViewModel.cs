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

        public BoardPageViewModel() 
        {
            
        }

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
    }
}
