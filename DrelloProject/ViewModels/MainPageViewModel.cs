using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;

namespace DrelloProject.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<KanBoard> boards = new List<KanBoard>();

        private RestDataService _restDataService;

        [RelayCommand]
        void Load()
        {
            for (int i = 0; i < 10; i++)
            {
                KanBoard board = new KanBoard { Name = "Имя " + i, Description = "Описание " + i};
                boards.Add(board);
            }
        }

    }
}
