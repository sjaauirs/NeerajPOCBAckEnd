using Backend.Models;
using GenericServices;

namespace Backend.Dtos
{
    public class ChallanDto : ILinkToEntity<Challan>
    {
        public int ChallanId { get; set; }

        public DateTime ChallanDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<ChallanItemDto> ChallanItems { get; set; }
    }
}
