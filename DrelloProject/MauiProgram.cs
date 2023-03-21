using CommunityToolkit.Maui.Core;
using DrelloProject.DataServices;
using DrelloProject.Services;
using DrelloProject.View;
using DrelloProject.ViewModels;

namespace DrelloProject;

[XamlCompilation(XamlCompilationOptions.Compile)]
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .RegisterAppServices()
            .RegisterViewModels()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("ROBOTO-BOLD.TTF", "RobotoBold");
                fonts.AddFont("ROBOTO-BOLDITALIC.TTF", "RobotoBoldItalic");
                fonts.AddFont("ROBOTO-ITALIC.TTF", "RobotoItalic");
                fonts.AddFont("ROBOTO-LIGHT.TTF", "RobotoLight");
                fonts.AddFont("ROBOTO-MEDIUM.TTF", "RobotoMedium");
                fonts.AddFont("ROBOTO-REGULAR.TTF", "RobotoRegular");
                fonts.AddFont("ROBOTO-THIN.TT", "RobotoThin");
            }).UseMauiCommunityToolkitCore();
        return builder.Build();
	}
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder Appbuilder)
    {
        Appbuilder.Services.AddHttpClient<IRestDataService, RestDataService>();

        return Appbuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder Appbuilder)
    {
        Appbuilder.Services.AddSingleton<EnterPage>();
        Appbuilder.Services.AddSingleton<EnterPageViewModel>();

        Appbuilder.Services.AddSingleton<MainPage>();
        Appbuilder.Services.AddSingleton<MainPageViewModel>();

        Appbuilder.Services.AddTransient<BoardPageSetings>();
        Appbuilder.Services.AddTransient<BoardPageSetingsViewModel>();

        Appbuilder.Services.AddTransient<BoardPage>();
        Appbuilder.Services.AddTransient<BoardPageViewModel>();

        Appbuilder.Services.AddSingleton<UserList>();
        Appbuilder.Services.AddSingleton<UserListViewModel>();

        Appbuilder.Services.AddSingleton<IAlertService, AlertService>();

        return Appbuilder;
    }
}
