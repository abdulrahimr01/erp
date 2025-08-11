using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpscaboutController : ControllerBase
    {
        private readonly IUpscaboutService _iUpscaboutService;

        public UpscaboutController(IUpscaboutService iUpscaboutService)
        {
            _iUpscaboutService = iUpscaboutService;
        }

        // GET: Get Upscabout
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetUpscaboutModel> response = await _iUpscaboutService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Upscabout
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<UpscaboutModelCollection> collection =
                await _iUpscaboutService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Upscabout
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            UpscaboutModelCollection collection = await _iUpscaboutService.GetFilter(
                paginationModel
            );
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UpscaboutModel upscaboutModel)
        {
            Response response = await _iUpscaboutService.Insert(upscaboutModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpscaboutModel upscaboutModel)
        {
            Response response = await _iUpscaboutService.Update(upscaboutModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iUpscaboutService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iUpscaboutService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iUpscaboutService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
