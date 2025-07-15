namespace ipog.erp.Models
{
    public class SupplierModel
    {
        public long Id { get; set; }
        public long? Typeid { get; set; }
        public string? Name { get; set; }
        public string? Gst { get; set; }
        public long Landline { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Actionby { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetSupplierModel : SupplierModel
    {
        public string? ActionBy { get; set; }
    }

    public class SupplierModelCollection : List<GetSupplierModel>
    {
        public string? ActionBy { get; set; }
    }
}
