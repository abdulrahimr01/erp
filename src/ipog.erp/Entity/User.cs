namespace ipog.erp.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public long RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsLogin { get; set; }
    }
}
