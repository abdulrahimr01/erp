namespace ipog.bureaucrats.Entity
{
    public class ContactInfo
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public string? Color { get; set; }
        public bool? IsActive { get; set; }

        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}