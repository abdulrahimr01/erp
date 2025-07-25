using ipog.erp.Entity;

namespace ipog.erp.DataSource.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Dictionary<string, object>>> GetById(long id);
        Task<List<Dictionary<string, object>>> GetAll();
        Task<List<Dictionary<string, object>>> GetFilter(Pagination pagination);
        Task<bool> Insert(Category category);
        Task<bool> Update(Category category);
        Task<bool> Delete(long id);
        Task<bool> SetActiveStatus(long id);
        Task<bool> SetInActiveStatus(long id);
    }
}
