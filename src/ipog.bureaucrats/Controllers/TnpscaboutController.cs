using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TnpscaboutController : ControllerBase
    {
        private readonly ITnpscaboutService _iTnpscaboutService;

        public TnpscaboutController(ITnpscaboutService iTnpscaboutService)
        {
            _iTnpscaboutService = iTnpscaboutService;
        }

        // GET: Get Tnpscabout
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetTnpscaboutModel> response = await _iTnpscaboutService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Tnpscabout
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<TnpscaboutModelCollection> collection =
                await _iTnpscaboutService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Tnpscabout
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            TnpscaboutModelCollection collection = await _iTnpscaboutService.GetFilter(
                paginationModel
            );
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] TnpscaboutModel tnpscaboutModel)
        {
            Response response = await _iTnpscaboutService.Insert(tnpscaboutModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TnpscaboutModel tnpscaboutModel)
        {
            string message = await _iTnpscaboutService.Update(tnpscaboutModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iTnpscaboutService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iTnpscaboutService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iTnpscaboutService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
