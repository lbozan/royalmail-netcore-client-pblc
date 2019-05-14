using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ShipmentBarcodeItemModel
    {
        [Required]
        public string ShipmentNumber { get; set; }
        [Required]
        public string ItemID { get; set; }
        [Required]
        public string Status { get; set; }
        public string ValidFrom { get; set; }
        public string Label { get; set; }
    }
}
