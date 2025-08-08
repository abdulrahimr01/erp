using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrentAffairsController : ControllerBase
    {
        private readonly ICurrentAffairsService _iCurrentAffairsService;

        public CurrentAffairsController(ICurrentAffairsService iCurrentAffairsService)
        {
            _iCurrentAffairsService = iCurrentAffairsService;
        }

        // GET: Get CurrentAffairs
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetCurrentAffairsModel> response = await _iCurrentAffairsService.GetById(id);
            return Ok(response);
        }

        // GET: Get All CurrentAffairs
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<CurrentAffairsModelCollection> collection = await _iCurrentAffairsService.GetAll();
            return Ok(collection);
        }

        // POST: Filter CurrentAffairs
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            CurrentAffairsModelCollection collection = await _iCurrentAffairsService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CurrentAffairsModel currentaffairsModel)
        {
            Response response = await _iCurrentAffairsService.Insert(currentaffairsModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CurrentAffairsModel currentaffairsModel)
        {
            Response response = await _iCurrentAffairsService.Update(currentaffairsModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iCurrentAffairsService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iCurrentAffairsService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iCurrentAffairsService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
