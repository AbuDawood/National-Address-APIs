using Newtonsoft.Json;
using SaAddressApi.Net.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaAddressApi.Net.Model
{
    public class SaAddressV3 : SaAddressV4
    {
        [JsonProperty("PolygonString")]
        public string PolygonString { get; set; }

        [JsonProperty("IsPrimaryAddress")]
        public string IsPrimaryAddress { get; set; }

        [JsonProperty("UnitNumber")]
        public string UnitNumber { get; set; }

        [JsonProperty("Latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("CityId")]
        public string CityId { get; set; }

        [JsonProperty("RegionId")]
        public string RegionId { get; set; }

        [JsonProperty("Restriction")]
        public string Restriction { get; set; }

        [JsonProperty("PKAddressID")]
        public string PKAddressId { get; set; }

        [JsonProperty("DistrictID")]
        public string DistrictId { get; set; }

        [JsonProperty("Title_L2")]
        public string TitleL2 { get; set; }

        [JsonProperty("RegionName_L2")]
        public string RegionNameL2 { get; set; }

        [JsonProperty("City_L2")]
        public string CityL2 { get; set; }

        [JsonProperty("Street_L2")]
        public string StreetL2 { get; set; }

        [JsonProperty("District_L2")]
        public string DistrictL2 { get; set; }

        [JsonProperty("CompanyName_L2")]
        public string CompanyNameL2 { get; set; }

        [JsonProperty("GovernorateID")]
        public string GovernorateId { get; set; }

        [JsonProperty("Governorate")]
        public string Governorate { get; set; }

        [JsonProperty("Governorate_L2")]
        public string GovernorateL2 { get; set; }

    }
}
