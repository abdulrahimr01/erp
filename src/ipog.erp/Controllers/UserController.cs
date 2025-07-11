using ipog.erp.DataSource;
using ipog.erp.Extension;
using Microsoft.AspNetCore.Mvc;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public UserController(ILogger<UserController> logger, INpgsqlQuery inpgsqlQuery)
        {
            _logger = logger;
            _inpgsqlQuery = inpgsqlQuery;
        }

        // GET: Get user
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            Dictionary<string, object> parameters = new()
            {
                { "p_action", "GETBYID" },
                { "p_id", id },
            };
            List<Dictionary<string, object>> result = await _inpgsqlQuery.ExecuteReaderAsync(
                "SELECT * FROM fn_usersget(@p_action, @p_id)",
                parameters
            );
            User user = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .FirstOrDefault();
            return Ok(user);
        }

        // GET: Get All user
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Dictionary<string, object> parameters = new() { { "p_action", "GETALL" } };
            List<Dictionary<string, object>> result = await _inpgsqlQuery.ExecuteReaderAsync(
                "SELECT * FROM fn_usersget(@p_action)",
                parameters
            );
            List<User> users = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .ToList();
            return Ok(users);
        }

        // POST: Filter user
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] Pagination pagination)
        {
            Dictionary<string, object> parameters = new()
            {
                { "p_action", "GETALL" },
                { "p_id", 0 },
                { "p_skip", pagination.Skip },
                { "p_take", pagination.Take },
                { "p_ordercol", pagination.OrderCol ?? "id" },
                { "p_orderdir", pagination.OrderDir ?? "ASC" },
            };
            List<Dictionary<string, object>> result = await _inpgsqlQuery.ExecuteReaderAsync(
                "SELECT * FROM fn_usersget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            List<User> users = result
                .Select(static row => DataMapperExtensions.MapRowToModel<User>(row))
                .ToList();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] User user)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_name", user.Name },
                    { "p_email", user.Email },
                    { "p_mobile", user.Mobile },
                    { "p_password", user.Password },
                    { "p_address", user.Address },
                    { "p_roleid", user.RoleId },
                    { "p_actionby", user.ActionBy },
                    { "p_actiondate", user.ActionDate },
                    { "p_isactive", user.IsActive },
                    { "p_islogin", user.IsLogin },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_users(@p_name, @p_email, @p_mobile, @p_password, @p_address, @p_roleid, @p_actionby, @p_actiondate, @p_isactive, @p_islogin)",
                    parameters
                );
                return Ok("User inserted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return Ok("User insert failed.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_name", user.Name },
                    { "p_email", user.Email },
                    { "p_mobile", user.Mobile },
                    { "p_password", user.Password },
                    { "p_address", user.Address },
                    { "p_roleid", user.RoleId },
                    { "p_actionby", user.ActionBy },
                    { "p_actiondate", user.ActionDate },
                    { "p_isactive", user.IsActive },
                    { "p_islogin", user.IsLogin },
                    { "p_id", user.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_users(@p_name, @p_email, @p_mobile, @p_password, @p_address, @p_roleid, @p_actionby, @p_actiondate, @p_isactive, @p_islogin, @p_id)",
                    parameters
                );
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return Ok("User update failed.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_action", "Delete" },
                    { "p_id", id },
                };
                bool success = await _inpgsqlQuery.ExecuteScalarAsync(
                    "SELECT fn_usersbyid(@p_action, @p_id)",
                    parameters
                );
                if (success)
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
        public async Task<IActionResult> SetUserActiveStatus(long id)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_action", "active" },
                    { "p_id", id },
                };
                bool success = await _inpgsqlQuery.ExecuteScalarAsync(
                    "SELECT fn_usersbyid(@p_action, @p_id)",
                    parameters
                );
                if (success)
                    return Ok($"User status updated to active.");
                else
                    return NotFound($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetUserinActiveStatus(long id)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_action", "inactive" },
                    { "p_id", id },
                };
                bool success = await _inpgsqlQuery.ExecuteScalarAsync(
                    "SELECT fn_usersbyid(@p_action, @p_id)",
                    parameters
                );
                if (success)
                    return Ok($"User status updated to inactive.");
                else
                    return NotFound($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
