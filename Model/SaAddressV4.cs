using Newtonsoft.Json;
using SaAddressApi.Net.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaAddressApi.Net.Model
{
    public class SaAddressV4 : ISaAddress
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Address1")]
        public string Address1 { get; set; }

        [JsonProperty("Address2")]
        public string Address2 { get; set; }

        [JsonProperty("ObjLatLng")]
        [JsonConverter(typeof(ObjLatLngConverter))]
        public ObjLatLng ObjLatLng { get; set; }

        [JsonProperty("BuildingNumber")]
        public string BuildingNumber { get; set; }

        [JsonProperty("Street")]
        public string Street { get; set; }

        [JsonProperty("District")]
        public string District { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("PostCode")]
        public string PostCode { get; set; }

        [JsonProperty("AdditionalNumber")]
        public string AdditionalNumber { get; set; }

        [JsonProperty("RegionName")]
        public string RegionName { get; set; }

    }
}
