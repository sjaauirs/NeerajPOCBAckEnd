using Backend.Models;
using GenericServices;

namespace Backend.Dtos
{
    public class ChallanItemDto : ILinkToEntity<ChallanItem>
    {
        public int ChallanItemId { get; set; }
        public string StyleNumber { get; set; }
        public int ItemCount { get; set; }
        public decimal Price { get; set; }
    }
}
