using Microsoft.AspNetCore.Mvc;
using RoyalMailAPI.Service.Models;
using RoyalMailAPI.Service.Service.RoyalMailService;
using RoyalMailAPI.Service.Service.TokenService;
using RoyalMailAPI.Web.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoyalMailAPI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IRoyalMailService _royalMail;
        public HomeController(IHttpClientFactory clientFactory,
                              IRoyalMailService royalMail)
        {
            _clientFactory = clientFactory;
            _royalMail = royalMail;
        }

        public async Task<IActionResult> Index()
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
                },
            };

            //await _royalMail.Domestic(model);
            //await _royalMail.DomesticT(model);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private async Task TestResponse()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.royalmail.net/shipping/v2/token");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("x-rmg-password", "XblyY7NOyFTZ84W2vl7x1FQWGXs=");
            request.Headers.Add("x-rmg-user-name", "JEM@EVOLUTIONPARTS.CO.UKAPI");
            request.Headers.Add("x-ibm-client-secret", "aI3sO1dG6mD3xO7qA1nC6vE7jQ4dA3tL2aX4aN4tC0fS2hH4hU");
            request.Headers.Add("x-ibm-client-id", "93dbeb72-c08b-4891-a1af-51303bce43a8");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                try
                {

                    var data = await response.Content.ReadAsAsync<TokenModel>();
                    var testdata = data;

                }
                catch (Exception ex)
                {
                    string exx = ex.Message;
                }
            }
            else
            {

                var data = Array.Empty<string>();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
