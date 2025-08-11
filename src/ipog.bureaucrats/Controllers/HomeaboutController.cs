using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeaboutController : ControllerBase
    {
        private readonly IHomeaboutService _iHomeaboutService;

        public HomeaboutController(IHomeaboutService iHomeaboutService)
        {
            _iHomeaboutService = iHomeaboutService;
        }

        // GET: Get Homeabout
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetHomeaboutModel> response = await _iHomeaboutService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Homeabout
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<HomeaboutModelCollection> collection =
                await _iHomeaboutService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Homeabout
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            HomeaboutModelCollection collection = await _iHomeaboutService.GetFilter(
                paginationModel
            );
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] HomeaboutModel homeaboutModel)
        {
            Response response = await _iHomeaboutService.Insert(homeaboutModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HomeaboutModel homeaboutModel)
        {
            Response response = await _iHomeaboutService.Update(homeaboutModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iHomeaboutService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iHomeaboutService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iHomeaboutService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
