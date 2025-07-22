namespace ipog.bureaucrats.Models
{
    public class CartpageModel
    {
        public long Id { get; set; }
        public string? Userid { get; set; }
        public string? Productid { get; set; }
        public string? Quantity { get; set; }
        public string? Price { get; set; }
        public string? Originalprice { get; set; }
        public string? ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
    }

    public class GetCartpageModel : CartpageModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class CartpageModelCollection : List<GetCartpageModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
