namespace ipog.bureaucrats.Models
{
    public class CoursevideosModel
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Youtubevideoid { get; set; }
        public string? Description { get; set; }
        public DateTime? Actiondate { get; set; }
        public string? Actionby { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetCoursevideosModel : CoursevideosModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class CoursevideosModelCollection : List<GetCoursevideosModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
