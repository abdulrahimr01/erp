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
public async Task<IActionResult> Insert([FromForm] BooksFormDto dto)
{
    var model = new BooksModel
    {
        Id = dto.Id,
        Title = dto.Title,
        ExamName = dto.ExamName,
        Author = dto.Author,
        Price = dto.Price,
        OriginalPrice = dto.Originalprice,
        Description = dto.Description,
        Details = dto.Details,
        Stocks = dto.Stocks,
        IsActive = dto.IsActive,
        ActionBy = dto.ActionBy,
        ActionDate = dto.ActionDate,
        Course = dto.Course
    };

    if (dto.FrontImage != null)
    {
        using var ms = new MemoryStream();
        await dto.FrontImage.CopyToAsync(ms);
        model.FrontImage = ms.ToArray();
    }

    if (dto.BackImage != null)
    {
        using var ms = new MemoryStream();
        await dto.BackImage.CopyToAsync(ms);
        model.BackImage = ms.ToArray();
    }

    var response = await _iBooksService.Insert(model);
    return Ok(response);
}

[HttpPut]
public async Task<IActionResult> Update([FromForm] BooksFormDto dto)
{
    var model = new BooksModel
    {
        Id = dto.Id,
        Title = dto.Title,
        ExamName = dto.ExamName,
        Author = dto.Author,
        Price = dto.Price,
        OriginalPrice = dto.Originalprice,
        Description = dto.Description,
        Details = dto.Details,
        Stocks = dto.Stocks,
        IsActive = dto.IsActive,
        ActionBy = dto.ActionBy,
        ActionDate = dto.ActionDate,
        Course = dto.Course
    };

    if (dto.FrontImage != null)
    {
        using var ms = new MemoryStream();
        await dto.FrontImage.CopyToAsync(ms);
        model.FrontImage = ms.ToArray();
    }

    if (dto.BackImage != null)
    {
        using var ms = new MemoryStream();
        await dto.BackImage.CopyToAsync(ms);
        model.BackImage = ms.ToArray();
    }

    var response = await _iBooksService.Update(model);
    return Ok(response);
}
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iBooksService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iBooksService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iBooksService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
