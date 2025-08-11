namespace ipog.bureaucrats.Models
{
    public class EditorialsModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public bool? IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class GetEditorialsModel : EditorialsModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class EditorialsModelCollection : List<GetEditorialsModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}

