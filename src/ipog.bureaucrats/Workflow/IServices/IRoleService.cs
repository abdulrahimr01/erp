using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IRoleService
    {
        Task<GetResponse<GetRoleModel>> GetById(long id);
        Task<CollectionResponse<RoleModelCollection>> GetAll();
        Task<RoleModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(RoleModel roleModel);
        Task<Response> Update(RoleModel roleModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
