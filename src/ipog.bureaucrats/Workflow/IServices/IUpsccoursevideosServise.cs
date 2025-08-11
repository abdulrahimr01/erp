using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IUpsccoursevideosService
    {
        Task<GetResponse<GetUpsccoursevideosModel>> GetById(long id);
        Task<CollectionResponse<UpsccoursevideosModelCollection>> GetAll();
        Task<UpsccoursevideosModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(UpsccoursevideosModel upsccoursevideosModel);
        Task<Response> Update(UpsccoursevideosModel upsccoursevideosModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
