using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaAddressApi.Net.Model
{
    public class SaPostCodeObj
    {
        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("hasParcels")]
        public string HasParcels { get; set; }
    }
}
