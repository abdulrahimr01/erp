using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IUpscaboutService
    {
        Task<GetResponse<GetUpscaboutModel>> GetById(long id);
        Task<CollectionResponse<UpscaboutModelCollection>> GetAll();
        Task<UpscaboutModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(UpscaboutModel upscaboutModel);
        Task<string> Update(UpscaboutModel upscaboutModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
