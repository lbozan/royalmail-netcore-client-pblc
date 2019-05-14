using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class ShipmentsRequestModel
    {
        [Required]
        public string ShipmentType { get; set; }
        [Required]
        public ServiceModel Service { get; set; }
        public string BfpoCode { get; set; }
        public string ShippingDate { get; set; }
        public List<ShipmentRequestItemInternationalModel> Items { get; set; }
        [Required]
        public ContactModel RecipientContact { get; set; }
        [Required]
        public AddressModel RecipientAddress { get; set; }
        public string SenderReference { get; set; }
        public string DepartmentReference { get; set; }
        public string CustomerReference { get; set; }
        public string SafePlace { get; set; }
        [Required]
        public InternationalInfoModel InternationalInfo { get; set; }
    }

    public class InternationalInfoModel
    {
        [Required]
        public List<ParcelModel> Parcels { get; set; }
        public string ShipperExporterVatNo { get; set; }
        public string RecipientImportersVatNo { get; set; }
        public string OriginalExportShipmentNo { get; set; }
        public bool DocumentsOnly { get; set; }
        public string ShipmentDescription { get; set; }
        public string Comments { get; set; }
        public string InvoiceDate { get; set; }
        [StringLength(3)]
        public string TermsOfDelivery { get; set; }
        public string PurchaseOrderRef { get; set; }


    }
}
