using Newtonsoft.Json;
using SaAddressApi.Net.Model.Base;

namespace SaAddressApi.Net.Model.Response
{
    //[JsonObject("")]
    public class ExtentsFeaturesResponse : BaseResponse
    {
        /// <summary>
        /// yMax
        /// </summary>
        [JsonProperty("maxy")]
        public double? NorthBound { get; set; }

        /// <summary>
        /// yMin
        /// </summary>
        [JsonProperty("miny")]
        public double? SouthBound { get; set; }

        /// <summary>
        /// xMax
        /// </summary>
        [JsonProperty("maxx")]
        public double? EastBound { get; set; }

        /// <summary>
        /// xMin
        /// </summary>
        [JsonProperty("minx")]
        public double? WestBound { get; set; }
    }
}
