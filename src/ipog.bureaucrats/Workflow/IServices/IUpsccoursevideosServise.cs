using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IUpsccoursevideosService
    {
        Task<GetResponse<GetUpsccoursevideosModel>> GetById(long id);
        Task<CollectionResponse<UpsccoursevideosModelCollection>> GetAll();
        Task<UpsccoursevideosModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(UpsccoursevideosModel upsccoursevideosModel);
        Task<string> Update(UpsccoursevideosModel upsccoursevideosModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
