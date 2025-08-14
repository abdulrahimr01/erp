namespace ipog.bureaucrats.Models
{
    public class BooksModel
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? ExamName { get; set; }
        public string? Author { get; set; }
        public decimal? Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public int? Stocks { get; set; }
        public bool IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; } 
        public byte[]? FrontImage { get; set; }
        public byte[]? BackImage { get; set; }
        public string? Course {get;set;}
    }

    public class BooksFormDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string ExamName { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public decimal Originalprice { get; set; }
    public string Description { get; set; }
    public string Details { get; set; }
    public int Stocks { get; set; }
    public bool IsActive { get; set; }
    public string ActionBy { get; set; }
    public DateTime ActionDate { get; set; }
    public string Course { get; set; }

    // IFormFile directly here
    public IFormFile? FrontImage { get; set; }
    public IFormFile? BackImage { get; set; }
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
