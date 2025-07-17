using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IContactInfoService
    {
        Task<GetResponse<GetContactInfoModel>> GetById(long id);
        Task<CollectionResponse<ContactInfoModelCollection>> GetAll();
        Task<ContactInfoModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(ContactInfoModel contactInfoModel);
        Task<string> Update(ContactInfoModel contactInfoModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}