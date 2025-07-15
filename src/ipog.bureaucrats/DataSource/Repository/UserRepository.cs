using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public UserRepository(ILogger<UserRepository> logger, INpgsqlQuery inpgsqlQuery)
        {
            _logger = logger;
            _inpgsqlQuery = inpgsqlQuery;
        }

        public async Task<List<Dictionary<string, object>>> GetById(long id)
        {
            try
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
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Dictionary<string, object>>> GetAll()
        {
            Dictionary<string, object> parameters = new() { { "p_action", "GETALL" } };
            List<Dictionary<string, object>> result = await _inpgsqlQuery.ExecuteReaderAsync(
                "SELECT * FROM fn_usersget(@p_action)",
                parameters
            );
            return result;
        }

        public async Task<List<Dictionary<string, object>>> GetFilter(Pagination pagination)
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
            return result;
        }

        public async Task<bool> Insert(User user)
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
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(User user)
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
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(long id)
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
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user");
                throw;
            }
        }

        public async Task<bool> SetActiveStatus(long id)
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
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "user not found");
                throw;
            }
        }

        public async Task<bool> SetInActiveStatus(long id)
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
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "user not found");
                throw;
            }
        }
    }
}
