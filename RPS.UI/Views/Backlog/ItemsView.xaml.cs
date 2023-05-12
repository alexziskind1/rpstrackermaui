using RPS.Core.Models;
using RPS.UI.ViewModels.Backlog;

namespace RPS.UI.Views.Backlog;

public partial class ItemsView : ContentView
{
	public ItemsView()
	{
		InitializeComponent();

        /*
        this.dataGrid.ItemsSource = new List<Data>
        {
            new Data { Country = "India", Capital = "New Delhi"},
            new Data { Country = "South Africa", Capital = "Cape Town"},
            new Data { Country = "Nigeria", Capital = "Abuja" },
            new Data { Country = "Singapore", Capital = "Singapore" }
        };
        */
    }

    public void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // string previous = (e.PreviousSelection.FirstOrDefault() as PtItem);
        var selItem = (e.CurrentSelection.FirstOrDefault() as PtItem);
        if (selItem != null)
        {
            var vm = BindingContext as ItemsViewModel;
            var vmDetails = new DetailsViewModel(selItem, vm.ParentVm.itemsRepo, vm.ParentVm.tasksRepo);
            Navigation.PushAsync(new DetailsPage(vmDetails));
        }

        ((CollectionView)sender).SelectedItem = null;
    }


}