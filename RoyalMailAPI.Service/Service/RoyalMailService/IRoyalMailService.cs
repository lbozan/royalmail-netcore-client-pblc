using RoyalMailAPI.Service.Models;
using System.Threading.Tasks;

namespace RoyalMailAPI.Service.Service.RoyalMailService
{
    public interface IRoyalMailService
    {
        Task<CreatedShipmentResponseModel> Domestic(ShipmentModel model);
        Task<CreatedShipmentResponseModel> DomesticT(ShipmentModel model);
    }
}
