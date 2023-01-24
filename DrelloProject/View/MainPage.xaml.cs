using DrelloProject.ViewModels;

namespace DrelloProject.View;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}