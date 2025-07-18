using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class PapersRepository : IPapersRepository
    {
        private readonly ILogger<IPapersRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public PapersRepository(ILogger<IPapersRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_papersget(@p_action, @p_id)",
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
                "SELECT * FROM fn_papersget(@p_action)",
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
                "SELECT * FROM fn_papersget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Papers papers)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_exam", papers.Exam },
                    { "p_name", papers.Name },
                    { "p_isactive", papers.IsActive },
                    { "p_actionby", papers.ActionBy },
                    { "p_actiondate", papers.ActionDate },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_papers(@p_exam, @p_name, @p_isactive, @p_actionby, @p_actiondate)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "papers insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Papers papers)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_exam", papers.Exam },
                    { "p_name", papers.Name },
                    { "p_isactive", papers.IsActive },
                    { "p_actionby", papers.ActionBy },
                    { "p_actiondate", papers.ActionDate },
                    { "p_id", papers.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_papers(@p_exam, @p_name, @p_isactive, @p_actionby, @p_actiondate, @p_id)",
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
                    "SELECT fn_papersbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting papers");
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
                    "SELECT fn_papersbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "papers not found");
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
                    "SELECT fn_papersbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "papers not found");
                throw;
            }
        }
    }
}
