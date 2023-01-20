using DrelloProject.View;

namespace DrelloProject;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(BoardPage), typeof(BoardPage));
	}
}
