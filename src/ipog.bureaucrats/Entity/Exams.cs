namespace ipog.bureaucrats.Entity
{
    public class Exams
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Actionby { get; set; }
        public DateTime? Actiondate { get; set; }
        public bool IsActive { get; set; }
    }
}
