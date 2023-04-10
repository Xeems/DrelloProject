using DrelloProject.View;
using DrelloProject.ViewModels;

namespace DrelloProject;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(EnterPage), typeof(EnterPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(BoardPage), typeof(BoardPage));
		Routing.RegisterRoute(nameof(BoardPageSetings), typeof(BoardPageSetings));
		Routing.RegisterRoute(nameof(UserList), typeof(UserList));
		Routing.RegisterRoute(nameof(NewTaskPage), typeof(NewTaskPage));
    }
}
