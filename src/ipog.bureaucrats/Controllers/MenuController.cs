using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _iMenuService;

        public MenuController(IMenuService iMenuService)
        {
            _iMenuService = iMenuService;
        }

        // GET: Get Menu
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetMenuModel> response = await _iMenuService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Menu
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<MenuModelCollection> collection = await _iMenuService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Menu
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            MenuModelCollection collection = await _iMenuService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] MenuModel menuModel)
        {
            Response response = await _iMenuService.Insert(menuModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MenuModel menuModel)
        {
            Response response = await _iMenuService.Update(menuModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iMenuService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iMenuService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iMenuService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
