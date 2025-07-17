using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ICoursevideosService
    {
        Task<GetResponse<GetCoursevideosModel>> GetById(long id);
        Task<CollectionResponse<CoursevideosModelCollection>> GetAll();
        Task<CoursevideosModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(CoursevideosModel coursevideosModel);
        Task<string> Update(CoursevideosModel coursevideosModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
