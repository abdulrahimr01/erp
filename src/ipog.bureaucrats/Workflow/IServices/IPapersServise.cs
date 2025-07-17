using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IPapersService
    {
        Task<GetResponse<GetPapersModel>> GetById(long id);
        Task<CollectionResponse<PapersModelCollection>> GetAll();
        Task<PapersModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(PapersModel papersModel);
        Task<string> Update(PapersModel papersModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
