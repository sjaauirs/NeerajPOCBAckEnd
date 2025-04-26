using Backend.Models;
using GenericServices;

namespace Backend.Dtos
{
    public class ChallanTagDto  : ILinkToEntity<ChallanTag>
    {
        public int ChallanTagId { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; } = false;  
        public int DeleteNbr { get; set; } = 0;
        public List<ChallanDto> Challans { get; set; }
    }
}
