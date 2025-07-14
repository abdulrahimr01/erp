using ipog.erp.Models;
using ipog.erp.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _iRoleService;

        public RoleController(IRoleService iRoleService)
        {
            _iRoleService = iRoleService;
        }

        // GET: Get role
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetRoleModel> response = await _iRoleService.GetById(id);
            return Ok(response);
        }

        // GET: Get All role
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<RoleModelCollection> collection = await _iRoleService.GetAll();
            return Ok(collection);
        }

        // POST: Filter role
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            RoleModelCollection collection = await _iRoleService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] RoleModel roleModel)
        {
            Response response = await _iRoleService.Insert(roleModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleModel roleModel)
        {
            string message = await _iRoleService.Update(roleModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iRoleService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iRoleService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iRoleService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
