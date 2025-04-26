using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    [Table("challan_tag")]
    public class ChallanTag
    {
        [Key]
        public int ChallanTagId { get; set; }

        [Required]
        [StringLength(255)]
        public string TagName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = false;  // Default to false (0 in DB)
        public int DeleteNbr { get; set; } = 0;      // Default to 0 in DB

        public int ClientCompanyId { get; set; }

        public List<Challan> Challans { get; set; }

    }

}
