﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using RPS.UI.BL;
using RPS.UI.ViewModels.Dashboard;
using RPS.UI.ViewModels.Backlog;
using RPS.UI.Views.Dashboard;
using RPS.UI.Views.Backlog;
using Telerik.Maui.Controls.Compatibility;

namespace RPS.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.RegisterAppServices()
                    .RegisterViewModels()
                    .RegisterViews();

            builder
                .UseMauiApp<App>()
                .UseTelerik()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

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
            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<BacklogViewModel>();
            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<DashboardPage>();
            builder.Services.AddTransient<BacklogPage>();
            return builder;
        }
    }

}