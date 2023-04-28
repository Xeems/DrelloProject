using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrelloProject.DataServices;
using DrelloProject.Models;
using DrelloProject.Services;
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
        bool isRegister = false;

        private RestDataService _restDataService = new RestDataService();

        [RelayCommand]
        async Task LogIn() 
        {
            User user = new User() { UserName = userName, Login = login, Password = password };
           
            if (!IsRegister)
            {
                var currentUser = await _restDataService.GetUserAsync(user);


                if (currentUser != null)
                {
                    StaticUser.ShortName = currentUser.ShortName;
                    StaticUser.UserName = currentUser.UserName;
                    StaticUser.UserHEXColor = currentUser.UserHEXColor;
                    StaticUser.Id = currentUser.Id;

                    await Shell.Current.GoToAsync($"{nameof(MainPage)}",
                        new Dictionary<string, object>
                        {
                            ["CurrentUser"] = currentUser
                        });
                }
                else
                    App.AlertSvc.ShowAlert("Ошибка", "Не удалось войти", "ОК");
            }
            else
            {                
                var message = _restDataService.AddUserAsync(user);
                if (message != null)
                {
                    ToastService.ShowToast("Регистрация успешно завершена");
                    ChangeScenario();
                }
            }
                                  
        }

        [RelayCommand]
        void ChangeScenario()
        {
            IsRegister = !IsRegister;            
        }

    }
}
