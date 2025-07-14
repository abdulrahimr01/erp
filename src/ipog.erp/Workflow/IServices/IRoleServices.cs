using ipog.erp.Models;

namespace ipog.erp.Workflow.IServices
{
    public interface IRoleService
    {
        Task<GetResponse<GetRoleModel>> GetById(long id);
        Task<CollectionResponse<RoleModelCollection>> GetAll();
        Task<RoleModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(RoleModel roleModel);
        Task<string> Update(RoleModel roleModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
