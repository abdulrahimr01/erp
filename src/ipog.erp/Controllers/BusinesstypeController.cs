using ipog.erp.Models;
using ipog.erp.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinesstypeController : ControllerBase
    {
        private readonly IBusinesstypeService _iBusinesstypeService;

        public BusinesstypeController(IBusinesstypeService iBusinesstypeService)
        {
            _iBusinesstypeService = iBusinesstypeService;
        }

        // GET: Get Businesstype
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetBusinesstypeModel> response = await _iBusinesstypeService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Businesstype
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<BusinesstypeModelCollection> collection =
                await _iBusinesstypeService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Businesstype
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            BusinesstypeModelCollection collection = await _iBusinesstypeService.GetFilter(
                paginationModel
            );
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BusinesstypeModel businesstypeModel)
        {
            Response response = await _iBusinesstypeService.Insert(businesstypeModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BusinesstypeModel businesstypeModel)
        {
            string message = await _iBusinesstypeService.Update(businesstypeModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iBusinesstypeService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iBusinesstypeService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iBusinesstypeService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
