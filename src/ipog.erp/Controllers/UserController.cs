using ipog.erp.DataSource.IRepository;
using ipog.erp.Entity;
using ipog.erp.Extension;
using Microsoft.AspNetCore.Mvc;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _iUserRepository;

        public UserController(ILogger<UserController> logger, IUserRepository iUserRepository)
        {
            _logger = logger;
            _iUserRepository = iUserRepository;
        }

        // GET: Get user
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iUserRepository.GetById(id);
            User? user = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .FirstOrDefault();
            return Ok(user);
        }

        // GET: Get All user
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Dictionary<string, object>> result = await _iUserRepository.GetAll();
            List<User> users = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .ToList();
            return Ok(users);
        }

        // POST: Filter user
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] Pagination pagination)
        {
            List<Dictionary<string, object>> result = await _iUserRepository.GetFilter(pagination);
            List<User> users = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .ToList();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] User user)
        {
            bool success = await _iUserRepository.Insert(user);
            if (success)
                return Ok("User inserted successfully.");
            else
                return StatusCode(500, "User insert failed.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            bool success = await _iUserRepository.Update(user);
            if (success)
                return Ok("User updated successfully.");
            else
                return StatusCode(500, "User update failed.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                bool deleted = await _iUserRepository.Delete(id);

                if (deleted)
                    return Ok("User deleted successfully.");
                else
                    return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            try
            {
                bool success = await _iUserRepository.SetActiveStatus(id);
                if (success)
                    return Ok("User status updated to active.");
                else
                    return NotFound($"User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            try
            {
                bool success = await _iUserRepository.SetInActiveStatus(id);
                if (success)
                    return Ok("User status updated to inactive.");
                else
                    return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
