using DrelloProject.ViewModels;

namespace DrelloProject.View;

public partial class NewTaskPage : ContentPage
{
	public NewTaskPage(NewTaskPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}