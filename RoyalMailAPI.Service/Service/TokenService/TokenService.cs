using Newtonsoft.Json;
using RoyalMailAPI.Service.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RoyalMailAPI.Service.Service.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IHttpClientFactory _clientFactory;

        public TokenService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TokenModel> GetToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.royalmail.net/shipping/v2/token");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("x-rmg-password", "***");
            request.Headers.Add("x-rmg-user-name", "***");
            request.Headers.Add("x-ibm-client-secret", "***");
            request.Headers.Add("x-ibm-client-id", "***");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                TokenModel model = JsonConvert.DeserializeObject<TokenModel>(res);
                return model;
            }

            return new TokenModel();
        }
    }
}
