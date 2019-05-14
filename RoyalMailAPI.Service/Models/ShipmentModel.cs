using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ShipmentModel
    {
        [Required]
         public string ShipmentType { get; set; }
        [Required]
        public ServiceModel Service { get; set; }
        public string ShippingDate { get; set; }
        public List<ShipmentRequestItemModel> Items { get; set; }
        [Required]
        public ContactModel RecipientContact { get; set; }
        [Required]
        public AddressModel RecipientAddress { get; set; }
        public string SenderReference { get; set; }
        public string DepartmentReference { get; set; }
        public string CustomerReference { get; set; }
        public string SafePlace { get; set; }

    }
}
