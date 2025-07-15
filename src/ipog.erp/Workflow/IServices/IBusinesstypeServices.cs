using ipog.erp.Models;

namespace ipog.erp.Workflow.IServices
{
    public interface IBusinesstypeService
    {
        Task<GetResponse<GetBusinesstypeModel>> GetById(long id);
        Task<CollectionResponse<BusinesstypeModelCollection>> GetAll();
        Task<BusinesstypeModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(BusinesstypeModel businesstypeModel);
        Task<string> Update(BusinesstypeModel businesstypeModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
