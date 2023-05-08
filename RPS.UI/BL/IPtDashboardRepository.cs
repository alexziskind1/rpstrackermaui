using RPS.Core.Models.Dto;

namespace RPS.BL
{
    public interface IPtDashboardRepository
    {
        PtDashboardStatusCounts GetStatusCounts(PtDashboardFilter filter);
        PtDashboardFilteredIssues GetFilteredIssues(PtDashboardFilter filter);
    }
}
