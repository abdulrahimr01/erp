using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PapersController : ControllerBase
    {
        private readonly IPapersService _iPapersService;

        public PapersController(IPapersService iPapersService)
        {
            _iPapersService = iPapersService;
        }

        // GET: Get Papers
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetPapersModel> response = await _iPapersService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Papers
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<PapersModelCollection> collection = await _iPapersService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Papers
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            PapersModelCollection collection = await _iPapersService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PapersModel papersModel)
        {
            Response response = await _iPapersService.Insert(papersModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PapersModel papersModel)
        {
            Response response = await _iPapersService.Update(papersModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iPapersService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iPapersService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iPapersService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
