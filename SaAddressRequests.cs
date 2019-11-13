using Mono.Web;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SaAddressApi.Net
{
    /// <summary>
    /// Type of area
    /// </summary>
    public enum LayerName
    {
        regions,
        cities,
        districts,
        streets,
        zipcodes
    }

    internal class SaAddressRequests
    {
        /// <summary>
        /// Requested service
        /// </summary>
        public enum RequestedService
        {
            LookupCities,

            LookupRegions,

            LookupDistricts,

            LookupServiceCategory,

            LookupSubserviceCategory,

            FreeTextSearchV4,

            FreeTextSearchV3,

            AddressByFixedParams,

            AddressByGeocode,

            verifyAddress,

            PoiByFixedParams,

            PoiByFreeText,

            ExtentsFeatures,

            BulkSearch,

            NearestPoi
        }

        private const string LookupCitiesSubUrl = "v3.1/lookup/cities?";

        private const string LookupRegionsSubUrl = "v3.1/lookup/regions?";

        private const string LookupDistrictsSubUrl = "v3.1/lookup/districts?";

        private const string LookupServiceCategorySubUrl = "v3.1/lookup/service-categories?";

        private const string LookupSubserviceCategorySubUrl = "v3.1/lookup/services-sub-categories?";

        private const string FreeTextSearchV4SubUrl = "v4/Address/address-free-text?";

        private const string FreeTextSearchV3SubUrl = "v3.1/Address/address-free-text?";

        private const string VerifyAddressSubUrl = "v3.1/Address/address-verify?";

        private const string AddressByFixedParamsSubUrl = "v3.1/Address/address-fixed-params?";

        private const string AddressByGeocodeSubUrl = "v3.1/Address/address-geocode?";

        private const string PoiByFixedParamsSubUrl = "v3.1/Address/poi-fixed-params?";

        private const string PoiByFreeTextSubUrl = "v3.1/Address/poi-free-text?";

        private const string ExtentsFeaturesSubUrl = "v3.1/Address/get-feature-extents?";

        private const string BulkSearchSubUrl = "v3.1/Address/address-bulk?";

        private const string NearestPoiSubUrl = "v3.1/Address/poi-nearest?";

        // construct
        private readonly bool _use2ndKey;
        private readonly string _language;
        private readonly string _format;
        private readonly string _encode;

        public SaAddressRequests(bool use2ndKey = false, string language = "A", string format = "json", string encode = null)
        {
            _use2ndKey = use2ndKey;
            _language = language;
            _format = format;
            _encode = encode;
        }

        //**
        ///**
        //**

        public async Task<HttpResponseMessage> AddressV4FreeTextAsync(string addressstring, int page = 1)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            queryString["addressstring"] = addressstring;

            return await BaseRequestAsync(queryString, RequestedService.FreeTextSearchV4, page);
        }

        public async Task<HttpResponseMessage> AddressV3FreeTextAsync(string addressstring, int page = 1)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            queryString["addressstring"] = addressstring;

            return await BaseRequestAsync(queryString, RequestedService.FreeTextSearchV3, page);
        }

        public async Task<HttpResponseMessage> AddressByGeocodeAsync(double lat, double lng, int page = 1)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request parameters
            queryString["lat"] = lat.ToString();
            queryString["long"] = lng.ToString();

            return await BaseRequestAsync(queryString, RequestedService.AddressByGeocode, page);

        }

        public async Task<HttpResponseMessage> AddressFixedParamsAsync(string cityId = null, string districtId = null,
            string buildingNumber = null, string zipcode = null, string additionalNumber = null, string cityName = null,
            string districtName = null, string streetName = null, int page = 1)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request parameters
            queryString["cityId"] = cityId;
            queryString["districtId"] = districtId;
            queryString["buildingnumber"] = buildingNumber;
            queryString["zipcode"] = zipcode;
            queryString["additionalnumber"] = additionalNumber;
            queryString["cityname"] = cityName;
            queryString["districtname"] = districtName;
            queryString["streetname"] = streetName;

            return await BaseRequestAsync(queryString, RequestedService.AddressByFixedParams, page);

        }

        public async Task<HttpResponseMessage> VerifyAddressAsync(string buildingNumber = null, string zipCode = null,
            string additionalNumber = null)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["buildingnumber"] = buildingNumber;
            queryString["zipcode"] = zipCode;
            queryString["additionalnumber"] = additionalNumber;

            return await BaseRequestAsync(queryString, RequestedService.verifyAddress);
        }

        public async Task<HttpResponseMessage> PoiFreeTextAsync(string serviceString, int page = 1)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request parameters
            queryString["servicestring"] = serviceString;

            return await BaseRequestAsync(queryString, RequestedService.PoiByFreeText, page);

        }

        public async Task<HttpResponseMessage> PoiFixedParamsAsync(string serviceString = null, string cityId = null, string districtId = null,
            string buildingNumber = null, string zipCode = null, string additionalNumber = null,
            string cityName = null, string districtName = null, string streetName = null,
            string servicecategoryId = null, string servicesubcategoryId = null, string regionId = null, int page = 1)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["servicestring"] = serviceString;
            queryString["cityId"] = cityId;
            queryString["districtId"] = districtId;
            queryString["buildingnumber"] = buildingNumber;
            queryString["zipcode"] = zipCode;
            queryString["additionalnumber"] = additionalNumber;
            queryString["cityname"] = cityName;
            queryString["districtname"] = districtName;
            queryString["streetname"] = streetName;
            queryString["servicecategoryId"] = servicecategoryId;
            queryString["servicesubcategoryId"] = servicesubcategoryId;
            queryString["regionid"] = regionId;

            return await BaseRequestAsync(queryString, RequestedService.PoiByFixedParams, page);

        }

        public async Task<HttpResponseMessage> LookupRegionsAsync()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            return await BaseRequestAsync(queryString, RequestedService.LookupRegions);
        }

        public async Task<HttpResponseMessage> LookupCitiesAsync(string regionId = "-1")
        {

            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["regionid"] = regionId;

            return await BaseRequestAsync(queryString, RequestedService.LookupCities);

        }

        public async Task<HttpResponseMessage> LookupDistrictsAsync(string cityId)
        {

            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["cityid"] = cityId;

            return await BaseRequestAsync(queryString, RequestedService.LookupDistricts);

        }

        public async Task<HttpResponseMessage> LookupServiceCategoryAsync()
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            return await BaseRequestAsync(queryString, RequestedService.LookupServiceCategory);
        }

        public async Task<HttpResponseMessage> LookupSubserviceCategoryAsync(string serviceCategoryId)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["servicecategoryid"] = serviceCategoryId;

            return await BaseRequestAsync(queryString, RequestedService.LookupSubserviceCategory);
        }

        public async Task<HttpResponseMessage> BulkSearchAsync(string addressstring, int page = 1)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["addressstring"] = addressstring;

            return await BaseRequestAsync(queryString, RequestedService.BulkSearch, page);
        }

        public async Task<HttpResponseMessage> NearestPoiAsync(string serviceCategoryId,
            double lat, double lng, double radius = 0.5,
            int page = 1)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["servicecategoryid"] = serviceCategoryId;
            queryString["long"] = lng.ToString();
            queryString["lat"] = lat.ToString();
            queryString["radius"] = radius.ToString();

            return await BaseRequestAsync(queryString, RequestedService.NearestPoi, page);
        }

        public async Task<HttpResponseMessage> ExtentsFeaturesAsync(LayerName layerName, string featureId)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            string layerNameString = string.Empty;

            switch (layerName)
            {
                case LayerName.cities:
                    layerNameString = "cities";
                    break;
                case LayerName.districts:
                    layerNameString = "districts";
                    break;
                case LayerName.regions:
                    layerNameString = "regions";
                    break;
                case LayerName.streets:
                    layerNameString = "streets";
                    break;
                case LayerName.zipcodes:
                    layerNameString = "zipcodes";
                    break;
            }

            queryString["layername"] = layerNameString;

            queryString["featureid"] = featureId;

            return await BaseRequestAsync(queryString, RequestedService.ExtentsFeatures);
        }


        //TODO: Missed are : bulk search, Get Extents Of A Feature, Nearest POI's, 



        /// <summary>
        /// the base request of saudi national address
        /// </summary>
        private async Task<HttpResponseMessage> BaseRequestAsync(NameValueCollection urlParams, RequestedService requestedElement, int page = 1)
        {
            if (!SaAddressConfig.isRegitered)
                throw new System.Exception("the library is not regitered, Please register first!");

            var subUrl = string.Empty;

            urlParams["language"] = _language;

            urlParams["format"] = _format;

            urlParams["encode"] = _encode;

            urlParams["page"] = page.ToString();

            switch (requestedElement)
            {
                case RequestedService.AddressByFixedParams:
                    subUrl = AddressByFixedParamsSubUrl;
                    break;

                case RequestedService.AddressByGeocode:
                    subUrl = AddressByGeocodeSubUrl;
                    break;

                case RequestedService.FreeTextSearchV4:
                    subUrl = FreeTextSearchV4SubUrl;
                    break;

                case RequestedService.FreeTextSearchV3:
                    subUrl = FreeTextSearchV3SubUrl;
                    break;

                case RequestedService.LookupCities:
                    subUrl = LookupCitiesSubUrl;
                    break;

                case RequestedService.LookupDistricts:
                    subUrl = LookupDistrictsSubUrl;
                    break;

                case RequestedService.LookupRegions:
                    subUrl = LookupRegionsSubUrl;
                    break;

                case RequestedService.PoiByFixedParams:
                    subUrl = PoiByFixedParamsSubUrl;
                    break;

                case RequestedService.PoiByFreeText:
                    subUrl = PoiByFreeTextSubUrl;
                    break;

                case RequestedService.verifyAddress:
                    subUrl = VerifyAddressSubUrl;
                    break;

                case RequestedService.LookupServiceCategory:
                    subUrl = LookupServiceCategorySubUrl;
                    break;

                case RequestedService.LookupSubserviceCategory:
                    subUrl = LookupSubserviceCategorySubUrl;
                    break;

                case RequestedService.BulkSearch:
                    subUrl = BulkSearchSubUrl;
                    break;

                case RequestedService.NearestPoi:
                    subUrl = NearestPoiSubUrl;
                    break;

                case RequestedService.ExtentsFeatures:
                    subUrl = ExtentsFeaturesSubUrl;
                    break;
            }

            HttpClient client = new HttpClient();

            var key = _use2ndKey ? SaAddressConfig.SaAdrsApiKey2 : SaAddressConfig.SaAdrsApiKey1;

            // Request headers
            client.DefaultRequestHeaders.Add("api_key", key);

            var uri = SaAddressConfig.SaAdrsBaseUrl + subUrl + urlParams;

            return await client.GetAsync(uri);
        }


    }

}
