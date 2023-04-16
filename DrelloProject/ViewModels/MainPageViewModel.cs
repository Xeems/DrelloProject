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
        private User currentUser;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private ObservableCollection<Board> boards = new ObservableCollection<Board>();

        [ObservableProperty]
        private ObservableCollection<PersonalTask> personalTasks = new ObservableCollection<PersonalTask>();

        private PersonalTaskDataService _personalTaskDataService = new PersonalTaskDataService();

        private BoardDataService _boardDataService = new BoardDataService();

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
                            ["Board"] = board
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
    }
}
