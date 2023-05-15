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

        var colType = new DataGridTemplateColumn();
        colType.CellContentTemplate = new DataTemplate(() =>
        {
            var imgBinding = new Binding("Type");
            imgBinding.Converter = new ItemTypeImageConverter();
            var img = new Image { WidthRequest = 20, HeightRequest = 20 };
            img.SetBinding(Image.SourceProperty, imgBinding);
            return img;
        });
        dg.Columns.Add(colType);

        /* Example of a simple text column
        dg.Columns.Add(new DataGridTextColumn { PropertyName = "Title", HeaderText = "Title" });
        */

        var colTitleWithPriority = new DataGridTemplateColumn { HeaderText = "Title" };
        colTitleWithPriority.CellContentTemplate = new DataTemplate(() =>
        {
            var badge = new RadBadgeView { BadgeHorizontalPosition = BadgePosition.Start, BadgeText = "", BadgeBackgroundColor = Color.Parse("Green") };

            var badgeColorBinding = new Binding("Priority");
            badgeColorBinding.Converter = new PriorityColorConverter();
            badge.SetBinding(RadBadgeView.BadgeBackgroundColorProperty, badgeColorBinding);

            var titleLabel = new Label();
            var titleTextBinding = new Binding("Title");
            titleLabel.SetBinding(Label.TextProperty, titleTextBinding);

            badge.Content = titleLabel;

            return badge;
        });
        dg.Columns.Add(colTitleWithPriority);



        /* Example with Avatar only
        var colAvatar = new DataGridTemplateColumn();
        colAvatar.CellContentTemplate = new DataTemplate(() => 
        {
            var imgBinding = new Binding("Assignee");
            imgBinding.Converter = new AvatarConverter();
            var img = new Image { WidthRequest = 40, HeightRequest = 40 };
            img.SetBinding(Image.SourceProperty, imgBinding);
            return img;
        });
        dg.Columns.Add(colAvatar);
        */


        var colAssignee = new DataGridTemplateColumn { HeaderText = "Assignee" };
        colAssignee.CellContentTemplate = new DataTemplate(() =>
        {
            var hsl = new HorizontalStackLayout { Spacing = 15, Margin = 5 };

            var imgBinding = new Binding("Assignee");
            imgBinding.Converter = new AvatarConverter();

            var img = new Image { WidthRequest = 40, HeightRequest = 40 };
            img.SetBinding(Image.SourceProperty, imgBinding);

            var imgBorder = new RadBorder { BorderThickness = 5, CornerRadius = 20 };
            imgBorder.Content = img;

            var lbl = new Label { VerticalOptions = LayoutOptions.Center };
            var nmBinding = new Binding("Assignee");
            nmBinding.Converter = new FullNameConverter();
            lbl.SetBinding(Label.TextProperty, nmBinding);
            hsl.Children.Add(imgBorder);
            hsl.Children.Add(lbl);
            return hsl;
        });
        dg.Columns.Add(colAssignee);






        var colEstimate = new DataGridNumericalColumn { PropertyName = "Estimate", HeaderText = "Estimate" };
        dg.Columns.Add(colEstimate);

        var colDateCreated = new DataGridDateColumn { PropertyName = "DateCreated", HeaderText = "Created" };
        dg.Columns.Add(colDateCreated);


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