namespace ipog.bureaucrats.Entity
{
    public class Cartpage
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
}
