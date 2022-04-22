namespace Domains.SearchModels
{
    public partial class PersonSearch : BaseSearch
    {

        public string SearchValue { get; set; }
        public int? ApprovalStatus { get; set; }
    }
    public partial class PersonAdvanceSearch : BaseSearch
    {

        public string Sector { get; set; }
        public string SubSector { get; set; }
        public string Group { get; set; }
        public string Filter { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Street { get; set; }
        public int? Gender { get; set; }
        public string JobTitle { get; set; }
        public string NoOfEmployees { get; set; }
        public string TitleLevel { get; set; }
        public string PhoneNo { get; set; }
    }
}
