using ipog.erp.Models;

namespace ipog.erp.Workflow.IServices
{
    public interface IUserService
    {
        Task<GetUserModel> GetById(long id);
        Task<UserModelCollection> GetAll();
        Task<UserModelCollection> GetFilter(PaginationModel paginationModel);
        Task<string> Insert(UserModel userModel);
        Task<string> Update(UserModel userModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
