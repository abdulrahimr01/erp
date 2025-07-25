using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public interface IUserRepository
    {
        Task<List<Dictionary<string, object>>> GetById(long id);
        Task<List<Dictionary<string, object>>> GetAll();
        Task<List<Dictionary<string, object>>> GetFilter(Pagination pagination);
        Task<List<Dictionary<string, object>>> UserLogin(UserLogin request);
        Task<List<Dictionary<string, object>>> UpdatePassword(UpdatePassword request);
        Task<bool> Insert(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(long id);
        Task<bool> SetActiveStatus(long id);
        Task<bool> SetInActiveStatus(long id);
    }
}
