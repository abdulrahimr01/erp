using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditorialsController : ControllerBase
    {
        private readonly IEditorialsService _iEditorialsService;

        public EditorialsController(IEditorialsService iEditorialsService)
        {
            _iEditorialsService = iEditorialsService;
        }

        // GET: Get Editorials
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetEditorialsModel> response = await _iEditorialsService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Editorials
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<EditorialsModelCollection> collection = await _iEditorialsService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Editorials
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            EditorialsModelCollection collection = await _iEditorialsService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] EditorialsModel editorialsModel)
        {
            Response response = await _iEditorialsService.Insert(editorialsModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditorialsModel editorialsModel)
        {
            Response response = await _iEditorialsService.Update(editorialsModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iEditorialsService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iEditorialsService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iEditorialsService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
