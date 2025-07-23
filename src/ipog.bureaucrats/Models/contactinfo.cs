namespace ipog.bureaucrats.Models
{
    public class ContactInfoModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public string? Color { get; set; }
        public bool? IsActive { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class GetContactInfoModel : ContactInfoModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class ContactInfoModelCollection : List<GetContactInfoModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}

