using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ContactModel
    {
        public string Name { get; set; }
        public string ComplementaryName { get; set; }
        public string TelephoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
