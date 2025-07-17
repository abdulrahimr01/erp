using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class UpscaboutRepository : IUpscaboutRepository
    {
        private readonly ILogger<IUpscaboutRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public UpscaboutRepository(ILogger<IUpscaboutRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_upscaboutget(@p_action, @p_id)",
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
                "SELECT * FROM fn_upscaboutget(@p_action)",
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
                "SELECT * FROM fn_upscaboutget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Upscabout upscabout)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_text", upscabout.Text },
                    { "p_actionby", upscabout.Actionby },
                    { "p_actiondate", upscabout.Actiondate },
                    { "p_isactive", upscabout.IsActive },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_upscabout(@p_text, @p_actionby, @p_actiondate, @p_isactive)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "upscabout insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Upscabout upscabout)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_text", upscabout.Text },
                    { "p_actionby", upscabout.Actionby },
                    { "p_actiondate", upscabout.Actiondate },
                    { "p_isactive", upscabout.IsActive },
                    { "p_id", upscabout.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_upscabout(@p_text, @p_actionby, @p_actiondate, @p_isactive, @p_id)",
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
                    "SELECT fn_upscaboutbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting upscabout");
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
                    "SELECT fn_upscaboutbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "upscabout not found");
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
                    "SELECT fn_upscaboutbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "upscabout not found");
                throw;
            }
        }
    }
}
