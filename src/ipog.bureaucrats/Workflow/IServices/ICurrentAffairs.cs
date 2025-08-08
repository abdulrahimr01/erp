using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ICurrentAffairsService
    {
        Task<GetResponse<GetCurrentAffairsModel>> GetById(long id);
        Task<CollectionResponse<CurrentAffairsModelCollection>> GetAll();
        Task<CurrentAffairsModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(CurrentAffairsModel currentAffairsModel);
        Task<Response> Update(CurrentAffairsModel currentAffairsModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}