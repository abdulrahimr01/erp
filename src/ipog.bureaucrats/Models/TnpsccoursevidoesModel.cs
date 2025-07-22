namespace ipog.bureaucrats.Models
{
    public class TnpsccoursevideosModel
    {
        public long Id { get; set; }
        public string? Coursename { get; set; }
        public string? Title { get; set; }
        public string? Youtubevideoid { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? ActionBy { get; set; }
    }

    public class GetTnpsccoursevideosModel : TnpsccoursevideosModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class TnpsccoursevideosModelCollection : List<GetTnpsccoursevideosModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
