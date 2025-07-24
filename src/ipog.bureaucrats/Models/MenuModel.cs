namespace ipog.bureaucrats.Models
{
    public class MenuModel
    {
        public long Id { get; set; }
        public string? Menuname { get; set; }
        public string? Submenuname { get; set; }
        public string? Icon { get; set; }
        public string? Menupath { get; set; }
        public string? Submenupath { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? ActionBy { get; set; }
        public bool IsActive { get; set; }
        public string? UserType { get; set; }
    }

    public class GetMenuModel : MenuModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class MenuModelCollection : List<GetMenuModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
