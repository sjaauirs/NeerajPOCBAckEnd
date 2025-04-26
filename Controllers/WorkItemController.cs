//using Backend.Dtos;
//using GenericServices;
//using GenericServices.AspNetCore;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;

//namespace Backend.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WorkItemController : ControllerBase
//    {
//        private readonly ICrudServicesAsync _crud;
//        private readonly ILogger<WorkItemController> _logger;

//        public WorkItemController(ILogger<WorkItemController> logger, ICrudServicesAsync crud)
//        {
//            _logger = logger;
//            _crud = crud;
//        }

//        private async Task<WorkItemDto> WorkItemById(int id)
//        {
//           return await _crud.ReadSingleAsync<WorkItemDto>(id);
//        }

//        // Get an WorkItem by ID
//        [HttpGet("{id}" , Name = "GetWorkItemById")]
//        public async  Task<ActionResult<WebApiMessageAndResult<WorkItemDto>>> Get(int id)
//        {
//            var result =await WorkItemById(id);
//            if (!_crud.IsValid)
//                return BadRequest(_crud.GetAllErrors());

//            return _crud.Response(result);
//        }

//        // Get an WorkItem by ID
//        [HttpGet("All")]
//        public async Task<ActionResult<WebApiMessageAndResult<List<WorkItemDto>>>> Get()
//        {
//            var result = await _crud.ReadManyNoTracked<WorkItemDto>().ToListAsync();
//            if (!_crud.IsValid)
//                return BadRequest(_crud.GetAllErrors());

//            return _crud.Response(result);
//        }

//        // Create a new WorkItem
//        [ProducesResponseType(typeof(WorkItemDto), 201)]
//        [HttpPost]
//        public async Task<ActionResult<WorkItemDto>> Post([FromBody] WorkItemDto dto)
//        {
//            WorkItemDto? result = null;
//            if (dto.WorkItemId > 0)
//            {
//                await _crud.UpdateAndSaveAsync(dto);
//                result = await WorkItemById(dto.WorkItemId);
//            }
//            else
//            {
//                result = await _crud.CreateAndSaveAsync(dto);
//            }
//            if (!_crud.IsValid)
//                return BadRequest(_crud.GetAllErrors());

//            return _crud.Response(this, "GetWorkItemById", new { id = result.WorkItemId }, result);

//        }

//        // Update an existing WorkItem
//        [HttpPut("{id}")]
//        public async Task<ActionResult<WebApiMessageAndResult<WorkItemDto>>> Put(int id, [FromBody] WorkItemDto dto)
//        {
//            // Set the ID of the DTO before updating
//            dto.WorkItemId = id;
//           await _crud.UpdateAndSaveAsync<WorkItemDto>(dto);
           
//            if (!_crud.IsValid)
//                return BadRequest(_crud.GetAllErrors());

//            return _crud.Response(await WorkItemById(dto.WorkItemId));
//        }

//        // Delete an WorkItem
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<WebApiMessageOnly>> Delete(int id)
//        {
//             await _crud.DeleteAndSaveAsync<WorkItemDto>(id);
//            if (!_crud.IsValid)
//                return BadRequest(_crud.GetAllErrors());

//            return _crud.Response();
//        }
//    }
//}
