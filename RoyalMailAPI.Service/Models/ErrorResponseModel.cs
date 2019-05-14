using System.Collections.Generic;

namespace RoyalMailAPI.Service.Models
{
    public class ErrorResponseModel
    {
        public string HttpCode { get; set; }
        public string HttpMessage { get; set; }
        public string MoreInformation { get; set; }
        public List<ErrorModel> Errors { get; set; }

        //public ErrorsModel Errors { get; set; }

    }
}
