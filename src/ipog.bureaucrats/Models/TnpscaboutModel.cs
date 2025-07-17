namespace ipog.bureaucrats.Models
{
    public class TnpscaboutModel
    {
        public long Id { get; set; }
        public string? Text { get; set; }
        public string? Actionby { get; set; }
        public DateTime? Actiondate { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetTnpscaboutModel : TnpscaboutModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class TnpscaboutModelCollection : List<GetTnpscaboutModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
