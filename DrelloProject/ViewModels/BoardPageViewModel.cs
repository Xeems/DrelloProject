using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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
using System.Threading;
using System.Threading.Tasks;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(Board), nameof(Board))]
    [QueryProperty(nameof(AUser), nameof(AUser))]
    public partial class BoardPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Board board;

        [ObservableProperty]
        private User aUser;

        [ObservableProperty]
        private UserInBoard currentUser;

        [ObservableProperty]
        private ObservableCollection<UserInBoard> boardMembers;

        [ObservableProperty]
        private ObservableCollection<ATask> notStartedTasks = new ObservableCollection<ATask>();

        [ObservableProperty]
        private ObservableCollection<ATask> performedTasks = new ObservableCollection<ATask>();

        [ObservableProperty]
        private ObservableCollection<ATask> doneTasks = new ObservableCollection<ATask>();

        private BoardTaskDataService taskDataService = new BoardTaskDataService();

        private BoardDataService boardDataService = new BoardDataService();


        [RelayCommand]
        async void Back() 
        {
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        [RelayCommand]
        async void PageLoaded() 
        {
            LoadTasks();
            BoardMembers = await boardDataService.GetUsersInBoard(Board.Id);
            CurrentUser = BoardMembers.Where(u=> u.User.Id == AUser.Id).First();
        }

        [RelayCommand]
        async void Settings()
        {
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

        [RelayCommand]
        async void TakeATask(ATask aTask)
        {
            bool response = await taskDataService.TakeTask(aTask.Id, CurrentUser.Id);
            if (response)
                LoadTasks();
            else 
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                string text = "Ошибка";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;
                var toast = Toast.Make(text, duration, fontSize);
                await toast.Show(cancellationTokenSource.Token);
            }
        }

        async void LoadTasks()
        {
            DoneTasks.Clear();
            PerformedTasks.Clear();
            NotStartedTasks.Clear();
            var ATasks = await taskDataService.GetTasks(Board.Id);
            foreach (var ATask in ATasks)
            {
                if (ATask.RequiredRole.Id == CurrentUser.BoardRole.Id)
                    ATask.IsAvailable = true;

                switch (ATask.Status)
                {
                    case ATaskStatus.NotStarted:
                        NotStartedTasks.Add(ATask);
                        break;
                    case ATaskStatus.Performed:
                        PerformedTasks.Add(ATask);
                        break;
                    case ATaskStatus.Done:
                        DoneTasks.Add(ATask);
                        ATask.IsAvailable = false;
                        break;
                }
            }
        }
    }
}
