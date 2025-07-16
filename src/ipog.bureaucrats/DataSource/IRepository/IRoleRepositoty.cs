using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public interface IRoleRepository
    {
        Task<List<Dictionary<string, object>>> GetById(long id);
        Task<List<Dictionary<string, object>>> GetAll();
        Task<List<Dictionary<string, object>>> GetFilter(Pagination pagination);
        Task<bool> Insert(Role role);
        Task<bool> Update(Role role);
        Task<bool> Delete(long id);
        Task<bool> SetActiveStatus(long id);
        Task<bool> SetInActiveStatus(long id);
    }
}
