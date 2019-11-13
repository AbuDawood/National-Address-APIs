using Newtonsoft.Json;
using SaAddressApi.Net.Model.Base;

namespace SaAddressApi.Net.Model.Response
{
    public class VerifyAddressResponse : BaseResponse
    {
        [JsonProperty("addressfound")]
        public bool AddressFound { get; set; }
    }
}
