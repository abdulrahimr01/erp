namespace ipog.bureaucrats.Models
{
    public class PapersModel
    {
        public long Id { get; set; }
        public string? Exam { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
    }

    public class GetPapersModel : PapersModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class PapersModelCollection : List<GetPapersModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
