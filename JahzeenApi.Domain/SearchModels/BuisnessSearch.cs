using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.SearchModels
{
    public partial class BuisnessSearch : BaseSearch
    {

        public string SearchValue { get; set; }
        public int? ApprovalStatus { get; set; }
    }
    public partial class BuisnessAdvanceSearch : BaseSearch
    {

        public string Sector { get; set; }
        public string Group { get; set; }
        public string SubSector { get; set; }
        public string Filter { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Street { get; set; }
        public string ComplexName { get; set; }
        public string ComplexNo { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string PostalCode { get; set; }
        public string PoBox { get; set; }
        public string NationalId { get; set; }
        public string NoOfEmployees { get; set; }
        public string BusinessStatus { get; set; }
        public string CorporateType { get; set; }
        public string PartnerNationality { get; set; }
        public int? AccountTypeId { get; set; }
    }
}
