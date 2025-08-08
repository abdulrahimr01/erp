namespace ipog.bureaucrats.Entity
{
    public class CurrentAffairs
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string? Catagory { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public bool? IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
        public string? Title { get; set; }
    }
}