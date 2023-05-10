using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using RPS.Core.Models.Dto;
using System.Collections.ObjectModel;
using RPS.UI.BL;

namespace RPS.UI.ViewModels.Backlog
{
    public partial class BacklogViewModel : ObservableObject
    {

        private readonly int CURRENT_USER_ID = 21;
        public readonly IPtItemsRepository itemsRepo;
        public readonly IPtTasksRepository tasksRepo;


        //public ObservableCollection<PtItem> MyItems { get; set; }

        [ObservableProperty]
        public ObservableCollection<PtItem> myItems;

        public BacklogViewModel(IPtItemsRepository itemsRepo, IPtTasksRepository tasksRepo)
        {
            this.itemsRepo = itemsRepo;
            this.tasksRepo = tasksRepo;
            MyItems = new ObservableCollection<PtItem>();
        }

        public void RefreshItems()
        {
            var refreshedItems = new ObservableCollection<PtItem>(itemsRepo.GetAll());
            MyItems = refreshedItems;
            //MyItems.Clear();
            //MyItems.Concat(refreshedItems);
        }

        public void SaveNewItem(PtNewItem newItem)
        {
            newItem.UserId = CURRENT_USER_ID;
            var savedItem = itemsRepo.AddNewItem(newItem);
            MyItems.Insert(0, savedItem);
        }
    }
}
