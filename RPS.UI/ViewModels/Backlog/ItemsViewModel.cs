using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using System.Collections.ObjectModel;
using RPS.UI.BL;

namespace RPS.UI.ViewModels.Backlog
{

    public class Data
    {
        public string Country { get; set; }
        public string Capital { get; set; }
    }


    public partial class ItemsViewModel : ObservableObject
    {
        public BacklogViewModel ParentVm { get; set; }

        [ObservableProperty]
        public ObservableCollection<PtItem> myItems;

        [ObservableProperty]
        public ObservableCollection<Data> myData;


        public ItemsViewModel(BacklogViewModel parentVm)
        {
            this.ParentVm = parentVm;
            MyItems = new ObservableCollection<PtItem>();

            MyData = new ObservableCollection<Data>()
            {

                new Data { Country = "India", Capital = "New Delhi"},
                new Data { Country = "South Africa", Capital = "Cape Town"},
                new Data { Country = "Nigeria", Capital = "Abuja" },
                new Data { Country = "Singapore", Capital = "Singapore" }


            };
        }

        public void RefreshItems(ObservableCollection<PtItem> refreshedItems)
        {
            MyItems = refreshedItems;
        }

        public void InsertItem(int location, PtItem item)
        {
            MyItems.Insert(location, item);
        }

    }
}
