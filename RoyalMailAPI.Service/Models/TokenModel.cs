using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class TokenModel
    {
        [Required]
        public string Token { get; set; }
    }
}
