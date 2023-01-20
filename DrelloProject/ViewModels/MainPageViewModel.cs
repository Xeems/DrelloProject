using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.Services;
using System.Collections.ObjectModel;

namespace DrelloProject.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<KanBoard> boards = new ObservableCollection<KanBoard>();

        [ObservableProperty]
        private UploadImage uploadImage = new UploadImage();

        [ObservableProperty]
        private ImageSource backgroundImage;

        private RestDataService _restDataService;

        //public MainPageViewModel(IBoardsService boards) 
        //{ 
        // boards = (IBoardsService)boards.GetBoards();
        //}        

        [RelayCommand]
        async Task LoadAsync()
        {

            for (int i = 0; i < 10; i++)
            {
                KanBoard board = new KanBoard { Name = "Имя Подленнее ", Description = "Очень длинное описание для проверки на многострочность "};
                boards.Add(board);
            }

            //var img = await uploadImage.OpenMediaPickerAsync();

            //var imagefile = await uploadImage.Upload(img);

            //backgroundImage = ImageSource.FromStream(() =>
            //    uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase64))
            //);
        }

        [RelayCommand]
        async Task BoardAsync()
        {
           await Shell.Current.GoToAsync("BoardPage");

        }
    }
}
