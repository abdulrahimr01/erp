using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IExamsService
    {
        Task<GetResponse<GetExamsModel>> GetById(long id);
        Task<CollectionResponse<ExamsModelCollection>> GetAll();
        Task<ExamsModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(ExamsModel examsModel);
        Task<string> Update(ExamsModel examsModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
