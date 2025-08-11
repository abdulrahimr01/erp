using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IUserService
    {
        Task<GetResponse<GetUserModel>> GetById(long id);
        Task<CollectionResponse<UserModelCollection>> GetAll();
        Task<UserModelCollection> GetFilter(PaginationModel paginationModel);
        Task<GetResponse<GetUserModel>> UserLogin(UserLoginModel request);
        Task<GetResponse<GetUserModel>> UpdatePassword(UpdatePasswordModel requestModel);
        Task<Response> Insert(UserModel userModel);
        Task<Response> Update(UserModel userModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
