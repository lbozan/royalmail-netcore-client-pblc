using System.Collections.Generic;

namespace RoyalMailAPI.Service.Models
{
    public class CompletedShipmentsModel
    {
        public List<ShipmentWithBarcodeAndWeightModel> Items { get; set; }
    }
}
