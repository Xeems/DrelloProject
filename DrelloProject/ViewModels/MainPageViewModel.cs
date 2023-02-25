using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.View;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(Token), nameof(Token))]
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string token;

        [ObservableProperty]
        private ObservableCollection<Board> boards = new ObservableCollection<Board>();

        [ObservableProperty]
        private ObservableCollection<PersonalTask> personalTasks = new ObservableCollection<PersonalTask>();

        private PersonalTaskDataService _personalTaskDataService = new PersonalTaskDataService();

        [ObservableProperty]
        private Board selectedBoard;

        public MainPageViewModel() 
        {
            GetPersonalTasks(1);

            Board board = new Board { Name = "Имя", Description = "Очень длинное описание для проверки на многострочность " };
            for (int i = 0; i < 10; i++)
            {
                boards.Add(board);
            }            
        }

        public async void GetPersonalTasks(int userId)
        {
            var Tasks = await _personalTaskDataService.GetPersonalTasks(userId);
            if (Tasks != null)
                PersonalTasks = Tasks;
        }

        [RelayCommand]
        async Task DeletePersonalTask() 
        {
            personalTasks.Clear();
        }

        [RelayCommand]
        async Task TapBoardAsync()
        {
           await Shell.Current.GoToAsync("BoardPage");

        }

        [RelayCommand]
        async Task NewKanBoardBtn()
        {
            Shell.Current.GoToAsync(nameof(BoardPageSetings));
        }

        [RelayCommand]
        async Task NewToDoBtn()
        {
            GetPersonalTasks(1);
        }
    }
}
