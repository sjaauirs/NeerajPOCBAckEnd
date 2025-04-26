using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    [Table("challan_item")]
    public class ChallanItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChallanItemId { get; set; }

        [ForeignKey("Challan")]
        public int ChallanId { get; set; }

        [Required]
        [StringLength(100)]
        public string StyleNumber { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        [Column(TypeName = "numeric(10,2)")]
        public decimal Price { get; set; }
    }
}
