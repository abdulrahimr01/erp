using ipog.erp.Entity;

namespace ipog.erp.DataSource.IRepository
{
    public class BusinesstypeRepository : IBusinesstypeRepository
    {
        private readonly ILogger<IBusinesstypeRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public BusinesstypeRepository(
            ILogger<IBusinesstypeRepository> logger,
            INpgsqlQuery inpgsqlQuery
        )
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
                    "SELECT * FROM fn_businesstypeget(@p_action, @p_id)",
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
                "SELECT * FROM fn_businesstypeget(@p_action)",
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
                "SELECT * FROM fn_businesstypeget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Businesstype businesstype)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_name", businesstype.Name },
                    { "p_notes", businesstype.Notes },
                    { "p_actionby", businesstype.ActionBy },
                    { "p_isactive", businesstype.IsActive },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_businesstype(@p_name, @p_notes, @p_actionby, @p_isactive)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Businesstype insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Businesstype businesstype)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_name", businesstype.Name },
                    { "p_notes", businesstype.Notes },
                    { "p_isactive", businesstype.IsActive },
                    { "p_actionby", businesstype.ActionBy },
                    { "p_id", businesstype.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_businesstype(@p_name, @p_notes, @p_isactive, p_actionby, @p_id)",
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
                    "SELECT fn_businesstypebyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Businesstype");
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
                    "SELECT fn_businesstypebyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "businesstype not found");
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
                    "SELECT fn_businesstypebyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "businesstype not found");
                throw;
            }
        }
    }
}
