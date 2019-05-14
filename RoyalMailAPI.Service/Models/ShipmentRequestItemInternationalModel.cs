using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ShipmentRequestItemInternationalModel
    {
        [Required]
        public int Count { get; set; }
        [Required]
        public MeasurementModel Weight { get; set; }
    }
}
