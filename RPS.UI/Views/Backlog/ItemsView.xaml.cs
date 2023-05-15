using RPS.Core.Models;
using RPS.UI.Converters;
using RPS.UI.ViewModels.Backlog;
using Telerik.Maui.Controls;
using Telerik.Maui.Controls.Compatibility.DataGrid;
using Telerik.Maui.Controls.Compatibility.Primitives;
using Image = Microsoft.Maui.Controls.Image;
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
            AutoGenerateColumns = false,
            SelectionMode = DataGridSelectionMode.Single,
            SelectionUnit = DataGridSelectionUnit.Row,
            ItemsSource = (BindingContext as ItemsViewModel).MyItems,

        };
        Dg = dg;
        dg.SelectionChanged += OnDataGridSelectionChanged;
        
        dg.Columns.Add(new DataGridTemplateColumn { CellContentTemplate = (DataTemplate)Resources["TypeCellTemplate"] });
        dg.Columns.Add(new DataGridTemplateColumn { HeaderText = "Title", CellContentTemplate = (DataTemplate)Resources["BadgeColumnCellTemplate"] });
        dg.Columns.Add(new DataGridTemplateColumn { HeaderText = "Assignee", CellContentTemplate = (DataTemplate)Resources["AssigneeCellTemplate"] });
        dg.Columns.Add(new DataGridNumericalColumn { PropertyName = "Estimate", HeaderText = "Estimate" });
        dg.Columns.Add(new DataGridDateColumn { PropertyName = "DateCreated",  HeaderText = "Created" });
        
        Grid.SetRow(dg, 1);
        RootLayout.Children.Add(dg);
    }

    public void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // string previous = (e.PreviousSelection.FirstOrDefault() as PtItem);
        var selItem = (e.CurrentSelection.FirstOrDefault() as PtItem);
        if (selItem != null)
        {
            NavigateToDetails(selItem);
        }

        ((CollectionView)sender).SelectedItem = null;
    }

    private void OnDataGridSelectionChanged(object sender, DataGridSelectionChangedEventArgs e)
    {
        var selItem = e.AddedItems.FirstOrDefault();
        if (selItem != null)
        {
            NavigateToDetails(selItem as PtItem);
        }
    }

    private void NavigateToDetails(PtItem selItem)
    {
        var vm = BindingContext as ItemsViewModel;
        var vmDetails = new DetailsViewModel(selItem as PtItem, vm.ParentVm.itemsRepo, vm.ParentVm.tasksRepo);
        Navigation.PushAsync(new DetailsPage(vmDetails));
    }

}