using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    [Table("challan")]
    public class Challan
    {
        [Key]
        [Column("challan_id")]
        public int ChallanId { get; set; }

        [Column("challan_date")]
        public DateTime ChallanDate { get; set; } = DateTime.UtcNow.Date;

        [Column("created_on")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int ChallanTagId { get; set; }
        public ICollection<ChallanItem> ChallanItems { get; set; }
    }

}
