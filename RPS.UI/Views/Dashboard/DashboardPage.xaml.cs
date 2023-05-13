using RPS.UI.Models;
using RPS.UI.ViewModels.Backlog;
using RPS.UI.ViewModels.Dashboard;

namespace RPS.UI.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;

        //this.dataGrid.ItemsSource = new List<Data>
        //{
        //    new Data { Country = "India", Capital = "New Delhi"},
        //    new Data { Country = "South Africa", Capital = "Cape Town"},
        //    new Data { Country = "Nigeria", Capital = "Abuja" },
        //    new Data { Country = "Singapore", Capital = "Singapore" }
        //};
    }

    private void dateRange_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        var selRange = (DashboardMonthRange)picker.ItemsSource[selectedIndex];

        var vm = (DashboardViewModel)BindingContext;

        vm.UpdateMonthRange(selRange);
    }
}