using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class CreatedShipmentResponseModel : ErrorResponseModel
    {
        [Required]
        public CompletedShipmentsModel ComplatedShipments { get; set; }
    }
}
