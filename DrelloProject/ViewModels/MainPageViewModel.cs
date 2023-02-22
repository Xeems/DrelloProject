using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.Models;
using DrelloProject.View;
using System.Collections.ObjectModel;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(Token), nameof(Token))]
    public partial class MainPageViewModel : ObservableObject
    { 
        [ObservableProperty]
        private ObservableCollection<Board> boards = new ObservableCollection<Board>();

        [ObservableProperty]
        private string token;

        [ObservableProperty]
        private ObservableCollection<PersonalTask> personalTasks = new ObservableCollection<PersonalTask>();

        [ObservableProperty]
        private Board selectedBoard;

        public MainPageViewModel() 
        {
            Board board = new Board { Name = "Имя", Description = "Очень длинное описание для проверки на многострочность " };
            for (int i = 0; i < 10; i++)
            {
                boards.Add(board);
            }

            PersonalTask personalTask = new PersonalTask { TaskBody = "Имя Подленнее " };
            for (int i = 0; i < 20; i++)
            {
                personalTasks.Add(personalTask);
            }
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

        }
    }
}
