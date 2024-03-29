using DrelloProject.ViewModels;

namespace DrelloProject.View;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class BoardPage : ContentPage
{
	public BoardPage(BoardPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}