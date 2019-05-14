using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RoyalMailAPI.Service.Models;
using RoyalMailAPI.Service.Service.TokenService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RoyalMailAPI.Service.Service.RoyalMailService
{
    public class RoyalMailService : IRoyalMailService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ITokenService _token;

        public RoyalMailService(IHttpClientFactory clientFactory,
                                ITokenService token)
        {
            _clientFactory = clientFactory;
            _token = token;
        }

        public async Task<CreatedShipmentResponseModel> Domestic(ShipmentModel model)
        {
            string token = (await _token.GetToken()).Token;

            #region IsValid
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
            #endregion

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.royalmail.net/shipping/v2/domestic");
            request.Headers.Add("x-ibm-client-secret", "***");
            request.Headers.Add("x-ibm-client-id", "***");
            request.Headers.Add("X-RMG-Auth-Token", $"{token}");

            var serializeSetting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(model, serializeSetting);

            CreatedShipmentResponseModel resultModel;
            using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                request.Content = stringContent;

                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.SendAsync(request);

                var res = await response.Content.ReadAsStringAsync();
                resultModel = JsonConvert.DeserializeObject<CreatedShipmentResponseModel>(res);
            }
            return resultModel;
        }

        public async Task<CreatedShipmentResponseModel> DomesticT(ShipmentModel model)
        {
            #region IsValid
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
            #endregion

            var result = await GetRequest<CreatedShipmentResponseModel, ShipmentModel>(model, "domestic");
            return result;
        }

        private async Task<T> GetRequest<T, X>(X model, string url)
        {
            string tokenString = await TokenString();
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.royalmail.net/shipping/v2/{url}");
            request.Headers.Add("x-ibm-client-secret", "***");
            request.Headers.Add("x-ibm-client-id", "***");
            request.Headers.Add("X-RMG-Auth-Token", $"{tokenString}");

            var serializeSetting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(model, serializeSetting);

            T resultModel;
            using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                request.Content = stringContent;

                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.SendAsync(request);

                var res = await response.Content.ReadAsStringAsync();
                resultModel = JsonConvert.DeserializeObject<T>(res);
            }
            return resultModel;
        }

        private async Task<string> TokenString()
        {
            return (await _token.GetToken()).Token;
        }

        public static IList<ValidationResult> Validate(object model)
        {
            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, results, true);
            if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
            return results;
        }
    }
}
