using RPS.UI.ViewModels.Backlog;
using RPS.UI.Views;
using RPS.UI.Views.Backlog;
using static Android.Content.ClipData;

namespace RPS.UI
{
    public partial class App : Application
    {
        public App(BacklogPage page)
        {
            InitializeComponent();

            Application.Current.UserAppTheme = AppTheme.Light;
            //MainPage = new RPSFlyoutPage();

            // dev code
            //var vm = Handler.MauiContext.Services.GetService(typeof(BacklogViewModel));
            //var newPage = (Page)Activator.CreateInstance(typeof(BacklogPage), vm);

            MainPage = new NavigationPage( page);
        }
    }
}