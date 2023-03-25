using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.View;
using Microsoft.Maui.Controls;

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
        string passwordConfirm;

        [ObservableProperty]
        string test;

        [ObservableProperty]
        bool isLogin = true;

        private RestDataService _restDataService = new RestDataService();

        [RelayCommand]
        async Task LogInBtn() 
        {
            User user = new User() { UserName = userName, Login = login, Password = password };
           
            if (isLogin)
            {
                var Token = await _restDataService.GetUserAsync(user);

                if (Token != null)
                    await Shell.Current.GoToAsync($"{nameof(MainPage)}",
                        new Dictionary<string, object>
                        {
                            ["Token"] = Token
                        });
                else
                    App.AlertSvc.ShowAlert("Ошибка","Не удалось войти","ОК");
            }
            else
            {                
                var message = _restDataService.AddUserAsync(user);
            }
                                  
        }

        [RelayCommand]
        async void ChangeScenario()
        {
            isLogin = !isLogin;
            var UserNameEntry = Shell.Current.FindByName<Border>("UserNameBorder");
            var PasswordConfirmEntry = Shell.Current.FindByName<Border>("PasswordConfirmBorder");
            var ChangeScenarioButton = Shell.Current.FindByName<Button>("ChangeScenarioButton");
            /////////////////////////
            switch (isLogin)
            {
                case true:
                    UserNameEntry.IsVisible = true;
                    PasswordConfirmEntry.IsVisible = true;
                    ChangeScenarioButton.Text = "Регистрация";
                    break;
                case false:
                    UserNameEntry.IsVisible = false;
                    PasswordConfirmEntry.IsVisible = false;
                    ChangeScenarioButton.Text = "Вход";
                    break;
                    
            }
        }

    }
}
