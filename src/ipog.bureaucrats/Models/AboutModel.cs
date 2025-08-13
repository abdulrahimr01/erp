namespace ipog.bureaucrats.Models
{
    public class AboutModel
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public string? Content { get; set; }
        public bool IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
    }

    public class GetAboutModel : AboutModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class AboutModelCollection : List<GetAboutModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
