using RPS.Core.Models;
using RPS.UI.Converters;
using RPS.UI.ViewModels.Backlog;
using Telerik.Maui.Controls.Compatibility.DataGrid;

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
            ItemsSource = (BindingContext as ItemsViewModel).MyItems
        };
        Dg = dg;

        dg.Columns.Add(new DataGridTextColumn { PropertyName = "Title", HeaderText = "Title" });
        var colAssignee = new DataGridTextColumn { PropertyName = "Assignee", HeaderText = "Assignee" };
        colAssignee.CellContentTemplate = new DataTemplate(() =>
        {
            var hsl = new HorizontalStackLayout { Spacing = 15, Margin = 5 };

            var imgBinding = new Binding("Assignee");
            imgBinding.Converter = new AvatarConverter();

            var img = new Image { WidthRequest = 40, HeightRequest = 40 };
            img.SetBinding(Image.SourceProperty, imgBinding);

            var lbl = new Label { VerticalOptions = LayoutOptions.Center };
            var nmBinding = new Binding("Assignee");
            nmBinding.Converter = new FullNameConverter();
            lbl.SetBinding(Label.TextProperty, nmBinding);
            hsl.Children.Add(img);
            hsl.Children.Add(lbl);
            return hsl;
        });
        dg.Columns.Add(colAssignee);



                //        < telerik:DataGridTextColumn PropertyName = "FullName"
                //                            HeaderText = "Sales Person"
                //                            HeaderStyle = "{StaticResource columHeaderStyle}" >
                //    < telerik:DataGridTextColumn.CellContentTemplate >
                //        < DataTemplate >
                //            < HorizontalStackLayout Spacing = "15" Margin = "5" >
                //                < Image Source = "{Binding Image}" WidthRequest = "40" HeightRequest = "40" />
                //                < Label Text = "{Binding FullName}" VerticalOptions = "Center" />
                //            </ HorizontalStackLayout >
                //        </ DataTemplate >
                //    </ telerik:DataGridTextColumn.CellContentTemplate >
                //</ telerik:DataGridTextColumn >

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