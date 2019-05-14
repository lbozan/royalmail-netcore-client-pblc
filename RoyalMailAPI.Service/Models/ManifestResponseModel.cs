namespace RoyalMailAPI.Service.Models
{
    public class ManifestResponseModel : ErrorResponseModel
    {
        public int BatchNumber { get; set; }
        public int Count { get; set; }
        public string Manifest { get; set; }
        public ManifestShipmentsModel Shipments { get; set; }

    }
}
