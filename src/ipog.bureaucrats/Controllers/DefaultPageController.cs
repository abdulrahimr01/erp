using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefaultPageController : ControllerBase
    {
        private readonly IDefaultPageService _iDefaultPageService;

        public DefaultPageController(IDefaultPageService iDefaultPageService)
        {
            _iDefaultPageService = iDefaultPageService;
        }

        // GET: Get DefaultPage
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetDefaultPageModel> response = await _iDefaultPageService.GetById(id);
            return Ok(response);
        }

        // GET: Get All DefaultPage
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<DefaultPageModelCollection> collection = await _iDefaultPageService.GetAll();
            return Ok(collection);
        }

        // POST: Filter DefaultPage
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            DefaultPageModelCollection collection = await _iDefaultPageService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DefaultPageModel defaultPageModel)
        {
            Response response = await _iDefaultPageService.Insert(defaultPageModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DefaultPageModel defaultPageModel)
        {
            Response response = await _iDefaultPageService.Update(defaultPageModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iDefaultPageService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iDefaultPageService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iDefaultPageService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
