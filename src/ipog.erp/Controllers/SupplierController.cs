using ipog.erp.Models;
using ipog.erp.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _iSupplierService;

        public SupplierController(ISupplierService iSupplierService)
        {
            _iSupplierService = iSupplierService;
        }

        // GET: Get Supplier
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetSupplierModel> response = await _iSupplierService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Supplier
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<SupplierModelCollection> collection =
                await _iSupplierService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Supplier
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            SupplierModelCollection collection = await _iSupplierService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] SupplierModel supplierModel)
        {
            Response response = await _iSupplierService.Insert(supplierModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SupplierModel supplierModel)
        {
            string message = await _iSupplierService.Update(supplierModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iSupplierService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iSupplierService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iSupplierService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
