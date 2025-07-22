namespace ipog.bureaucrats.Models
{
    public class WishlistModel
    {
        public long Id { get; set; }
        public long? Userid { get; set; }
        public long? Itemid { get; set; }
        public string? Itemtitle { get; set; }
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class GetWishlistModel : WishlistModel
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }

    public class WishlistModelCollection : List<GetWishlistModel>
    {
        public string? ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
