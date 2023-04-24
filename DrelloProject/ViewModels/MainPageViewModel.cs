using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.View;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(CurrentUser), nameof(CurrentUser))]
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private User currentUser = new();

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private ObservableCollection<Board> boards = new();

        [ObservableProperty]
        private ObservableCollection<PersonalTask> personalTasks = new();

        private PersonalTaskDataService _personalTaskDataService = new();

        private BoardDataService _boardDataService = new();

        [ObservableProperty]
        private Board selectedBoard;

        [RelayCommand]
        async Task PageLoaded() 
        {
            await GetPersonalTasks(CurrentUser.Id);
            await GetUserBoards(CurrentUser.Id);    

        }

        [RelayCommand]
        async Task TapBoard(Board board)
        {
           await Shell.Current.GoToAsync($"{nameof(BoardPage)}",
                        new Dictionary<string, object>
                        {
                            ["Board"] = board,
                            ["AUser"] = CurrentUser
                        });
        }

        [RelayCommand]
        async Task NewKanBoardBtn()
        {
            await Shell.Current.GoToAsync($"{nameof(BoardPageSetings)}",
                        new Dictionary<string, object>
                        {
                            ["CurrentUser"] = CurrentUser
                        });
        }

        [RelayCommand]
        async Task NewPersonalTaskBtn()
        {
            string personalTaskName = await Shell.Current.DisplayPromptAsync("Новая задача", "Введите название:", "OK", "Отмена");
            PersonalTask task = new PersonalTask() { Task = personalTaskName};
            bool response = await _personalTaskDataService.AddPesonalTask(task, CurrentUser.Id);
            if(response == true)
                await GetPersonalTasks(CurrentUser.Id);
        }

        [RelayCommand]
        async Task DeletePersonalTask(PersonalTask personalTask)
        {
            personalTasks.Remove(personalTask);
            await _personalTaskDataService.DeletePersonalTask(personalTask.Id);
        }

        [RelayCommand]
        async Task UserSettings()
        {
            await Shell.Current.GoToAsync($"{nameof(UserSettingsPage)}",
                        new Dictionary<string, object>
                        {
                            ["CurrentUser"] = CurrentUser
                        });
        }
       
        public async Task GetPersonalTasks(int userId)
        {
            var Tasks = await _personalTaskDataService.GetPersonalTasks(userId);
            if (Tasks != null)
                PersonalTasks = Tasks;
        }

        public async Task GetUserBoards(int UserId)
        {
            Boards = await _boardDataService.GetBoardsByUser(UserId);
        }

        public void LoadUser()
        {
            CurrentUser.Id = StaticUser.Id;
            CurrentUser.UserName = StaticUser.UserName;
            CurrentUser.UserHEXColor = StaticUser.UserHEXColor;
        }
    }
}
