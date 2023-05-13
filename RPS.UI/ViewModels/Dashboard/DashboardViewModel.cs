using CommunityToolkit.Mvvm.ComponentModel;
using RPS.Core.Models.Dto;
using RPS.UI.BL;
using RPS.UI.Models;
using System.Collections.ObjectModel;

namespace RPS.UI.ViewModels.Dashboard;

public partial class DashboardViewModel : ObservableObject
{

    private readonly IPtDashboardRepository repo;

    [ObservableProperty]
    public DateTime? dateStart;
    [ObservableProperty]
    public DateTime? dateEnd;
    [ObservableProperty]
    public int issueCountOpen;
    [ObservableProperty]
    public int issueCountClosed;


    private DashboardMonthRange CurrentRange { get; set; }
        
    public ObservableCollection<DashboardMonthRange> Ranges { get; set; }



    public int IssueCountActive { get { return IssueCountOpen + IssueCountClosed; } }
    public decimal IssueCloseRate
    {
        get
        {
            if (IssueCountActive == 0)
            {
                return 0m;
            }
            return Math.Round((decimal)IssueCountClosed / (decimal)IssueCountActive * 100m, 2);
        }
    }


    public ChartViewModel ChartVm { get; set; }


    public DashboardViewModel(IPtDashboardRepository repo)
    {
        ChartVm = new ChartViewModel();
        this.repo = repo;
        Ranges = new ObservableCollection<DashboardMonthRange>
        {
            new DashboardMonthRange(3),
            new DashboardMonthRange(6),
            new DashboardMonthRange(12),
        };
        CurrentRange = Ranges.Last();
        LoadData(null);
    }

    public void UpdateMonthRange(DashboardMonthRange range)
    {
        CurrentRange = range;
        LoadData(null);
    }

    public void LoadData(int? userId)
    {
        var months = CurrentRange.NumberOfMonths;

        DateTime start = DateTime.Now.AddMonths(months * -1);
        DateTime end = DateTime.Now;

        PtDashboardFilter filter = new PtDashboardFilter
        {
            DateStart = start,
            DateEnd = end,
            UserId = userId.HasValue ? userId.Value : 0
        };

        var statusCounts = repo.GetStatusCounts(filter);
        IssueCountOpen = statusCounts.OpenItemsCount;
        IssueCountClosed = statusCounts.ClosedItemsCount;

        DateStart = filter.DateStart;
        DateEnd = filter.DateEnd;

        //Chart related
        var filteredIssues = repo.GetFilteredIssues(filter);

        ChartVm.OpenItemsData = new ObservableCollection<TemporalData>();
        ChartVm.ClosedItemsData = new ObservableCollection<TemporalData>();

        for (int i = 0; i < filteredIssues.Categories.Count; i++) 
        {
            var category = filteredIssues.Categories[i];
            var monthItems = filteredIssues.MonthItems[i];
            var itemsOpen = monthItems.Open.Count;
            var itemsClosed = monthItems.Closed.Count;
            ChartVm.OpenItemsData.Add(new TemporalData { Date = category, Value = itemsOpen });
            ChartVm.ClosedItemsData.Add(new TemporalData { Date = category, Value = itemsClosed });
        }
    }
}