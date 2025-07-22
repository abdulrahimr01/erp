namespace ipog.bureaucrats.Entity
{
    public class Wishlist
    {
        public long Id { get; set; }
        public long? Userid { get; set; }
        public long? Itemid { get; set; }
        public string? Itemtitle { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
