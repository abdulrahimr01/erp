using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IWishlistService
    {
        Task<GetResponse<GetWishlistModel>> GetById(long id);
        Task<CollectionResponse<WishlistModelCollection>> GetAll();
        Task<WishlistModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(WishlistModel wishlistModel);
        Task<Response> Update(WishlistModel wishlistModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
