namespace ipog.bureaucrats.Entity
{
    public class Homeabout
    {
        public long Id { get; set; }
        public string? Text { get; set; }
        public string? Actionby { get; set; }
        public DateTime? Actiondate { get; set; }
        public bool IsActive { get; set; }
    }
}
