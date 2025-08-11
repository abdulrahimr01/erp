using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class EditorialsRepository : IEditorialsRepository
    {
        private readonly ILogger<IEditorialsRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public EditorialsRepository(ILogger<IEditorialsRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_editorialsget(@p_action, @p_id)",
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
                "SELECT * FROM fn_editorialsget(@p_action)",
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
                "SELECT * FROM fn_editorialsget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Editorials editorials)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_date",editorials.Date},
                    { "p_category", editorials.Category },
                    { "p_title",editorials.Title},
                    { "p_slug", editorials.Slug },
                    { "p_content", editorials.Content},
                    { "p_created_at",editorials.Created_at},
                    { "p_updated_at",editorials.Updated_at},
                    { "p_actionby", editorials.ActionBy },
                    { "p_actiondate", editorials.ActionDate },
                    { "p_isactive", editorials.IsActive }
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_editorials(@p_date,@p_category,@p_title, @p_slug, @p_content,@p_created_at,@p_updated_at, @p_isactive, @p_actionby, @p_actiondate)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Editorials insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Editorials editorials)
        {
            try
            {
                Dictionary<string, object> parameters = new()
        {
            { "p_date",editorials.Date},
            { "p_category", editorials.Category },
            { "p_title",editorials.Title},
            { "p_slug", editorials.Slug },
            { "p_content", editorials.Content},
            { "p_created_at",editorials.Created_at},
            { "p_updated_at",editorials.Updated_at},
            { "p_actionby", editorials.ActionBy },
            { "p_actiondate", editorials.ActionDate },
            { "p_isactive", editorials.IsActive },
            { "p_id", editorials.Id },
        };
                await _inpgsqlQuery.ExecuteQueryAsync(
                   "CALL sp_editorials(@p_date,@p_category,@p_title, @p_slug, @p_content,@p_created_at,@p_updated_at, @p_isactive, @p_actionby, @p_actiondate,@p_id)",
                    parameters
                );

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error calling sp_editorials: {ex.Message}");
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
                    "SELECT fn_editorialsbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Editorials");
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
                    "SELECT fn_editorialsbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Editorials not found");
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
                    "SELECT fn_editorialsbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Editorials not found");
                throw;
            }
        }
    }
}
