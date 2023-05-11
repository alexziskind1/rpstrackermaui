using System.ComponentModel.DataAnnotations;
using RPS.Core.Models.Enums;
using RPS.Core.Models;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RPS.UI.ViewModels.Backlog;

public class ItemFormViewModel : ObservableObject
{
    public DetailsScreenViewModel parentVm;
    private string title;
    private string description;

    private ItemTypeEnum itemType;
    private PriorityEnum priority;
    private StatusEnum status;

    private int estimate;
    

    public ItemFormViewModel(PtItem item, DetailsScreenViewModel parentVm)
    {
        this.parentVm = parentVm;

        if (item != null)
        {
            this.Title = item.Title;
            this.Description = item.Description;
            this.ItemType = item.Type;
            this.Priority = item.Priority;
            this.Status = item.Status;
            this.Estimate = item.Estimate;
        } else
        {
            this.Estimate = 1;
        }

    }

    [Required]
    [Display(Name = "Title", Prompt = "Enter Title")]
    public string Title
    {
        get => this.title;
        set => this.SetProperty(ref this.title, value);
    }

    [Required]
    [Display(Name = "Description", Prompt = "Enter Description")]
    public string Description
    {
        get => this.description;
        set => this.SetProperty(ref this.description, value);
    }

    [Range(1, 20)]
    [Display(Name = "Estimate")]
    public int Estimate
    {
        get => this.estimate;
        set => this.SetProperty(ref this.estimate, value);
    }

    [Display(Name = "Type")]
    public ItemTypeEnum ItemType
    {
        get => this.itemType;
        set => this.SetProperty(ref this.itemType, value);
    }

    [Display(Name = "Priority")]
    public PriorityEnum Priority
    {
        get => this.priority;
        set => this.SetProperty(ref this.priority, value);
    }

    [Display(Name = "Status")]
    public StatusEnum Status
    {
        get => this.status;
        set => this.SetProperty(ref this.status, value);
    }

}
