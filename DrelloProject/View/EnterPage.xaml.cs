using DrelloProject.ViewModels;

namespace DrelloProject.View;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class EnterPage : ContentPage
{
    public EnterPage(EnterPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

}