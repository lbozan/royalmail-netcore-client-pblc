using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ContentDetailModel
    {
        [Required]
        public string CountryOfManufactureCode { get; set; }
        public string ManufacturersName { get; set; }
        public string Description { get; set; }
        public MeasurementModel UnitWeight { get; set; }
        [Required]
        public int UnitQuantity { get; set; }
        [Required]
        public float UnitValue { get; set; }
        [Required]
        public string CurrencyCode { get; set; }
        [MinLength(6,ErrorMessage ="Min value 6")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric")]
        public string TariffCode { get; set; }
        public string TariffDescription { get; set; }

    }
}
