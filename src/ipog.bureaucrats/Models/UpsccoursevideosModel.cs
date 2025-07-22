namespace ipog.bureaucrats.Models
{
    public class UpsccoursevideosModel
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

    public class GetUpsccoursevideosModel : UpsccoursevideosModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class UpsccoursevideosModelCollection : List<GetUpsccoursevideosModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
