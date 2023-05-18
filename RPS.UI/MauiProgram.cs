using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using RPS.UI.BL;
using RPS.UI.ViewModels.Dashboard;
using RPS.UI.ViewModels.Backlog;
using RPS.UI.Views.Dashboard;
using RPS.UI.Views.Backlog;
using Telerik.Maui.Controls.Compatibility;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace RPS.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseTelerik()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.RegisterAppServices()
                    .RegisterViewModels()
                    .RegisterViews();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<PtInMemoryContext>();
            builder.Services.AddSingleton(typeof(IPtItemsRepository), typeof(PtItemsRepository));
            builder.Services.AddSingleton(typeof(IPtTasksRepository), typeof(PtTasksRepository));
            builder.Services.AddSingleton(typeof(IPtDashboardRepository), typeof(PtDashboardRepository));
            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddScoped<DashboardViewModel>();
            builder.Services.AddScoped<BacklogViewModel>();
            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddScoped<DashboardPage>();
            builder.Services.AddScoped<BacklogPage>();
            return builder;
        }
    }

}