namespace ipog.bureaucrats.Entity
{
    public class Coursevideos
    {
        public long Id { get; set; }
        public string? Coursename { get; set; }
        public string? Title { get; set; }
        public string? Youtubevideoid { get; set; }
        public string? Description { get; set; }
        public DateTime? Actiondate { get; set; }
        public string? Actionby { get; set; }
        public bool IsActive { get; set; }
    }
}
