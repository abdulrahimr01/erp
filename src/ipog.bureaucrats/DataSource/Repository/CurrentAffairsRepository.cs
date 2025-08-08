using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class CurrentAffairsRepository : ICurrentAffairsRepository
    {
        private readonly ILogger<ICurrentAffairsRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public CurrentAffairsRepository(ILogger<ICurrentAffairsRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_currentaffairsget(@p_action, @p_id)",
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
                "SELECT * FROM fn_currentaffairsget(@p_action)",
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
                "SELECT * FROM fn_currentaffairsget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(CurrentAffairs currentaffairs)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_date",currentaffairs.Date},
                    { "p_catagory", currentaffairs.Catagory },
                    { "p_slug", currentaffairs.Slug },
                    { "p_content", currentaffairs.Content},
                    { "p_created_at",currentaffairs.Created_at},
                    { "p_updated_at",currentaffairs.Updated_at},
                    { "p_actionby", currentaffairs.ActionBy },
                    { "p_actiondate", currentaffairs.ActionDate },
                    { "p_isactive", currentaffairs.IsActive },
                    { "p_title",currentaffairs.Title}
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_currentaffairs(@p_date,@p_catagory, @p_slug, @p_content,@p_created_at,@p_updated_at, @p_isactive, @p_actionby, @p_actiondate,@p_title)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CurrentAffairs insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(CurrentAffairs currentaffairs)
        {
            try
            {
                Dictionary<string, object> parameters = new()
        {
            { "p_date",currentaffairs.Date},
            { "p_catagory", currentaffairs.Catagory },
            { "p_slug", currentaffairs.Slug },
            { "p_content", currentaffairs.Content},
            { "p_created_at",currentaffairs.Created_at},
            { "p_updated_at",currentaffairs.Updated_at},
            { "p_actionby", currentaffairs.ActionBy },
            { "p_actiondate", currentaffairs.ActionDate },
            { "p_isactive", currentaffairs.IsActive },
            { "p_title",currentaffairs.Title},
            { "p_id", currentaffairs.Id },
        };
                await _inpgsqlQuery.ExecuteQueryAsync(
                   "CALL sp_currentaffairs(@p_date,@p_catagory, @p_slug, @p_content,@p_created_at,@p_updated_at, @p_isactive, @p_actionby, @p_actiondate,@p_title,@p_id)",
                    parameters
                );

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error calling sp_currentaffairs: {ex.Message}");
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
                    "SELECT fn_currentaffairsbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting CurrentAffairs");
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
                    "SELECT fn_currentaffairsbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CurrentAffairs not found");
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
                    "SELECT fn_currentaffairsbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CurrentAffairs not found");
                throw;
            }
        }
    }
}
