using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ITnpsccoursevideosService
    {
        Task<GetResponse<GetTnpsccoursevideosModel>> GetById(long id);
        Task<CollectionResponse<TnpsccoursevideosModelCollection>> GetAll();
        Task<TnpsccoursevideosModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(TnpsccoursevideosModel tnpsccoursevideosModel);
        Task<Response> Update(TnpsccoursevideosModel tnpsccoursevideosModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
