using Newtonsoft.Json;
using SaAddressApi.Net.Model;
using SaAddressApi.Net.Model.Base;
using System;

namespace SaAddressApi.Net
{


    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;

            StatusDescription status = StatusDescription.ServerException;

            if (enumString == "SUCCESS")
                status = StatusDescription.Success;

            if (enumString == "NO-RESULTS")
                status = StatusDescription.NoResults;

            return status;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            StatusDescription messageTransportResponseStatus = (StatusDescription)value;

            switch (messageTransportResponseStatus)
            {
                case StatusDescription.NoResults:
                    writer.WriteValue("NO-RESULTS");
                    break;

                case StatusDescription.Success:
                    writer.WriteValue("SUCCESS");
                    break;

                default:
                    writer.WriteValue("SERVER-EXCEPTION");
                    break;
            }
        }
    }

    internal class ObjLatLngConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var objLatLngStr = (string)reader.Value;

                var strArr = objLatLngStr.Split(' ');

                var objLatLng = new ObjLatLng
                {
                    Id = strArr[0],
                    Lng = double.Parse(strArr[1]),
                    Lat = double.Parse(strArr[2]),
                };


                return objLatLng;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objLatLng = (ObjLatLng)value;

            writer.WriteValue(string.Join(" ", objLatLng.Id, objLatLng.Lat, objLatLng.Lng));
        }
    }
}
