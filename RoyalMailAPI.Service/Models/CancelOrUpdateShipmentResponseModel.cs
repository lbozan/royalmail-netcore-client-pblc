using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class CancelOrUpdateShipmentResponseModel : ErrorResponseModel
    {
        [Required]
        public string ShipmentNumber { get; set; }
    }
}
