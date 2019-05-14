using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ShipmentRequestItemModel
    {
        public List<OfflineShipmentModel> OfflineShipment { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public MeasurementModel Weight { get; set; }
    }
}
