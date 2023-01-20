using CommunityToolkit.Maui.Core;
using DrelloProject.DataServices;
using DrelloProject.View;
using DrelloProject.ViewModels;

namespace DrelloProject;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).UseMauiCommunityToolkitCore();

        builder.Services.AddHttpClient<IRestDataService, RestDataService>();

        builder.Services.AddSingleton<EnterPage>();
        builder.Services.AddSingleton<EnterPageViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddTransient<BoardPage>();
        builder.Services.AddTransient<BoardPageViewModel>();

        //builder.Services.AddSingleton<IRestDataService,RestDataService>();

        return builder.Build();
	}
}
