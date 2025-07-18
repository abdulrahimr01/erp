namespace ipog.bureaucrats.Models
{
    public class RoleModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class GetRoleModel : RoleModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class RoleModelCollection : List<GetRoleModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
