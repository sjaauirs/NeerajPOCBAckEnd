namespace Backend.Models
{
    public class ClientCompany
    {
        public int ClientCompanyId { get; set; }

        public string CompanyName { get; set; }

        public string? AddressLine1 { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }

        public string? AccountNumber { get; set; }

        public string? GstNumber { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? DeleteNbr { get; set; }

        public List<ChallanTag> ChallanTags { get; set; }
    }

}
