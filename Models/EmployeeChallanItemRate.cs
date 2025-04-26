using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    [Table("employee_challan_item_rate")]
    public class EmployeeChallanItemRate
    {
        [Key]
        public int ChallanItemRateId { get; set; }  // New auto-generated primary key

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("ChallanItem")]
        public int ChallanItemId { get; set; }
        public ChallanItem ChallanItem { get; set; }

        [Required]
        [Range(0, 9999999999.99)]  // Limits the range to fit your numeric(10,2) constraint
        public decimal Rate { get; set; }

        [Required]
        public DateTime RateEffectiveDate { get; set; }  // If adding the RateEffectiveDate field
    }
}
