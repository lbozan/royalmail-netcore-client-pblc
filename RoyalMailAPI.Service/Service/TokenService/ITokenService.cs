using RoyalMailAPI.Service.Models;
using System.Threading.Tasks;

namespace RoyalMailAPI.Service.Service.TokenService
{
    public interface ITokenService
    {
        Task<TokenModel> GetToken();
    }
}
