using ipog.erp.Models;
using ipog.erp.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HsnController : ControllerBase
    {
        private readonly IHsnService _iHsnService;

        public HsnController(IHsnService iHsnService)
        {
            _iHsnService = iHsnService;
        }

        // GET: Get Hsn
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetHsnModel> response = await _iHsnService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Hsn
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<HsnModelCollection> collection = await _iHsnService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Hsn
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            HsnModelCollection collection = await _iHsnService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] HsnModel hsnModel)
        {
            Response response = await _iHsnService.Insert(hsnModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HsnModel hsnModel)
        {
            string message = await _iHsnService.Update(hsnModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iHsnService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iHsnService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iHsnService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
