namespace ipog.bureaucrats.Entity
{
    public class About
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public string? Content { get; set; }
        public string? Actionby { get; set; }
        public DateTime? Actiondate { get; set; }
        public bool IsActive { get; set; }
    }
}
