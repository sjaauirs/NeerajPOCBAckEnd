using Backend.Dtos;
using GenericServices;
using GenericServices.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ICrudServicesAsync _crud;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, ICrudServicesAsync crud)
        {
            _logger = logger;
            _crud = crud;
        }

        private async Task<EmployeeDto> EmployeeById(int id)
        {
           return await _crud.ReadSingleAsync<EmployeeDto>(id);
        }

        // Get an employee by ID
        [HttpGet("{id}" , Name = "GetEmployeeById")]
        public async  Task<ActionResult<WebApiMessageAndResult<EmployeeDto>>> Get(int id)
        {
            var result =await EmployeeById(id);
            if (!_crud.IsValid)
                return BadRequest(_crud.GetAllErrors());

            return _crud.Response(result);
        }

        // Get an employee by ID
        [HttpGet("All")]
        public async Task<ActionResult<WebApiMessageAndResult<List<EmployeeDto>>>> Get()
        {
            var result = await _crud.ReadManyNoTracked<EmployeeDto>().ToListAsync();
            if (!_crud.IsValid)
                return BadRequest(_crud.GetAllErrors());

            return _crud.Response(result);
        }

        // Create a new employee
        [ProducesResponseType(typeof(EmployeeDto), 201)]
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Post([FromBody] EmployeeDto dto)
        {
            EmployeeDto? result = null;
            if (dto.EmployeeId > 0)
            {
                await _crud.UpdateAndSaveAsync(dto);
                result = await EmployeeById(dto.EmployeeId);
            }
            else
            {
                result = await _crud.CreateAndSaveAsync(dto);
            }
            if (!_crud.IsValid)
                return BadRequest(_crud.GetAllErrors());

            return _crud.Response(this, "GetEmployeeById", new { id = result.EmployeeId }, result);

        }

        // Update an existing employee
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiMessageAndResult<EmployeeDto>>> Put(int id, [FromBody] EmployeeDto dto)
        {
            // Set the ID of the DTO before updating
            dto.EmployeeId = id;
           await _crud.UpdateAndSaveAsync<EmployeeDto>(dto);
           
            if (!_crud.IsValid)
                return BadRequest(_crud.GetAllErrors());

            return _crud.Response(await EmployeeById(dto.EmployeeId));
        }

        // Delete an employee
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiMessageOnly>> Delete(int id)
        {
             await _crud.DeleteAndSaveAsync<EmployeeDto>(id);
            if (!_crud.IsValid)
                return BadRequest(_crud.GetAllErrors());

            return _crud.Response();
        }
    }
}
