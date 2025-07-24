namespace ipog.bureaucrats.Models
{
    public class DefaultPageModel
    {
        public long Id { get; set; }
        public string? Pagename { get; set; }
        public string? Pagepath { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }
        public bool IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class GetDefaultPageModel : DefaultPageModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class DefaultPageModelCollection : List<GetDefaultPageModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
