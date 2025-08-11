using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IMenuService
    {
        Task<GetResponse<GetMenuModel>> GetById(long id);
        Task<CollectionResponse<MenuModelCollection>> GetAll();
        Task<MenuModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(MenuModel menuModel);
        Task<Response> Update(MenuModel menuModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
