

using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models;
using RPS.Core.Models.Enums;
using System.Collections.ObjectModel;

namespace RPS.UI.ViewModels.Backlog
{
    public partial class DetailsScreenViewModel : ObservableObject
    {
        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public string description;



        [ObservableProperty]
        public double estimate;

        public string SelectedItemType { get; set; }
        public ItemTypeEnum SelectedItemTypeEnum
        {
            get
            {
                if (SelectedItemType != null)
                {
                    return Enum.Parse<ItemTypeEnum>(SelectedItemType);
                }
                else
                {
                    return ItemTypeEnum.PBI;
                }
            }
        }
        public ObservableCollection<string> iTypes;
        public ObservableCollection<string> ItemTypes
        {
            get
            {
                if (iTypes == null)
                {
                    var arr = Enum.GetValues<ItemTypeEnum>();
                    iTypes = new ObservableCollection<string>(arr.Select(e => e.ToString()));
                }

                return iTypes;
            }
            set
            {
                iTypes = value;
            }
        }


        public string SelectedPriority { get; set; }

        public PriorityEnum SelectedPriorityEnum
        {
            get
            {
                if (SelectedPriority != null)
                {
                    return Enum.Parse<PriorityEnum>(SelectedPriority);
                }
                else
                {
                    return PriorityEnum.Medium;
                }
            }
        }

        public ObservableCollection<string> iPriorities;

        public ObservableCollection<string> Priorities
        {
            get
            {
                if (iPriorities == null)
                {
                    var arr = Enum.GetValues<PriorityEnum>();
                    iPriorities = new ObservableCollection<string>(arr.Select(e => e.ToString()));
                }

                return iPriorities;
            }
            set
            {
                iPriorities = value;
            }
        }


        public string SelectedStatus { get; set; }

        public StatusEnum SelectedStatusEnum
        {
            get
            {
                if (SelectedStatus != null)
                {
                    return Enum.Parse<StatusEnum>(SelectedStatus);
                }
                else
                {
                    return StatusEnum.Open;
                }
            }
        }

        public ObservableCollection<string> iStatuses;

        public ObservableCollection<string> Statuses
        {
            get
            {
                if (iStatuses == null)
                {
                    var arr = Enum.GetValues<StatusEnum>();
                    iStatuses = new ObservableCollection<string>(arr.Select(e => e.ToString()));
                }

                return iStatuses;
            }
            set
            {
                iStatuses = value;
            }
        }


        public DetailsScreenViewModel(PtItem item)
        {
            title = item.Title;
            description = item.Description;
            estimate = item.Estimate;
            SelectedItemType = item.Type.ToString();
            SelectedPriority = item.Priority.ToString();
            SelectedStatus = item.Status.ToString();
        }

    }
}
