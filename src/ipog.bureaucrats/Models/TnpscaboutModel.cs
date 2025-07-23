namespace ipog.bureaucrats.Models
{
    public class TnpscaboutModel
    {
        public long Id { get; set; }
        public string? Text { get; set; }
        public bool IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
    }

    public class GetTnpscaboutModel : TnpscaboutModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class TnpscaboutModelCollection : List<GetTnpscaboutModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
