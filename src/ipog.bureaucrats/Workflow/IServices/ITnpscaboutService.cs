using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ITnpscaboutService
    {
        Task<GetResponse<GetTnpscaboutModel>> GetById(long id);
        Task<CollectionResponse<TnpscaboutModelCollection>> GetAll();
        Task<TnpscaboutModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(TnpscaboutModel tnpscaboutModel);
        Task<string> Update(TnpscaboutModel tnpscaboutModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
