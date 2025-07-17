namespace ipog.bureaucrats.Entity
{
    public class DefaultPage
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
}