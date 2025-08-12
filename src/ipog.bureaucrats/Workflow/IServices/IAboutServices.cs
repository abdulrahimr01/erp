using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IAboutService
    {
        Task<GetResponse<GetAboutModel>> GetById(long id);
        Task<CollectionResponse<AboutModelCollection>> GetAll();
        Task<AboutModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(AboutModel aboutModel);
        Task<Response> Update(AboutModel aboutModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
