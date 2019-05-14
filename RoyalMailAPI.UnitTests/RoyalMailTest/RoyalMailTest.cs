using Moq;
using RoyalMailAPI.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace RoyalMailAPI.UnitTests.RoyalMailTest
{

    public interface IRoyalMailTest
    {
        Task<CreatedShipmentResponseModel> Domestic(ShipmentModel model);
        Task<CreatedShipmentResponseModel> Shipment(ShipmentModel model);
        Task<DocumentsRequestModel> Shipments(ShipmentModel model);
        Task<CancelOrUpdateShipmentResponseModel> ShipmentPUTCancel(int shipmentNumber, ShipmentModel model);
        Task<CancelOrUpdateShipmentResponseModel> ShipmentDELETE(int shipmentNumber, ShipmentModel model);
        Task<LabelResponseModel> ShipmentPUT(int shipmentNumber, ShipmentModel model);
        Task<ManifestResponseModel> ManifestPOST(ManifestRequestModel model);
        Task<PrintManifestResponseModel> ManifestPUT(ManifestRequestModel model);
    }
    public class RoyalMailTest
    {
        private readonly IRoyalMailTest _royalMail;

        public RoyalMailTest()
        {

            var mock = new Mock<IRoyalMailTest>();

            mock.Setup(service => service.Domestic(It.IsAny<ShipmentModel>()))
                .ReturnsAsync((ShipmentModel model) =>
                {
                    if (model is null)
                        throw new NullReferenceException("Model boş göderilemez");

                    if (Validate(model).Count > 0)
                        throw new ArgumentNullException("ShipmentType boş gönderilemez");

                    if (Validate(model.Service).Count > 0)
                        throw new ArgumentNullException("Service boş gönderilemez");

                    if (Validate(model.RecipientContact).Count > 0)
                        throw new ArgumentNullException("Contact boş gönderilemez");

                    if (Validate(model.RecipientAddress).Count > 0)
                        throw new ArgumentNullException("Address boş gönderilemez");

                    return new CreatedShipmentResponseModel() { HttpCode = "201" };
                });

            _royalMail = mock.Object;
        }

        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
            return results;
        }

        [Fact(DisplayName = "Domestic Success")]
        public async Task DomesticTest()
        {
            ShipmentModel model = new ShipmentModel()
            {
                ShipmentType = "type",
                Service = new ServiceModel()
                {
                    Offering = "test",
                    Type = "type"
                },
                RecipientAddress = new AddressModel()
                {
                    AddressLine1 = "adres",
                    PostCode = "21500",
                    PostTown = "ilce"
                },
                RecipientContact = new ContactModel()
                {
                    Email = "test@msn.com"
                }
            };
            var data = await _royalMail.Domestic(model);
            Assert.NotNull(data);
            Assert.IsType<CreatedShipmentResponseModel>(data);
            Assert.Equal("201", data.HttpCode);
        }

        [Fact(DisplayName = "Domestic Success")]
        public async Task DomesticExceptionTest()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() => _royalMail.Domestic(null));

            ShipmentModel model = new ShipmentModel();

            await Assert.ThrowsAsync<ArgumentNullException>(() => _royalMail.Domestic(model));
            model.ShipmentType = "type";
            await Assert.ThrowsAsync<ArgumentNullException>(() => _royalMail.Domestic(model));
            model.Service = new ServiceModel()
            {
                Offering = "test",
                Type = "type"
            };
            await Assert.ThrowsAsync<ArgumentNullException>(() => _royalMail.Domestic(model));
            model.RecipientAddress = new AddressModel()
            {
                AddressLine1 = "adres",
                PostCode = "21500",
                PostTown = "ilce"
            };
            await Assert.ThrowsAsync<ArgumentNullException>(() => _royalMail.Domestic(model));
            model.RecipientContact = new ContactModel()
            {
                Email = "test@msn.com"
            };
        }
    }
}
