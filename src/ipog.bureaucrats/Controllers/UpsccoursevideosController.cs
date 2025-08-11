using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpsccoursevideosController : ControllerBase
    {
        private readonly IUpsccoursevideosService _iUpsccoursevideosService;

        public UpsccoursevideosController(IUpsccoursevideosService iUpsccoursevideosService)
        {
            _iUpsccoursevideosService = iUpsccoursevideosService;
        }

        // GET: Get Upsccoursevideos
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetUpsccoursevideosModel> response =
                await _iUpsccoursevideosService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Upsccoursevideos
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<UpsccoursevideosModelCollection> collection =
                await _iUpsccoursevideosService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Upsccoursevideos
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            UpsccoursevideosModelCollection collection = await _iUpsccoursevideosService.GetFilter(
                paginationModel
            );
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(
            [FromBody] UpsccoursevideosModel upsccoursevideosModel
        )
        {
            Response response = await _iUpsccoursevideosService.Insert(upsccoursevideosModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpsccoursevideosModel upsccoursevideosModel
        )
        {
            Response response = await _iUpsccoursevideosService.Update(upsccoursevideosModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iUpsccoursevideosService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iUpsccoursevideosService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iUpsccoursevideosService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
