using DrelloProject.ViewModels;

namespace DrelloProject.View;

public partial class BoardPage : ContentPage
{
	public BoardPage(BoardPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}