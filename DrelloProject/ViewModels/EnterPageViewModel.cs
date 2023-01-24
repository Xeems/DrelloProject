using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.View;

namespace DrelloProject.ViewModels
{
    public partial class EnterPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string login;

        [ObservableProperty]
        string userName;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string test;

        [ObservableProperty]
        bool isLogin = true;

        //private RestDataService _restDataService;

        [RelayCommand]
        async Task LogInBtn() 
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
            
        }

        [RelayCommand]
        async void ChangeScenario()
        {
            isLogin = !isLogin;
        }

    }
}
