using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursevideosController : ControllerBase
    {
        private readonly ICoursevideosService _iCoursevideosService;

        public CoursevideosController(ICoursevideosService iCoursevideosService)
        {
            _iCoursevideosService = iCoursevideosService;
        }

        // GET: Get Coursevideos
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetCoursevideosModel> response = await _iCoursevideosService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Coursevideos
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<CoursevideosModelCollection> collection =
                await _iCoursevideosService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Coursevideos
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            CoursevideosModelCollection collection = await _iCoursevideosService.GetFilter(
                paginationModel
            );
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CoursevideosModel coursevideosModel)
        {
            Response response = await _iCoursevideosService.Insert(coursevideosModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CoursevideosModel coursevideosModel)
        {
            string message = await _iCoursevideosService.Update(coursevideosModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iCoursevideosService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iCoursevideosService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iCoursevideosService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
