namespace ipog.erp.Models
{
    public class Response
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class GetResponse<T> : Response
    {
        public T? Data { get; set; }
    }

    public class CollectionResponse<T> : Response
    {
        public Record<T>? Record { get; set; }
    }

    public class Record<T>
    {
        public int Count { get; set; }
        public T? Data { get; set; }
    }
}
