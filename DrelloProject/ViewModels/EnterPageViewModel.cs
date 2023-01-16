using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;

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

        private RestDataService _restDataService;

        [RelayCommand]
        async void LogInBtn() 
        {
            _restDataService = new RestDataService();

            User user = new User { Name = userName, Login = login, Password = password };

            if (isLogin)
            {
                var answer = await _restDataService.GetUserAsync(user);
                if (answer.Id != 0)
                {
                    await Shell.Current.GoToAsync("MainPage");
                    answer = null;
                }    
                    
            }
            else
            {
                await _restDataService.AddUserAsync(user);
            }
            

            
        }

        [RelayCommand]
        async void ChangeScenario()
        {
            isLogin = !isLogin;
        }

    }
}
