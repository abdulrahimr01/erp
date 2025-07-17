namespace ipog.bureaucrats.Models
{
    public class BooksModel
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Price { get; set; }
        public string? Originalprice { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? Stocks { get; set; }
        public DateTime? Actiondate { get; set; }
        public string? Actionby { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetBooksModel : BooksModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class BooksModelCollection : List<GetBooksModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
