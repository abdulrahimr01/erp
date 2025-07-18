namespace ipog.bureaucrats.Entity
{
    public class Papers
    {
        public long Id { get; set; }
        public string? Exam { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
    }
}
