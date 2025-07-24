namespace ipog.bureaucrats.Entity
{
    public class Menu
    {
        public long Id { get; set; }
        public string? Menuname { get; set; }
        public string? Submenuname { get; set; }
        public string? Menupath { get; set; }
        public string? Submenupath { get; set; }
        public string? Icon { get; set; }
        public DateTime? Actiondate { get; set; }
        public string? Actionby { get; set; }
        public bool IsActive { get; set; }
        public string? UserType { get; set; }
    }
}
