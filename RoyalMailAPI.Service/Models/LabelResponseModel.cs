namespace RoyalMailAPI.Service.Models
{
    public class LabelResponseModel : ErrorResponseModel
    {
        public string Label { get; set; }
        public LabelImagesModel LabelImages { get; set; }
        public string Format { get; set; }
        public LabelImagesModel LabelData { get; set; }
        public RecipientAddressModel RecipientAddress { get; set; }
        public RecipientContactModel RecipientContact { get; set; }
    }

    public class LabelDataModel
    {
        public string UpuCode { get; set; }
        public string InformationTypeID { get; set; }
        public string VersionID { get; set; }
        public string Format { get; set; }
        public string MailType { get; set; }
        public string ItemID { get; set; }
        public string CheckDigit { get; set; }
        public string ItemWeight { get; set; }
        public string WeightType { get; set; }
        public string Product { get; set; }
        public string TrackingNumber { get; set; }
        public string DestinationPostcodeDPS { get; set; }
        public string ReturnToSenderPostcode { get; set; }
        public string RequiredAtDelivery { get; set; }
        public string BuildingNumber { get; set; }
        public string BuildingName { get; set; }
        public string DateOfShipment { get; set; }

    }
}
