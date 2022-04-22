using System;
using System.Collections.Generic;

namespace Domains.DTO
{
    public class DashboardResponseDTO
    {
        public List<DashboardDTO> Dashboards { get; set; }
        public DashboardChartDTO Charts { get; set; }

    }
    public class DashboardDTO
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }


    }
    public class DashboardChartDTO
    {
        public List<int> NumberOfApprovals { get; set; }
        public List<int> NumberOfUsers { get; set; }
        public DateTime MaximumNumberOfUsersDate { get; set; }
        public DateTime MaximumNumberOfApprovalsDate { get; set; }

    }
    public class AdminAuthDashboardChartDTO
    {
        public List<int> NumberOfEmployees { get; set; }
        public List<int> NumberOfEmployers { get; set; }
        public DateTime MaximumNumberOfEmployeesDate { get; set; }
        public DateTime MaximumNumberOfEmployersDate { get; set; }
    }
    public class AdminAuthDashboardResponseDTO
    {
        public List<DashboardDTO> Dashboards { get; set; }
        public AdminAuthDashboardChartDTO Charts { get; set; }

    }


}
