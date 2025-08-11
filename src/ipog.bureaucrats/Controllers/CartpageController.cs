using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartpageController : ControllerBase
    {
        private readonly ICartpageService _iCartpageService;

        public CartpageController(ICartpageService iCartpageService)
        {
            _iCartpageService = iCartpageService;
        }

        // GET: Get Cartpage
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetCartpageModel> response = await _iCartpageService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Cartpage
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<CartpageModelCollection> collection =
                await _iCartpageService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Cartpage
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            CartpageModelCollection collection = await _iCartpageService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CartpageModel cartpageModel)
        {
            Response response = await _iCartpageService.Insert(cartpageModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CartpageModel cartpageModel)
        {
            Response response = await _iCartpageService.Update(cartpageModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iCartpageService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iCartpageService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iCartpageService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
