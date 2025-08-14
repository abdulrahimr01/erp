namespace ipog.bureaucrats.Entity
{
    public class Books
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
        public string? Course { get; set; }
    }
}
