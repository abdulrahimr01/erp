using ipog.erp.Models;

namespace ipog.erp.Workflow.IServices
{
    public interface ICustomerService
    {
        Task<GetResponse<GetCustomerModel>> GetById(long id);
        Task<CollectionResponse<CustomerModelCollection>> GetAll();
        Task<CustomerModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(CustomerModel customerModel);
        Task<string> Update(CustomerModel customerModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
