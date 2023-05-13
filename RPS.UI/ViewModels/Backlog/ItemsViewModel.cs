using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using System.Collections.ObjectModel;


namespace RPS.UI.ViewModels.Backlog
{
    public partial class ItemsViewModel : ObservableObject
    {
        public BacklogViewModel ParentVm { get; set; }

        [ObservableProperty]
        public ObservableCollection<PtItem> myItems;


        public ItemsViewModel(BacklogViewModel parentVm)
        {
            this.ParentVm = parentVm;
            MyItems = new ObservableCollection<PtItem>()
            {
                new PtItem
                {
                    Id = 1,
                    Title = "item 1"
                }
            };
        }

        public void RefreshItems(ObservableCollection<PtItem> refreshedItems)
        {
            MyItems.Clear();
            foreach (var item in refreshedItems)
            {
                MyItems.Add(item);
            }
        }

        public void InsertItem(int location, PtItem item)
        {
            MyItems.Insert(location, item);
        }

    }
}
