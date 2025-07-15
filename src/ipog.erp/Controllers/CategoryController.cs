using ipog.erp.Models;
using ipog.erp.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _iCategoryService;

        public CategoryController(ICategoryService iCategoryService)
        {
            _iCategoryService = iCategoryService;
        }

        // GET: Get Category
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetCategoryModel> response = await _iCategoryService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Category
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<CategoryModelCollection> collection =
                await _iCategoryService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Category
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            CategoryModelCollection collection = await _iCategoryService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CategoryModel categoryModel)
        {
            Response response = await _iCategoryService.Insert(categoryModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryModel categoryModel)
        {
            string message = await _iCategoryService.Update(categoryModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iCategoryService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iCategoryService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iCategoryService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
