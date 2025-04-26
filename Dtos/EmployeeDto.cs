using Backend.Models;
using GenericServices;
using System.Text.Json;

namespace Backend.Dtos
{
    public class EmployeeDto :ILinkToEntity<Employee>
    {
        public int EmployeeId { get; set; }  // employee_id

        public string Name { get; set; }  // name

        public string Address { get; set; }  // address

        public DateTime JoiningDate { get; set; }  // joining_date

        public string Pan { get; set; }  // pan

        public string Aadhar { get; set; }  // aadhar

        public string AccountNo { get; set; }  // account_no

        public string IfscCode { get; set; }  // ifsc_code

        public DateTime CreatedOn { get; set; }  // created_on

        public DateTime? UpdatedOn { get; set; }  // updated_on

        public int DeleteNbr { get; set; }  // delete_nbr

        public string ImageUrl { get; set; }  // image_url

        public JsonDocument EmployeeConfig { get; set; }  // employee_config

        public decimal DefaultRate { get; set; } = 0.00M;
    }

   
}
