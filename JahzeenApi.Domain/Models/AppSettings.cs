using JahzeenApi.Domain.Models.Common;
using System;
using System.Collections.Generic;

namespace JahzeenApi.Domain.Models
{
    public partial class AppSettings : BaseModel
    {
        public string HomeTitle { get; set; }
        public string HomeDescription { get; set; }
        public string AboutUsTitle { get; set; }
        public string AboutUsPoint1 { get; set; }
        public string AboutUsPoint2 { get; set; }
        public string AboutUsPoint3 { get; set; }
        public string AboutUsPoint4 { get; set; }
        public string FeaturesTitle { get; set; }
        public string FeaturesDescription { get; set; }
        public string FeatureTitle1 { get; set; }
        public string FeatureTitle2 { get; set; }
        public string FeatureTitle3 { get; set; }
        public string FeatureTitle4 { get; set; }
        public string FeatureTitle5 { get; set; }
        public string FeatureTitle6 { get; set; }

        public string Feature1 { get; set; }
        public string Feature2 { get; set; }
        public string Feature3 { get; set; }
        public string Feature4 { get; set; }
        public string Feature5 { get; set; }
        public string Feature6 { get; set; } 
        public string ContactUsTitle { get; set; }
        public string ContactUsDescription { get; set; }
        public string FooterNote { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string AppleStore { get; set; }
        public string GoogleStore { get; set; }
    }
}
