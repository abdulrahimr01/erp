using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;

        public UserController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        // GET: Get user
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetUserModel> response = await _iUserService.GetById(id);
            return Ok(response);
        }

        // GET: Get All user
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<UserModelCollection> collection = await _iUserService.GetAll();
            return Ok(collection);
        }

        // POST: Filter user
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            UserModelCollection collection = await _iUserService.GetFilter(paginationModel);
            return Ok(collection);
        }

        // GET: Login user
        [HttpPost("LoginUser")]
        public async Task<IActionResult> GetById(UserLoginModel requestModel)
        {
            GetResponse<GetUserModel> response = await _iUserService.UserLogin(requestModel);
            return Ok(response);
        }

        // GET: Update Password
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> GetById(UpdatePasswordModel requestModel)
        {
            GetResponse<GetUserModel> response = await _iUserService.UpdatePassword(requestModel);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserModel userModel)
        {
            Response response = await _iUserService.Insert(userModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel userModel)
        {
            string message = await _iUserService.Update(userModel);
            return Ok(message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            string message = await _iUserService.Delete(id);
            return Ok(message);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            string message = await _iUserService.SetActiveStatus(id);
            return Ok(message);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            string message = await _iUserService.SetInActiveStatus(id);
            return Ok(message);
        }
    }
}
