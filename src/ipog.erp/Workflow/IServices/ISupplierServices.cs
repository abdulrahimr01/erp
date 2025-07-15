using ipog.erp.Models;

namespace ipog.erp.Workflow.IServices
{
    public interface ISupplierService
    {
        Task<GetResponse<GetSupplierModel>> GetById(long id);
        Task<CollectionResponse<SupplierModelCollection>> GetAll();
        Task<SupplierModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(SupplierModel supplierModel);
        Task<string> Update(SupplierModel supplierModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
