using ipog.erp.Models;

namespace ipog.erp.Workflow.IServices
{
    public interface ICategoryService
    {
        Task<GetResponse<GetCategoryModel>> GetById(long id);
        Task<CollectionResponse<CategoryModelCollection>> GetAll();
        Task<CategoryModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(CategoryModel categoryModel);
        Task<string> Update(CategoryModel categoryModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
