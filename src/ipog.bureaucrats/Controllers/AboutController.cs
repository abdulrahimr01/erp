using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _iAboutService;

        public AboutController(IAboutService iAboutService)
        {
            _iAboutService = iAboutService;
        }

        // GET: Get About
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetAboutModel> response = await _iAboutService.GetById(id);
            return Ok(response);
        }

        // GET: Get All About
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<AboutModelCollection> collection = await _iAboutService.GetAll();
            return Ok(collection);
        }

        // POST: Filter About
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            AboutModelCollection collection = await _iAboutService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] AboutModel aboutModel)
        {
            Response response = await _iAboutService.Insert(aboutModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AboutModel aboutModel)
        {
            Response response = await _iAboutService.Update(aboutModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iAboutService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iAboutService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iAboutService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
