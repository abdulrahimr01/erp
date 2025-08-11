using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IExamsService
    {
        Task<GetResponse<GetExamsModel>> GetById(long id);
        Task<CollectionResponse<ExamsModelCollection>> GetAll();
        Task<ExamsModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(ExamsModel examsModel);
        Task<Response> Update(ExamsModel examsModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
