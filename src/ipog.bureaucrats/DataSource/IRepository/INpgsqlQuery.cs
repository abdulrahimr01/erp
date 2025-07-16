namespace ipog.bureaucrats.DataSource.IRepository
{
    public interface INpgsqlQuery
    {
        Task<List<Dictionary<string, object>>> ExecuteReaderAsync(
            string query,
            Dictionary<string, object>? parameters = null
        );

        Task ExecuteQueryAsync(string query, Dictionary<string, object>? parameters = null);
        Task<bool> ExecuteScalarAsync(string query, Dictionary<string, object>? parameters = null);
    }
}
