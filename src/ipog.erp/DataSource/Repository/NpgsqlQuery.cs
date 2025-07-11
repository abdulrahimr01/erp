using Npgsql;

namespace ipog.erp.DataSource.IRepository
{
    public class NpgsqlQuery : INpgsqlQuery
    {
        private readonly string _connString;
        private readonly ILogger<NpgsqlQuery> _logger;

        public NpgsqlQuery(IConfiguration config, ILogger<NpgsqlQuery> logger)
        {
            _connString = config.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        private async Task<List<Dictionary<string, object>>> ExecuteReaderAsync(
            string query,
            Dictionary<string, object>? parameters = null
        )
        {
            var results = new List<Dictionary<string, object>>();
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(query, conn);

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                }
                results.Add(row);
            }

            return results;
        }

        public async Task ExecuteQueryAsync(
            string query,
            Dictionary<string, object>? parameters = null
        )
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(query, conn);

            foreach (var param in parameters)
            {
                // Handle DateTime kind for timestamps if needed
                if (param.Value is DateTime dt)
                {
                    cmd.Parameters.Add(
                        new NpgsqlParameter(param.Key, NpgsqlTypes.NpgsqlDbType.Timestamp)
                        {
                            Value = DateTime.SpecifyKind(dt, DateTimeKind.Unspecified),
                        }
                    );
                }
                else
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<bool> ExecuteScalarAsync(
            string query,
            Dictionary<string, object>? parameters = null
        )
        {
            await using var conn = new NpgsqlConnection(_connString);
            await conn.OpenAsync();
            await using var cmd = new NpgsqlCommand(query, conn);

            foreach (var param in parameters)
            {
                // Handle DateTime kind for timestamps if needed
                if (param.Value is DateTime dt)
                {
                    cmd.Parameters.Add(
                        new NpgsqlParameter(param.Key, NpgsqlTypes.NpgsqlDbType.Timestamp)
                        {
                            Value = DateTime.SpecifyKind(dt, DateTimeKind.Unspecified),
                        }
                    );
                }
                else
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            var result = await cmd.ExecuteScalarAsync();
            return result is bool b && b;
        }

        Task<List<Dictionary<string, object>>> INpgsqlQuery.ExecuteReaderAsync(
            string query,
            Dictionary<string, object>? parameters
        )
        {
            return ExecuteReaderAsync(query, parameters);
        }
    }
}
