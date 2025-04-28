using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Backend.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }  // employee_id

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }  // name

        [MaxLength(500)]
        public string Address { get; set; }  // address

        [Required]
        public DateTime JoiningDate { get; set; }  // joining_date

        [MaxLength(20)]
        public string Pan { get; set; }  // pan

        [MaxLength(20)]
        public string Aadhar { get; set; }  // aadhar

        [MaxLength(50)]
        public string AccountNo { get; set; }  // account_no

        [MaxLength(20)]
        public string IfscCode { get; set; }  // ifsc_code

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;  // created_on (default: CURRENT_TIMESTAMP)

        public DateTime? UpdatedOn { get; set; }  // updated_on

        public int DeleteNbr { get; set; } = 0;  // delete_nbr (default: 0)

        [MaxLength(255)]
        public string ImageUrl { get; set; }  // image_url

        public JsonDocument? EmployeeConfig { get; set; }  // employee_config (jsonb)

        public decimal DefaultRate { get; set; } = 0.00M;
    }
}
