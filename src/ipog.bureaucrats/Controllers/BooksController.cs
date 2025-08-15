using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        // GET by ID
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var response = await _iBooksService.GetById(id);
            return Ok(response);
        }

        // GET all
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var collection = await _iBooksService.GetAll();
            return Ok(collection);
        }

        // POST filter
        [HttpPost("filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            var collection = await _iBooksService.GetFilter(paginationModel);
            return Ok(collection);
        }

        // POST insert
        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] BooksFormDto dto)
        {
            var model = MapDtoToModel(dto);
            var response = await _iBooksService.Insert(model);
            return Ok(response);
        }

        // PUT update
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] BooksFormDto dto)
        {
            var model = MapDtoToModel(dto);
            var response = await _iBooksService.Update(model);
            return Ok(response);
        }

        // DELETE by ID
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _iBooksService.Delete(id);
            return Ok(response);
        }

        // PATCH set active
        [HttpPatch("{id:long}/active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            var response = await _iBooksService.SetActiveStatus(id);
            return Ok(response);
        }

        // PATCH set inactive
        [HttpPatch("{id:long}/inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            var response = await _iBooksService.SetInActiveStatus(id);
            return Ok(response);
        }

        // Helper: Map DTO to Model
        private BooksModel MapDtoToModel(BooksFormDto dto)
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
                dto.FrontImage.CopyTo(ms);
                model.FrontImage = ms.ToArray();
            }

            if (dto.BackImage != null)
            {
                using var ms = new MemoryStream();
                dto.BackImage.CopyTo(ms);
                model.BackImage = ms.ToArray();
            }

            return model;
        }
    }
}
