using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ILogger<IBooksRepository> _logger;
        private readonly INpgsqlQuery _inpgsqlQuery;

        public BooksRepository(ILogger<IBooksRepository> logger, INpgsqlQuery inpgsqlQuery)
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
                    "SELECT * FROM fn_booksget(@p_action, @p_id)",
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
                "SELECT * FROM fn_booksget(@p_action)",
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
                "SELECT * FROM fn_booksget(@p_action, @p_id, @p_skip, @p_take, @p_ordercol, @p_orderdir)",
                parameters
            );
            return result;
        }

        public async Task<bool> Insert(Books books)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_title", books.Title },
                    { "p_examname", books.ExamName },
                    { "p_author", books.Author },
                    { "p_price", books.Price },
                    { "p_originalprice", books.Originalprice },
                    { "p_description", books.Description },
                    { "p_details", books.Details },
                    { "p_stocks", books.Stocks },
                    { "p_isactive", books.IsActive },
                    { "p_actionby", books.ActionBy },
                    { "p_actiondate", books.ActionDate },
                    { "p_frontimage", books.FrontImage },
                    { "p_backimage", books.BackImage },
                    { "p_course",books.Course}
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_books(@p_title, @p_examname, @p_author, @p_price, @p_originalprice, @p_description, @p_details, @p_stocks, @p_isactive, @p_actionby, @p_actiondate,@p_frontimage,@p_backimage,@p_course)",
                    parameters
                );
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Books insert failed.");
                return false;
            }
        }

        public async Task<bool> Update(Books books)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_title", books.Title },
                    { "p_examname", books.ExamName },
                    { "p_author", books.Author },
                    { "p_price", books.Price },
                    { "p_originalprice", books.Originalprice },
                    { "p_description", books.Description },
                    { "p_details", books.Details },
                    { "p_stocks", books.Stocks },
                    { "p_isactive", books.IsActive },
                    { "p_actionby", books.ActionBy },
                    { "p_actiondate", books.ActionDate },
                    { "p_frontimage", books.FrontImage },
                    { "p_backimage", books.BackImage },
                    { "p_course",books.Course},
                    { "p_id", books.Id },
                };
                await _inpgsqlQuery.ExecuteQueryAsync(
                    "CALL sp_books(@p_title, @p_examname, @p_author, @p_price, @p_originalprice, @p_description, @p_details, @p_stocks, @p_isactive, @p_actionby, @p_actiondate,@p_frontimage,@p_backimage,@p_course, @p_id)",
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
                    "SELECT fn_booksbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting books");
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
                    "SELECT fn_booksbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "books not found");
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
                    "SELECT fn_booksbyid(@p_action, @p_id)",
                    parameters
                );
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "books not found");
                throw;
            }
        }
    }
}
