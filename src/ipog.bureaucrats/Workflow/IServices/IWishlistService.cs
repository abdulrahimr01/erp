using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IWishlistService
    {
        Task<GetResponse<GetWishlistModel>> GetById(long id);
        Task<CollectionResponse<WishlistModelCollection>> GetAll();
        Task<WishlistModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(WishlistModel wishlistModel);
        Task<string> Update(WishlistModel wishlistModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
