using RoyalMailAPI.Service.Enums;
using System.ComponentModel.DataAnnotations;

namespace RoyalMailAPI.Service.Models
{
    public class DocumentsRequestModel : ErrorResponseModel
    {
        [Required]
        public EDocumentName DocumentName { get; set; }
        public EDocumentCopies DocumentCopies { get; set; }
    }
}
