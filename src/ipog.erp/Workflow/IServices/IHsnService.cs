using ipog.erp.Models;

namespace ipog.erp.Workflow.IServices
{
    public interface IHsnService
    {
        Task<GetResponse<GetHsnModel>> GetById(long id);
        Task<CollectionResponse<HsnModelCollection>> GetAll();
        Task<HsnModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(HsnModel hsn);
        Task<string> Update(HsnModel hsn);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
