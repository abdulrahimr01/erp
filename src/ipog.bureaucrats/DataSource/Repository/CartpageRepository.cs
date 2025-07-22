using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class CartpageRepository : ICartpageRepository
    {
        private readonly ILogger<ICartpageRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public CartpageRepository(ILogger<ICartpageRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_cartpageget(@p_action, @p_id)",
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
                "SELECT * FROM fn_cartpageget(@p_action)",
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
                "SELECT * FROM fn_cartpageget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Cartpage cartpage)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_userid", cartpage.Userid },
                    { "p_productid", cartpage.Productid },
                    { "p_quantity", cartpage.Quantity },
                    { "p_price", cartpage.Price },
                    { "p_originalprice", cartpage.Originalprice },
                    { "p_actionby", cartpage.ActionBy },
                    { "p_actiondate", cartpage.ActionDate },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_cartpage(@p_userid, @p_productid, @p_quantity, @p_price, @p_originalprice, @p_actionby, @p_actiondate)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "cartpage insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Cartpage cartpage)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_userid", cartpage.Userid },
                    { "p_productid", cartpage.Productid },
                    { "p_quantity", cartpage.Quantity },
                    { "p_price", cartpage.Price },
                    { "p_originalprice", cartpage.Originalprice },
                    { "p_actionby", cartpage.ActionBy },
                    { "p_actiondate", cartpage.ActionDate },
                    { "p_id", cartpage.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_cartpage(@p_userid, @p_productid, @p_quantity, @p_price, @p_originalprice, @p_actionby, @p_actiondate, @p_id)",
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
                    "SELECT fn_cartpagebyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting cartpage");
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
                    "SELECT fn_cartpagebyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "cartpage not found");
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
                    "SELECT fn_cartpagebyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "cartpage not found");
                throw;
            }
        }
    }
}
