using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace ipog.erp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly string _connString;
        private readonly ILogger<UserController> _logger;

        public UserController(IConfiguration config, ILogger<UserController> logger)
        {
            _connString = config.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        // GET: Get user
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            User user = new();
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT * FROM fn_usersget(@p_action, @p_id)", conn);
            cmd.Parameters.AddWithValue("p_action", "GETBYID");
            cmd.Parameters.AddWithValue("p_id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                user = new User
                {
                    Name = reader["name"]?.ToString(),
                    Email = reader["email"]?.ToString(),
                    Mobile = reader["mobile"]?.ToString(),
                };
            }
            else
            {
                return NotFound($"No user found with id {id}");
            }
            return Ok(user);
        }

        // GET: Get All user
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<User> users = new();
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand("SELECT * FROM fn_usersget(@p_action)", conn);
            cmd.Parameters.AddWithValue("p_action", "GETALL");
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                users.Add(
                    new User
                    {
                        Name = reader["name"]?.ToString(),
                        Email = reader["email"]?.ToString(),
                        Mobile = reader["mobile"]?.ToString(),
                    }
                );
            }
            else
            {
                return NotFound($"No user found");
            }
            return Ok(users);
        }

        // POST: Filter user
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] Pagination pagination)
        {
            List<User> users = new();
            using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM fn_usersget(@p_action, @p_id, @p_ordercol, @p_orderdir, @p_take, @p_skip)",
                conn
            );
            cmd.Parameters.AddWithValue("p_action", "FILTER");
            cmd.Parameters.AddWithValue("p_skip", pagination.Skip);
            cmd.Parameters.AddWithValue("p_take", pagination.Take);
            cmd.Parameters.AddWithValue("p_ordercol", pagination.OrderCol);
            cmd.Parameters.AddWithValue("p_orderdir", pagination.OrderDir);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                users.Add(
                    new User
                    {
                        Name = reader["name"]?.ToString(),
                        Email = reader["email"]?.ToString(),
                        Mobile = reader["mobile"]?.ToString(),
                    }
                );
            }
            else
            {
                return NotFound($"No user found");
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] User user)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();

                using var cmd = new NpgsqlCommand(
                    "CALL sp_users(@p_name, @p_email, @p_mobile, @p_password, @p_address, @p_roleid, @p_actionby, @p_actiondate, @p_isactive, @p_islogin)",
                    conn
                );

                cmd.Parameters.AddWithValue("p_name", user.Name);
                cmd.Parameters.AddWithValue("p_email", user.Email);
                cmd.Parameters.AddWithValue("p_mobile", user.Mobile);
                cmd.Parameters.AddWithValue("p_password", user.Password);
                cmd.Parameters.AddWithValue("p_address", user.Address);
                cmd.Parameters.AddWithValue("p_roleid", user.RoleId);
                cmd.Parameters.AddWithValue("p_actionby", user.ActionBy);
                cmd.Parameters.Add(
                    new NpgsqlParameter("p_actiondate", NpgsqlTypes.NpgsqlDbType.Timestamp)
                    {
                        Value = DateTime.SpecifyKind(user.ActionDate, DateTimeKind.Unspecified),
                    }
                );
                cmd.Parameters.AddWithValue("p_isactive", user.IsActive);
                cmd.Parameters.AddWithValue("p_islogin", user.IsLogin);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return Ok("User insert failed.");
            }
            return Ok("User inserted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();

                using var cmd = new NpgsqlCommand(
                    "CALL sp_users(@p_name, @p_email, @p_mobile, @p_password, @p_address, @p_roleid, @p_actionby, @p_actiondate, @p_isactive, @p_islogin, @p_id)",
                    conn
                );

                cmd.Parameters.AddWithValue("p_name", user.Name);
                cmd.Parameters.AddWithValue("p_email", user.Email);
                cmd.Parameters.AddWithValue("p_mobile", user.Mobile);
                cmd.Parameters.AddWithValue("p_password", user.Password);
                cmd.Parameters.AddWithValue("p_address", user.Address);
                cmd.Parameters.AddWithValue("p_roleid", user.RoleId);
                cmd.Parameters.AddWithValue("p_actionby", user.ActionBy);
                cmd.Parameters.Add(
                    new NpgsqlParameter("p_actiondate", NpgsqlTypes.NpgsqlDbType.Timestamp)
                    {
                        Value = DateTime.SpecifyKind(user.ActionDate, DateTimeKind.Unspecified),
                    }
                );
                cmd.Parameters.AddWithValue("p_isactive", user.IsActive);
                cmd.Parameters.AddWithValue("p_islogin", user.IsLogin);
                cmd.Parameters.AddWithValue("p_id", user.Id);

                await cmd.ExecuteNonQueryAsync();

                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return Ok("User update failed.");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();

                await using var cmd = new NpgsqlCommand(
                    "SELECT fn_usersbyid(@p_action, @p_id)",
                    conn
                );
                cmd.Parameters.AddWithValue("p_action", "Delete");
                cmd.Parameters.AddWithValue("p_id", id);

                var result = await cmd.ExecuteScalarAsync();
                bool success = result is bool b && b;

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

        [HttpPost("user/status")]
        public async Task<IActionResult> SetUserActiveStatus(string action, long id)
        {
            var validActions = new[] { "active", "inactive" };
            if (!validActions.Contains(action.ToLower()))
            {
                return BadRequest("Invalid action. Allowed: active, inactive.");
            }

            try
            {
                await using var conn = new NpgsqlConnection(_connString);
                await conn.OpenAsync();

                await using var cmd = new NpgsqlCommand(
                    "SELECT fn_usersbyid(@p_action, @p_id)",
                    conn
                );
                cmd.Parameters.AddWithValue("p_action", action);
                cmd.Parameters.AddWithValue("p_id", id);

                var result = await cmd.ExecuteScalarAsync();
                bool success = result is bool b && b;

                if (success)
                    return Ok($"User status updated to {action}.");
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
