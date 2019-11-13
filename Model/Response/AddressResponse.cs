using Newtonsoft.Json;
using SaAddressApi.Net.Model.Base;
using SaAddressApi.Net.Model.Interfaces;

namespace SaAddressApi.Net.Model.Response
{
    public class AddressResponse<T> : BaseResponse where T : ISaAddress
    {
        [JsonProperty("totalSearchResults")]
        public int? TotalSearchedResults { get; set; }

        [JsonProperty("Addresses")]
        public T[] Addresses { get; set; }

        [JsonProperty("PostCode")]
        public SaPostCodeObj[] PostCode { get; set; }

    }
}
