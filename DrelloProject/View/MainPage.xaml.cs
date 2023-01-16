using DrelloProject.ViewModels;

namespace DrelloProject.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}