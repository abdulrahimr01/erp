using ipog.erp.Entity;

namespace ipog.erp.DataSource.IRepository
{
    public interface IBusinesstypeRepository
    {
        Task<List<Dictionary<string, object>>> GetById(long id);
        Task<List<Dictionary<string, object>>> GetAll();
        Task<List<Dictionary<string, object>>> GetFilter(Pagination pagination);
        Task<bool> Insert(Businesstype businesstype);
        Task<bool> Update(Businesstype businesstype);
        Task<bool> Delete(long id);
        Task<bool> SetActiveStatus(long id);
        Task<bool> SetInActiveStatus(long id);
    }
}
