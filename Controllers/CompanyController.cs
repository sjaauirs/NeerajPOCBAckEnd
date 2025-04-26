using Backend.Dtos;
using GenericServices;
using GenericServices.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICrudServicesAsync _crud;

        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ILogger<CompanyController> logger , ICrudServicesAsync crud)
        {
            _logger = logger;
            _crud = crud;
        }

        [HttpGet("{companyname}" , Name = "GetCompanyByName")]
        public async Task<ActionResult<WebApiMessageAndResult<ClientCompanyDto>>> Get(string companyname)
        {
            var result = await _crud.ReadSingleAsync<ClientCompanyDto>(
        x => x.CompanyName.ToLower() == companyname.ToLower()        // Include ChallanItems within Challans
             );
            if (!_crud.IsValid)
                return BadRequest(_crud.GetAllErrors());

            return Ok(result);

        }

        [ProducesResponseType(typeof(ClientCompanyDto), 201)]
        [HttpPost]
        public async Task<ActionResult<ClientCompanyDto>> Post([FromBody] ClientCompanyDto dto)
        {
            ClientCompanyDto? result = null;
            if (dto.ClientCompanyId > 0)
            {
                await _crud.UpdateAndSaveAsync(dto);
                result = await _crud.ReadSingleAsync<ClientCompanyDto>(dto.ClientCompanyId);
            }
            else
            {
                result = await _crud.CreateAndSaveAsync(dto);
            }
            if (!_crud.IsValid)
                return BadRequest(_crud.GetAllErrors());

            return _crud.Response(this, "GetCompanyByName", new { companyname = result.CompanyName }, result);
        }
    }
}
