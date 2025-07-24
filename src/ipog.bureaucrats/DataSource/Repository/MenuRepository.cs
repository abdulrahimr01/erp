using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ILogger<IMenuRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public MenuRepository(ILogger<IMenuRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_menuget(@p_action, @p_id)",
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
                "SELECT * FROM fn_menuget(@p_action)",
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
                "SELECT * FROM fn_menuget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Menu menu)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_menuname", menu.Menuname },
                    { "p_submenuname", menu.Submenuname },
                    { "p_menupath", menu.Menupath },
                    { "p_submenupath", menu.Submenupath },
                    { "p_icon", menu.Icon },
                    { "p_isactive", menu.IsActive },
                    { "p_actionby", menu.Actionby },
                    { "p_actiondate", menu.Actiondate },
                    { "p_usertype", menu.UserType },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_menu(@p_menuname, @p_submenuname,@p_menupath, @p_submenupath, @p_icon , @p_isactive, @p_actionby,  @p_actiondate,@p_usertype)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Menu insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Menu menu)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_menuname", menu.Menuname },
                    { "p_submenuname", menu.Submenuname },
                    { "p_menupath", menu.Menupath },
                    { "p_submenupath", menu.Submenupath },
                    { "p_icon", menu.Icon },
                    { "p_isactive", menu.IsActive },
                    { "p_actionby", menu.Actionby },
                    { "p_actiondate", menu.Actiondate },
                    { "p_usertype", menu.UserType },
                    { "p_id", menu.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_menu(@p_menuname, @p_submenuname, @p_menupath, @p_submenupath,@p_icon, @p_isactive,@p_actionby, @p_actiondate,@p_usertype, @p_id)",
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
                    "SELECT fn_menubyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting menu");
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
                    "SELECT fn_menubyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "menu not found");
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
                    "SELECT fn_menubyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "menu not found");
                throw;
            }
        }
    }
}
