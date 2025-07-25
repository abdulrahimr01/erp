namespace ipog.bureaucrats.Models
{
    public class PaginationModel
    {
        public string OrderCol { get; set; } = "id";
        public string OrderDir { get; set; } = "ASC";
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
