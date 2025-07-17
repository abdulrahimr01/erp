using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly ILogger<IContactInfoRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public ContactInfoRepository(ILogger<IContactInfoRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_contactinfoget(@p_action, @p_id)",
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
                "SELECT * FROM fn_contactinfoget(@p_action)",
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
                "SELECT * FROM fn_contactinfoget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(ContactInfo contactinfo)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_name", contactinfo.Name },
                    { "p_details", contactinfo.Details },
                    { "p_color", contactinfo.Color },
                    { "p_actionby", contactinfo.ActionBy },
                    { "p_actiondate", contactinfo.ActionDate },
                    { "p_isactive", contactinfo.IsActive },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_contactinfo(@p_name, @p_details, @p_color, @p_isactive, @p_actionby, @p_actiondate)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactInfo insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(ContactInfo contactinfo)
        {
            try
            {
                Dictionary<string, object> parameters = new()
        {
            { "p_name", contactinfo.Name },
            { "p_details", contactinfo.Details },
            { "p_color", contactinfo.Color },
            { "p_isactive", contactinfo.IsActive },
            { "p_actionby", contactinfo.ActionBy },
            { "p_actiondate", contactinfo.ActionDate },
            { "p_id", contactinfo.Id },
        };

                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_contactinfo(@p_name, @p_details, @p_color, @p_isactive, @p_actionby, @p_actiondate, @p_id)",
                    parameters
                );

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error calling sp_contactinfo: {ex.Message}");
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
                    "SELECT fn_contactinfobyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting ContactInfo");
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
                    "SELECT fn_contactinfobyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactInfo not found");
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
                    "SELECT fn_contactinfobyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactInfo not found");
                throw;
            }
        }
    }
}
