namespace SaAddressApi.Net.Model.Interfaces
{
    public interface ISaAddress
    {
        string Title { get; set; }

        string Address1 { get; set; }

        string Address2 { get; set; }

        ObjLatLng ObjLatLng { get; set; }

        string BuildingNumber { get; set; }

        string Street { get; set; }

        string District { get; set; }

        string City { get; set; }

        string PostCode { get; set; }

        string AdditionalNumber { get; set; }

        string RegionName { get; set; }
    }
}