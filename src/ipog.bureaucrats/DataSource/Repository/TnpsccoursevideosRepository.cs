using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class TnpsccoursevideosRepository : ITnpsccoursevideosRepository
    {
        private readonly ILogger<ITnpsccoursevideosRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public TnpsccoursevideosRepository(
            ILogger<ITnpsccoursevideosRepository> logger,
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
                    "SELECT * FROM fn_tnpsccoursevideosget(@p_action, @p_id)",
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
                "SELECT * FROM fn_tnpsccoursevideosget(@p_action)",
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
                "SELECT * FROM fn_tnpsccoursevideosget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Tnpsccoursevideos tnpsccoursevideos)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_coursename", tnpsccoursevideos.Coursename },
                    { "p_title", tnpsccoursevideos.Title },
                    { "p_youtubevideoid", tnpsccoursevideos.Youtubevideoid },
                    { "p_description", tnpsccoursevideos.Description },
                    { "p_isactive", tnpsccoursevideos.IsActive },
                    { "p_actionby", tnpsccoursevideos.Actionby },
                    { "p_actiondate", tnpsccoursevideos.Actiondate },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_tnpsccoursevideos(@p_coursename, @p_title, @p_youtubevideoid, @p_description, @p_isactive, @p_actionby, @p_actiondate)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "tnpsccoursevideos insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Tnpsccoursevideos tnpsccoursevideos)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_coursename", tnpsccoursevideos.Coursename },
                    { "p_title", tnpsccoursevideos.Title },
                    { "p_youtubevideoid", tnpsccoursevideos.Youtubevideoid },
                    { "p_description", tnpsccoursevideos.Description },
                    { "p_isactive", tnpsccoursevideos.IsActive },
                    { "p_actionby", tnpsccoursevideos.Actionby },
                    { "p_actiondate", tnpsccoursevideos.Actiondate },
                    { "p_id", tnpsccoursevideos.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_tnpsccoursevideos(@p_coursename,@p_title, @p_youtubevideoid, @p_description, @p_isactive, @p_actionby, @p_actiondate, @p_id)",
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
                    "SELECT fn_tnpsccoursevideosbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting tnpsccoursevideos");
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
                    "SELECT fn_tnpsccoursevideosbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "tnpsccoursevideos not found");
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
                    "SELECT fn_tnpsccoursevideosbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "tnpsccoursevideos not found");
                throw;
            }
        }
    }
}
