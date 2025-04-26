using Backend.Models;
using GenericServices;

namespace Backend.Dtos
{
    [IncludeThen( (nameof(ClientCompanyDto.ChallanTags)) , (nameof(ChallanTagDto.Challans)) , (nameof(ChallanDto.ChallanItems)))]
    public class ClientCompanyDto : ILinkToEntity<ClientCompany>
    {
        public int ClientCompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        public string? AddressLine1 { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }

        public string? AccountNumber { get; set; }

        public string? GstNumber { get; set; }
        public List<ChallanTagDto> ChallanTags { get; set; }
    }
}
