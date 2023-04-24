using DrelloProject.ViewModels;
namespace DrelloProject.View;

public partial class UserSettingsPage : ContentPage
{
	public UserSettingsPage(UserSettingsViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}