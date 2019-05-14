using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ServiceModel
    {
        public string Format { get; set; }
        public string Occurence { get; set; }
        [Required]
        public string Offering { get; set; }
        [Required]
        public string Type { get; set; }
        public string Singature { get; set; }
        public ServiceEnhancementsModel Enhancements { get; set; }
    }
}
