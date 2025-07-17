using ipog.bureaucrats.Models;

namespace ipog.bureaucrats.Workflow.IServices
{
    public interface IBooksService
    {
        Task<GetResponse<GetBooksModel>> GetById(long id);
        Task<CollectionResponse<BooksModelCollection>> GetAll();
        Task<BooksModelCollection> GetFilter(PaginationModel paginationModel);
        Task<Response> Insert(BooksModel booksModel);
        Task<string> Update(BooksModel booksModel);
        Task<string> Delete(long id);
        Task<string> SetActiveStatus(long id);
        Task<string> SetInActiveStatus(long id);
    }
}
