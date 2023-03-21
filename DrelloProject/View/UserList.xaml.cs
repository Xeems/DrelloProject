using DrelloProject.ViewModels;

namespace DrelloProject.View;

public partial class UserList : ContentPage
{
	public UserList(UserListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}