using CommunityToolkit.Maui.Views;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using RPS.UI.ViewModels.Backlog;
using RPS.UI.Views.Backlog.Popups;
using Telerik.Maui.Controls.Compatibility.DataGrid;

namespace RPS.UI.Views.Backlog;

public partial class BacklogPage : ContentPage
{
	public BacklogPage(BacklogViewModel vm)
	{
        // TODO - Temporary workaround to wait until app is ready
        this.Loaded += (s,e) => CreateDataGrid();

		InitializeComponent();

		BindingContext = vm;
    }

    private void CreateDataGrid()
    {
        var dg = new RadDataGrid
        {
            AutoGenerateColumns = false,
            ItemsSource = (BindingContext as BacklogViewModel).ItemsVm.MyItems
        };
        
        dg.Columns.Add(new DataGridTextColumn { PropertyName = "Description", HeaderText = "Description" });
        dg.Columns.Add(new DataGridTextColumn { PropertyName = "Estimate", HeaderText = "Estimate" });
        // mOAR columnz!

        Grid.SetRow(dg, 1);
        RootGrid.Children.Add(dg);
    }

    public async void AddItem_Clicked(object sender, EventArgs e)
    {
        var addNewItemPopup = new AddItemPopup();
        var result = await this.ShowPopupAsync(addNewItemPopup) as PtNewItem;

        if (result != null)
        {
            (BindingContext as BacklogViewModel).SaveNewItem(result);
        }
    }

    public void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // string previous = (e.PreviousSelection.FirstOrDefault() as PtItem);
        var selItem = (e.CurrentSelection.FirstOrDefault() as PtItem);
        if (selItem != null)
        {
            var vm = BindingContext as BacklogViewModel;
            var vmDetails = new DetailsViewModel(selItem, vm.itemsRepo, vm.tasksRepo);
            Navigation.PushAsync(new DetailsPage(vmDetails));
        }

        ((CollectionView)sender).SelectedItem = null;
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        var vm = BindingContext as BacklogViewModel;
        vm.GetRefreshedItems();
    }
}