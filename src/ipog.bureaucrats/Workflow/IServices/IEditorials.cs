using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IEditorialsService
    {
        Task<GetResponse<GetEditorialsModel>> GetById(long id);
        Task<CollectionResponse<EditorialsModelCollection>> GetAll();
        Task<EditorialsModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(EditorialsModel editorialsModel);
        Task<Response> Update(EditorialsModel editorialsModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}