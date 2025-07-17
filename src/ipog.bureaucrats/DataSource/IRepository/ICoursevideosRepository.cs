using ipog.bureaucrats.Entity;

namespace ipog.bureaucrats.DataSource.IRepository
{
    public interface ICoursevideosRepository
    {
        Task<List<Dictionary<string, object>>> GetById(long id);
        Task<List<Dictionary<string, object>>> GetAll();
        Task<List<Dictionary<string, object>>> GetFilter(Pagination pagination);
        Task<bool> Insert(Coursevideos coursevideos);
        Task<bool> Update(Coursevideos coursevideos);
        Task<bool> Delete(long id);
        Task<bool> SetActiveStatus(long id);
        Task<bool> SetInActiveStatus(long id);
    }
}
