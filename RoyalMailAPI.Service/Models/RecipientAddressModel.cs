using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class RecipientAddressModel
    {
        public string BuildingName { get; set; }
        public string BuildingNumber { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string StateOrProvince { get; set; }
        [Required]
        public string PostTown { get; set; }
        public string County { get; set; }
        [Required]
        public string PostCode { get; set; }
        [StringLength(2, MinimumLength = 2)]
        public string Country { get; set; }
    }
}
