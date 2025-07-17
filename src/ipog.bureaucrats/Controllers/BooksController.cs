using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _iBooksService;

        public BooksController(IBooksService iBooksService)
        {
            _iBooksService = iBooksService;
        }

        // GET: Get Books
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetBooksModel> response = await _iBooksService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Books
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<BooksModelCollection> collection = await _iBooksService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Books
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            BooksModelCollection collection = await _iBooksService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BooksModel booksModel)
        {
            Response response = await _iBooksService.Insert(booksModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BooksModel booksModel)
        {
            string message = await _iBooksService.Update(booksModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iBooksService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iBooksService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iBooksService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
