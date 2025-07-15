using ipog.erp.Models;
using ipog.erp.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _iCustomerService;

        public CustomerController(ICustomerService iCustomerService)
        {
            _iCustomerService = iCustomerService;
        }

        // GET: Get Customer
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetCustomerModel> response = await _iCustomerService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Customer
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<CustomerModelCollection> collection =
                await _iCustomerService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Customer
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            CustomerModelCollection collection = await _iCustomerService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CustomerModel customerModel)
        {
            Response response = await _iCustomerService.Insert(customerModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerModel customerModel)
        {
            string message = await _iCustomerService.Update(customerModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iCustomerService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iCustomerService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iCustomerService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
