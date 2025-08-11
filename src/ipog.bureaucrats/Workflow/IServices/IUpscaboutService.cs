using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IUpscaboutService
    {
        Task<GetResponse<GetUpscaboutModel>> GetById(long id);
        Task<CollectionResponse<UpscaboutModelCollection>> GetAll();
        Task<UpscaboutModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(UpscaboutModel upscaboutModel);
        Task<Response> Update(UpscaboutModel upscaboutModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
