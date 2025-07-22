using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ICartpageService
    {
        Task<GetResponse<GetCartpageModel>> GetById(long id);
        Task<CollectionResponse<CartpageModelCollection>> GetAll();
        Task<CartpageModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(CartpageModel cartpageModel);
        Task<string> Update(CartpageModel cartpageModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
