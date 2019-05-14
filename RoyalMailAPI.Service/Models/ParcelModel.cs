using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ParcelModel
    {
        public MeasurementModel Weight { get; set; }
        public MeasurementModel Length { get; set; }
        public MeasurementModel Height { get; set; }
        public MeasurementModel Width { get; set; }
        public string PurposeOfShipment { get; set; }
        public string Explanation { get; set; }
        public string InvoiceNumber { get; set; }
        public string ExportLicenseNumber { get; set; }
        public string CertificateNumber { get; set; }
        [Required]
        public List<ContentDetailModel> ContentDetails { get; set; }
        public float Fees { get; set; }
    }
}
