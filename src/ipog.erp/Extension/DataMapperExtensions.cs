namespace ipog.erp.Extension
{
    public static class DataMapperExtensions
    {
        public static T MapRowToModel<T>(Dictionary<string, object> row)
            where T : new()
        {
            T model = new();
            var props = typeof(T).GetProperties();

            // Normalize dictionary to be case-insensitive
            var caseInsensitiveRow = row.ToDictionary(
                static k => k.Key.ToLowerInvariant(),
                static v => v.Value
            );

            foreach (var prop in props)
            {
                string propName = prop.Name.ToLowerInvariant(); // Normalize prop name

                if (
                    caseInsensitiveRow.TryGetValue(propName, out var value)
                    && value != null
                    && prop.CanWrite
                )
                {
                    var targetType =
                        Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    var safeValue = Convert.ChangeType(value, targetType);
                    prop.SetValue(model, safeValue);
                }
            }

            return model;
        }
    }
}
