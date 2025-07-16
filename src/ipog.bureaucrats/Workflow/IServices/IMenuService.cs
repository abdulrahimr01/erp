using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IMenuService
    {
        Task<GetResponse<GetMenuModel>> GetById(long id);
        Task<CollectionResponse<MenuModelCollection>> GetAll();
        Task<MenuModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(MenuModel menuModel);
        Task<string> Update(MenuModel menuModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
