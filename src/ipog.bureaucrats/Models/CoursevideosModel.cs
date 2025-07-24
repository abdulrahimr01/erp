namespace ipog.bureaucrats.Models
{
    public class CoursevideosModel
    {
        public long Id { get; set; }
        public string? Coursename { get; set; }
        public string? Title { get; set; }
        public string? Youtubevideoid { get; set; }
        public string? Description { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? ActionBy { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetCoursevideosModel : CoursevideosModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class CoursevideosModelCollection : List<GetCoursevideosModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
