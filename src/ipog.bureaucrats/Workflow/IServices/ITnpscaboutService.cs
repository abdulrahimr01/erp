using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ITnpscaboutService
    {
        Task<GetResponse<GetTnpscaboutModel>> GetById(long id);
        Task<CollectionResponse<TnpscaboutModelCollection>> GetAll();
        Task<TnpscaboutModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(TnpscaboutModel tnpscaboutModel);
        Task<Response> Update(TnpscaboutModel tnpscaboutModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
