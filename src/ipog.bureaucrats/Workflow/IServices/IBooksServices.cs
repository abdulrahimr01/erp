using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IBooksService
    {
        Task<GetResponse<GetBooksModel>> GetById(long id);
        Task<CollectionResponse<BooksModelCollection>> GetAll();
        Task<BooksModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(BooksModel booksModel);
        Task<Response> Update(BooksModel booksModel);
        Task<Response> Delete(long id);
        Task<Response> SetActiveStatus(long id);
        Task<Response> SetInActiveStatus(long id);
    }
}
