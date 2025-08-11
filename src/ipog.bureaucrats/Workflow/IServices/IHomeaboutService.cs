using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IHomeaboutService
    {
        Task<GetResponse<GetHomeaboutModel>> GetById(long id);
        Task<CollectionResponse<HomeaboutModelCollection>> GetAll();
        Task<HomeaboutModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(HomeaboutModel homeaboutModel);
        Task<Response> Update(HomeaboutModel homeaboutModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
