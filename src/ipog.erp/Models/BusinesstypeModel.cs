namespace ipog.erp.Models
{
    public class BusinesstypeModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public string? ActionBy { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetBusinesstypeModel : BusinesstypeModel
    {
        public string? ActionBy { get; set; }
    }

    public class BusinesstypeModelCollection : List<GetBusinesstypeModel>
    {
        public string? ActionBy { get; set; }
    }
}
