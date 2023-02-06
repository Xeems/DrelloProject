using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.Services;
using System.Collections.ObjectModel;

namespace DrelloProject.ViewModels
{
    [QueryProperty(nameof(Token), nameof(Token))]
    public partial class MainPageViewModel : ObservableObject
    { 
        [ObservableProperty]
        private ObservableCollection<KanBoard> boards = new ObservableCollection<KanBoard>();

        [ObservableProperty]
        private string token;

        [ObservableProperty]
        private ObservableCollection<PersonalTask> personalTasks = new ObservableCollection<PersonalTask>();

        [ObservableProperty]
        private KanBoard selectedBoard;

        public MainPageViewModel() 
        {
            KanBoard board = new KanBoard { Name = "Имя", Description = "Очень длинное описание для проверки на многострочность " };
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
    }
}
