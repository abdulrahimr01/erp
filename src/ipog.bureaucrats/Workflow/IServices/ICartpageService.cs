using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ICartpageService
    {
        Task<GetResponse<GetCartpageModel>> GetById(long id);
        Task<CollectionResponse<CartpageModelCollection>> GetAll();
        Task<CartpageModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(CartpageModel cartpageModel);
        Task<Response> Update(CartpageModel cartpageModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
