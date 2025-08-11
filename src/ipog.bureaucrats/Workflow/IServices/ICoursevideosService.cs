using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface ICoursevideosService
    {
        Task<GetResponse<GetCoursevideosModel>> GetById(long id);
        Task<CollectionResponse<CoursevideosModelCollection>> GetAll();
        Task<CoursevideosModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(CoursevideosModel coursevideosModel);
        Task<Response> Update(CoursevideosModel coursevideosModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
