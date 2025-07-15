namespace ipog.erp.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public string? Actionby { get; set; }
        public bool IsActive { get; set; }
    }

    public class GetCategoryModel : CategoryModel
    {
        public string? ActionBy { get; set; }
    }

    public class CategoryModelCollection : List<GetCategoryModel>
    {
        public string? ActionBy { get; set; }
    }
}
