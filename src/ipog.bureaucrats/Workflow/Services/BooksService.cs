using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class BooksService : IBooksService
    {
        private readonly ILogger<BooksService> _logger;
        private readonly IMapping _mapper;
        private readonly IBooksRepository _iBooksRepository;

        public BooksService(
            ILogger<BooksService> logger,
            IMapping mapper,
            IBooksRepository iBooksRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iBooksRepository = iBooksRepository;
        }

        public async Task<GetResponse<GetBooksModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iBooksRepository.GetById(id);
            Books? books = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Books>(row))
                .FirstOrDefault();
            if (books == null)
            {
                return new GetResponse<GetBooksModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetBooksModel response = await _mapper.CreateMap<GetBooksModel, Books>(books);
            return new GetResponse<GetBooksModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<BooksModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iBooksRepository.GetAll();
            List<Books> books = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Books>(row))
                .ToList();
            BooksModelCollection collection = await _mapper.CreateMap<
                BooksModelCollection,
                List<Books>
            >(books);
            return new CollectionResponse<BooksModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<BooksModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iBooksRepository.GetFilter(pagination);
            List<Books> books = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Books>(row))
                .ToList();
            BooksModelCollection collection = await _mapper.CreateMap<
                BooksModelCollection,
                List<Books>
            >(books);
            return collection;
        }

        public async Task<Response> Insert(BooksModel booksModel)
        {
            Books books = await _mapper.CreateMap<Books, BooksModel>(booksModel);
            bool success = await _iBooksRepository.Insert(books);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Books inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Books inserted failed.",
            };
        }

        public async Task<string> Update(BooksModel booksModel)
        {
            Books books = await _mapper.CreateMap<Books, BooksModel>(booksModel);
            bool success = await _iBooksRepository.Update(books);
            if (success)
                return "Books updated successfully.";
            else
                return "Books update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iBooksRepository.Delete(id);
                if (deleted)
                    return "Books deleted successfully.";
                else
                    return "Books not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> SetActiveStatus(long id)
        {
            try
            {
                bool success = await _iBooksRepository.SetActiveStatus(id);
                if (success)
                    return "Books status updated to active.";
                else
                    return "Books not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> SetInActiveStatus(long id)
        {
            try
            {
                bool success = await _iBooksRepository.SetInActiveStatus(id);
                if (success)
                    return "Books status updated to inactive.";
                else
                    return "Books not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
