using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class AddressModel
    {
        public string BuildingName { get; set; }
        public string BuildingNumber { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required]
        public string PostTown { get; set; }
        public string County { get; set; }
        [Required]
        public string PostCode { get; set; }
        public string CountryCode { get; set; }
    }
}
