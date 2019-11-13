namespace SaAddressApi.Net
{


    /// <summary>
    /// Main config for the SaAddress API, use register at the startup
    /// </summary>
    public static partial class SaAddressConfig
    {

        internal static bool isRegitered = false;

        internal static string SaAdrsBaseUrl { get; set; }

        internal static string SaAdrsApiKey1 { get; set; }

        internal static string SaAdrsApiKey2 { get; set; }

        public static void Register(string baseUrl, string key1, string key2)
        {
            SaAdrsBaseUrl = baseUrl;
            SaAdrsApiKey1 = key1;
            SaAdrsApiKey2 = key2;

            isRegitered = true;
        }
    }
}
