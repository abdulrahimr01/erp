namespace ipog.bureaucrats.Models
{
    public class UpscaboutModel
    {
        public long Id { get; set; }
        public string? Text { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetUpscaboutModel : UpscaboutModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class UpscaboutModelCollection : List<GetUpscaboutModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
