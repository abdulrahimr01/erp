using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IPapersService
    {
        Task<GetResponse<GetPapersModel>> GetById(long id);
        Task<CollectionResponse<PapersModelCollection>> GetAll();
        Task<PapersModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(PapersModel papersModel);
        Task<Response> Update(PapersModel papersModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
