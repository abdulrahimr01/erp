using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TnpsccoursevideosController : ControllerBase
    {
        private readonly ITnpsccoursevideosService _iTnpsccoursevideosService;

        public TnpsccoursevideosController(ITnpsccoursevideosService iTnpsccoursevideosService)
        {
            _iTnpsccoursevideosService = iTnpsccoursevideosService;
        }

        // GET: Get Tnpsccoursevideos
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetTnpsccoursevideosModel> response =
                await _iTnpsccoursevideosService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Tnpsccoursevideos
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<TnpsccoursevideosModelCollection> collection =
                await _iTnpsccoursevideosService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Tnpsccoursevideos
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            TnpsccoursevideosModelCollection collection =
                await _iTnpsccoursevideosService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(
            [FromBody] TnpsccoursevideosModel tnpsccoursevideosModel
        )
        {
            Response response = await _iTnpsccoursevideosService.Insert(tnpsccoursevideosModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] TnpsccoursevideosModel tnpsccoursevideosModel
        )
        {
            Response response = await _iTnpsccoursevideosService.Update(tnpsccoursevideosModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iTnpsccoursevideosService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iTnpsccoursevideosService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iTnpsccoursevideosService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
