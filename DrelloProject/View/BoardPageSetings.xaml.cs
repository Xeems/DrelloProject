using DrelloProject.ViewModels;

namespace DrelloProject.View;

public partial class BoardPageSetings : ContentPage
{
	public BoardPageSetings(BoardPageSetingsViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}