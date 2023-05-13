using RPS.Core.Models;
using RPS.UI.ViewModels.Backlog;
using Telerik.Maui.Controls.Compatibility.DataGrid;

namespace RPS.UI.Views.Backlog;

public partial class ItemsView : ContentView
{

    public RadDataGrid Dg { get; set; }

	public ItemsView()
	{
        // TODO - Temporary workaround to wait until app is ready
        this.Loaded += (s, e) => CreateDataGrid();
        InitializeComponent();
    }

    private void CreateDataGrid()
    {
        var dg = new RadDataGrid
        {
            AutoGenerateColumns = true,
            ItemsSource = (BindingContext as ItemsViewModel).MyItems
        };
        Dg = dg;

        dg.Columns.Add(new DataGridTextColumn { PropertyName = "Description", HeaderText = "Description" });
        dg.Columns.Add(new DataGridTextColumn { PropertyName = "Estimate", HeaderText = "Estimate" });
        // mOAR columnz!

        Grid.SetRow(dg, 1);
        RootLayout.Children.Add(dg);
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

    private void Button_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as ItemsViewModel;
        
    }
}