namespace ipog.bureaucrats.Models
{
    public class ExamsModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetExamsModel : ExamsModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class ExamsModelCollection : List<GetExamsModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
