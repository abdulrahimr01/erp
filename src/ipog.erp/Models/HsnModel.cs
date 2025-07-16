namespace ipog.erp.Models
{
    public class HsnModel
    {
        public long Id { get; set; }
        public long? Categoryid { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public string? Gst { get; set; }
        public string? Sgst { get; set; }
        public string? Cgst { get; set; }
        public string? Actionby { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetHsnModel : HsnModel
    {
        public string? ActionBy { get; set; }
    }

    public class HsnModelCollection : List<GetHsnModel>
    {
        public string? ActionBy { get; set; }
    }
}
