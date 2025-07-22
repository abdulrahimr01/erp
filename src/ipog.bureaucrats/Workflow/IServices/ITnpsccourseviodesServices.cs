using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ITnpsccoursevideosService
    {
        Task<GetResponse<GetTnpsccoursevideosModel>> GetById(long id);
        Task<CollectionResponse<TnpsccoursevideosModelCollection>> GetAll();
        Task<TnpsccoursevideosModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(TnpsccoursevideosModel tnpsccoursevideosModel);
        Task<string> Update(TnpsccoursevideosModel tnpsccoursevideosModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
