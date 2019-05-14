using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class RecipientContactModel
    {
        [Required]
        public string Name { get; set; }
        public string ComplementaryName { get; set; }
        public string TelephoneNumber { get; set; }
        public string ElectronicAddress { get; set; }
    }
}
