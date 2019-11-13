using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaAddressApi.Net.Model.Base
{
    public enum StatusDescription
    {
        ServerException,
        NoResults, //NO-RESULTS
        Success // SUCCESS
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class BaseResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("statusdescription")]
        [JsonConverter(typeof(StatusConverter))]
        public StatusDescription StatusDescription { get; set; }

        [JsonProperty("fullexception")]
        public string FullException { get; set; }

    }
}
