namespace ipog.bureaucrats.Entity
{
    public class Role
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
