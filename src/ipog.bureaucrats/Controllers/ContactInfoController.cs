using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _iContactInfoService;

        public ContactInfoController(IContactInfoService iContactInfoService)
        {
            _iContactInfoService = iContactInfoService;
        }

        // GET: Get ContactInfo
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetContactInfoModel> response = await _iContactInfoService.GetById(id);
            return Ok(response);
        }

        // GET: Get All ContactInfo
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<ContactInfoModelCollection> collection = await _iContactInfoService.GetAll();
            return Ok(collection);
        }

        // POST: Filter ContactInfo
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            ContactInfoModelCollection collection = await _iContactInfoService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ContactInfoModel contactinfoModel)
        {
            Response response = await _iContactInfoService.Insert(contactinfoModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContactInfoModel contactinfoModel)
        {
            Response response = await _iContactInfoService.Update(contactinfoModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iContactInfoService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iContactInfoService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iContactInfoService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
