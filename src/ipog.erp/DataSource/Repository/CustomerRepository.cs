using ipog.erp.Entity;

namespace ipog.erp.DataSource.IRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public CustomerRepository(ILogger<CustomerRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_customerget(@p_action, @p_id)",
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
                "SELECT * FROM fn_customerget(@p_action)",
                parameters
            );
            return result;
        }

        public async Task<List<Dictionary<string, object>>> GetFilter(Pagination pagination)
        {
            Dictionary<string, object> parameters = new()
            {
                { "p_action", "FILTER" },
                { "p_id", 0 },
                { "p_skip", pagination.Skip },
                { "p_take", pagination.Take },
                { "p_ordercol", pagination.OrderCol ?? "id" },
                { "p_orderdir", pagination.OrderDir ?? "ASC" },
            };
            List<Dictionary<string, object>> result = await _inpgsqlQuery.ExecuteReaderAsync(
                "SELECT * FROM fn_customerget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Customer customer)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_typeid", customer.Typeid },
                    { "p_name", customer.Name },
                    { "p_gst", customer.Gst },
                    { "p_landline", customer.Landline },
                    { "p_email", customer.Email },
                    { "p_contact", customer.Contact },
                    { "p_mobile", customer.Mobile },
                    { "p_address", customer.Address },
                    { "p_actionby", customer.ActionBy },
                    { "p_isactive", customer.IsActive },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_customer(@p_typeid, @p_name, @p_gst, @p_landline, @p_email, @p_contact, @p_mobile, @p_address, @p_actionby, @p_isactive)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "customer insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_typeid", customer.Typeid },
                    { "p_name", customer.Name },
                    { "p_gst", customer.Gst },
                    { "p_landline", customer.Landline },
                    { "p_email", customer.Email },
                    { "p_contact", customer.Contact },
                    { "p_mobile", customer.Mobile },
                    { "p_address", customer.Address },
                    { "p_actionby", customer.ActionBy },
                    { "p_isactive", customer.IsActive },
                    { "p_id", customer.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_Customer(@p_typeid, @p_name, @p_gst, @p_landline, @p_email, @p_contact, @p_mobile, @p_address, @p_actionby, @p_isactive, @p_id)",
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
                    "SELECT fn_customerbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting customer");
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
                    "SELECT fn_customerbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "customer not found");
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
                    "SELECT fn_customerbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "customer not found");
                throw;
            }
        }
    }
}
