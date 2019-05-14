using RoyalMailAPI.Service.Enums;
using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class MeasurementModel
    {
        [Required]
        public EUnitOfMeasure UnitOfMeasure { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
