using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IDefaultPageService
    {
        Task<GetResponse<GetDefaultPageModel>> GetById(long id);
        Task<CollectionResponse<DefaultPageModelCollection>> GetAll();
        Task<DefaultPageModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(DefaultPageModel defaultPageModel);
        Task<Response> Update(DefaultPageModel defaultPageModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}