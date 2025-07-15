using ipog.erp.Entity;

namespace ipog.erp.DataSource.IRepository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ILogger<SupplierRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public SupplierRepository(ILogger<SupplierRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_supplierget(@p_action, @p_id)",
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
                "SELECT * FROM fn_supplierget(@p_action)",
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
                "SELECT * FROM fn_supplierget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Supplier supplier)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_typeid", supplier.Typeid },
                    { "p_name", supplier.Name },
                    { "p_gst", supplier.Gst },
                    { "p_landline", supplier.Landline },
                    { "p_email", supplier.Email },
                    { "p_contact", supplier.Contact },
                    { "p_mobile", supplier.Mobile },
                    { "p_address", supplier.Address },
                    { "p_actionby", supplier.Actionby },
                    { "p_isactive", supplier.IsActive },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_supplier(@p_typeid, @p_name, @p_gst, @p_landline, @p_email, @p_contact, @p_mobile, @p_address, @p_actionby, @p_isactive)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "supplier insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Supplier supplier)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_typeid", supplier.Typeid },
                    { "p_name", supplier.Name },
                    { "p_gst", supplier.Gst },
                    { "p_landline", supplier.Landline },
                    { "p_email", supplier.Email },
                    { "p_contact", supplier.Contact },
                    { "p_mobile", supplier.Mobile },
                    { "p_address", supplier.Address },
                    { "p_actionby", supplier.Actionby },
                    { "p_isactive", supplier.IsActive },
                    { "p_id", supplier.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_supplier(@p_typeid, @p_name, @p_gst, @p_landline, @p_email, @p_contact, @p_mobile, @p_address, @p_actionby, @p_isactive, @p_id)",
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
                    "SELECT fn_supplierbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting supplier");
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
                    "SELECT fn_supplierbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "supplier not found");
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
                    "SELECT fn_supplierbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "supplier not found");
                throw;
            }
        }
    }
}
