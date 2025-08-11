using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly IExamsService _iExamsService;

        public ExamsController(IExamsService iExamsService)
        {
            _iExamsService = iExamsService;
        }

        // GET: Get Exams
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetExamsModel> response = await _iExamsService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Exams
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<ExamsModelCollection> collection = await _iExamsService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Exams
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            ExamsModelCollection collection = await _iExamsService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ExamsModel examsModel)
        {
            Response response = await _iExamsService.Insert(examsModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExamsModel examsModel)
        {
            Response response = await _iExamsService.Update(examsModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iExamsService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iExamsService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iExamsService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
