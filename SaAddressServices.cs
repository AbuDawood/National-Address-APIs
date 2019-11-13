using SaAddressApi.Net.Model;
using SaAddressApi.Net.Model.Response;
using System.Threading.Tasks;
using static SaAddressApi.Net.SaAddressRequests;

namespace SaAddressApi.Net
{
    public class SaAddressServices
    {
        private SaAddressRequests SaAddressRequests { get; set; }

        public SaAddressServices(bool use2ndKey = false, string language = "A", string format = "json", string encode = null)
        {
            SaAddressRequests = new SaAddressRequests(use2ndKey, language, format, encode);
        }

        //**
        /// SERVICES
        //**

        public async Task<AddressResponse<SaAddressV4>> AddressV4FreeTextAsync(string addressstring, int page = 1)
        {
            var result = await SaAddressRequests.AddressV4FreeTextAsync(addressstring, page);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse<SaAddressV4>>(content);
        }

        public async Task<AddressResponse<SaAddressV3>> AddressV3FreeTextAsync(string addressstring, int page = 1)
        {
            var result = await SaAddressRequests.AddressV3FreeTextAsync(addressstring, page);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse<SaAddressV3>>(content);
        }

        public async Task<AddressResponse<SaAddressV3>> AddressByGeocodeAsync(double lat, double lng, int page = 1)
        {
            var result = await SaAddressRequests.AddressByGeocodeAsync(lat, lng, page);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse<SaAddressV3>>(content);
        }

        public async Task<AddressResponse<SaAddressV3>> AddressFixedParamsAsync(string cityId = null, string districtId = null,
            string buildingNumber = null, string zipcode = null, string additionalNumber = null, string cityName = null,
            string districtName = null, string streetName = null, int page = 1)
        {
            var result = await SaAddressRequests.AddressFixedParamsAsync(cityId, districtId, buildingNumber, zipcode,
                additionalNumber, cityName, districtName, streetName, page);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse<SaAddressV3>>(content);
        }

        public async Task<VerifyAddressResponse> VerifyAddressAsync(string buildingNumber = null, string zipCode = null,
            string additionalNumber = null)
        {
            var result = await SaAddressRequests.VerifyAddressAsync(buildingNumber, zipCode, additionalNumber);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<VerifyAddressResponse>(content);
        }

        public async Task<AddressResponse<SaAddressV3>> PoiFreeTextAsync(string serviceString, int page = 1)
        {
            var result = await SaAddressRequests.PoiFreeTextAsync(serviceString, page);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse<SaAddressV3>>(content);
        }

        public async Task<AddressResponse<SaAddressV3>> PoiFixedParamsAsync(string serviceString = null, string cityId = null, string districtId = null,
            string buildingNumber = null, string zipCode = null, string additionalNumber = null,
            string cityName = null, string districtName = null, string streetName = null,
            string servicecategoryId = null, string servicesubcategoryId = null, string regionId = null, int page = 1)
        {

            var result = await SaAddressRequests.PoiFixedParamsAsync(serviceString, cityId, districtId, buildingNumber,
                zipCode, additionalNumber, cityName, districtName, streetName, servicecategoryId, servicesubcategoryId,
                regionId, page);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse<SaAddressV3>>(content);
        }

        public async Task<LookupResponse> LookupRegionsAsync()
        {

            var result = await SaAddressRequests.LookupRegionsAsync();
            var content = await result.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<LookupResponse>(content);
        }

        public async Task<LookupResponse> LookupCitiesAsync(string regionId = "-1")
        {

            var result = await SaAddressRequests.LookupCitiesAsync(regionId);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<LookupResponse>(content);
        }

        public async Task<LookupResponse> LookupDistrictsAsync(string cityId)
        {

            var result = await SaAddressRequests.LookupDistrictsAsync(cityId);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<LookupResponse>(content);
        }

        public async Task<LookupResponse> LookupServiceCategoryAsync()
        {
            var result = await SaAddressRequests.LookupServiceCategoryAsync();
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<LookupResponse>(content);
        }

        public async Task<LookupResponse> LookupSubserviceCategoryAsync(string serviceCategoryId)
        {
            var result = await SaAddressRequests.LookupSubserviceCategoryAsync(serviceCategoryId);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<LookupResponse>(content);
        }

        /// <summary>
        /// Search bulk address API allows user to find complete details of multiple address by providing building number,
        /// zip code for the addresses. You can decide to use Json or XML as an output format in addition to language of your choice 
        /// from Arabic or English.
        /// </summary>
        /// <param name="addressstring">
        /// Address attributes would be separated with a pipe. Whereas, 
        /// each address would be separated from others with a semicolon.
        /// BuildingNumber|ZipCode|AdditionalNumber; 
        /// For example, 8228|12643|2121;3908|12991|8966;….. upto 10. 
        /// NOTE: Even if the string contains more than 10 addresses, the 1st 10 addresses will be considered where the rest would be discarded.
        /// </param>
        /// <param name="page">
        /// By default each request returns a maximum number of 10 results. If there are a large number of results, in such a case, this page number must be passed along to get the next set of results. Default value is 1.
        /// </param>
        public async Task<AddressResponse<SaAddressV3>> BulkSearchAsync(string addressstring, int page = 1)
        {
            var result = await SaAddressRequests.BulkSearchAsync(addressstring, page);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse<SaAddressV3>>(content);
        }

        public async Task<AddressResponse<SaAddressV3>> NearestPoiAsync(string serviceCategoryId,
            double lat, double lng, double radius = 0.5,
            int page = 1)
        {
            var result = await SaAddressRequests.NearestPoiAsync(serviceCategoryId, lat, lng, radius, page);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse<SaAddressV3>>(content);
        }

        public async Task<ExtentsFeaturesResponse> ExtentsFeaturesAsync(LayerName layerName, string featureId)
        {
            var result = await SaAddressRequests.ExtentsFeaturesAsync(layerName, featureId);
            var content = await result.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<ExtentsFeaturesResponse>(content);
        }
    }
}
