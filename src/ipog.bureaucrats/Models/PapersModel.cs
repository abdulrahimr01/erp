namespace ipog.bureaucrats.Models
{
    public class PapersModel
    {
        public long Id { get; set; }
        public string? Exam { get; set; }
        public string? Name { get; set; }
        public string? Actionby { get; set; }
        public DateTime? Actiondate { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetPapersModel : PapersModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class PapersModelCollection : List<GetPapersModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
