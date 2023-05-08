using RPS.UI.ViewModels.Dashboard;

namespace RPS.UI.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}