using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IHomeaboutService
    {
        Task<GetResponse<GetHomeaboutModel>> GetById(long id);
        Task<CollectionResponse<HomeaboutModelCollection>> GetAll();
        Task<HomeaboutModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(HomeaboutModel homeaboutModel);
        Task<string> Update(HomeaboutModel homeaboutModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
