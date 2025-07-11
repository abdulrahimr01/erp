using ipog.erp.Models;

namespace ipog.erp.Workflow.IServices
{
    public interface IUserService
    {
        Task<GetResponse<GetUserModel>> GetById(long id);
        Task<CollectionResponse<UserModelCollection>> GetAll();
        Task<UserModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(UserModel userModel);
        Task<string> Update(UserModel userModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
