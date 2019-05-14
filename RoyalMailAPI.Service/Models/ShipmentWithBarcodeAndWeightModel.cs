namespace RoyalMailAPI.Service.Models
{
    public class ShipmentWithBarcodeAndWeightModel
    {
        public ShipmentBarcodeItemsModel ShipmentItems { get; set; }
        public MeasurementModel Weight { get; set; }
    }
}
