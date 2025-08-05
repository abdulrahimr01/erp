using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ICurrentAffairsService
    {
        Task<GetResponse<GetCurrentAffairsModel>> GetById(long id);
        Task<CollectionResponse<CurrentAffairsModelCollection>> GetAll();
        Task<CurrentAffairsModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(CurrentAffairsModel currentAffairsModel);
        Task<string> Update(CurrentAffairsModel currentAffairsModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}