using Newtonsoft.Json;
using SaAddressApi.Net.Model.Base;

namespace SaAddressApi.Net.Model.Response
{
    public class LookupResponse : BaseResponse
    {
        [JsonProperty("Regions")]
        public SaLookup[] Regions { get; set; }

        [JsonProperty("Cities")]
        public SaLookup[] Cities { get; set; }

        [JsonProperty("Districts")]
        public SaLookup[] Districts { get; set; }

        [JsonProperty("ServiceCategories")]
        public SaLookup[] ServiceCategories { get; set; }

        [JsonProperty("ServiceSubCategories")]
        public SaLookup[] ServiceSubCategories { get; set; }
    }
}
