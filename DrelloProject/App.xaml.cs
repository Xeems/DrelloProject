namespace DrelloProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        App.Current.MainPage = new AppShell();
	}
}
