
using LifeManagementApp1.ViewModel;
using Microsoft.Extensions.Logging;

namespace LifeManagementApp1;

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
			});
			builder.Services.AddSingleton<TodoPage>();
			builder.Services.AddSingleton<MainViewModel>();

			builder.Services.AddTransient<DetailPage>();
			builder.Services.AddTransient<DetailViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
