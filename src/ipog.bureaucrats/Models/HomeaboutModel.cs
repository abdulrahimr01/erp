namespace ipog.bureaucrats.Models
{
    public class HomeaboutModel
    {
        public long Id { get; set; }
        public string? Text { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetHomeaboutModel : HomeaboutModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class HomeaboutModelCollection : List<GetHomeaboutModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
