using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class PapersService : IPapersService
    {
        private readonly ILogger<PapersService> _logger;
        private readonly IMapping _mapper;
        private readonly IPapersRepository _iPapersRepository;

        public PapersService(
            ILogger<PapersService> logger,
            IMapping mapper,
            IPapersRepository iPapersRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iPapersRepository = iPapersRepository;
        }

        public async Task<GetResponse<GetPapersModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iPapersRepository.GetById(id);
            Papers? papers = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Papers>(row))
                .FirstOrDefault();
            if (papers == null)
            {
                return new GetResponse<GetPapersModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetPapersModel response = await _mapper.CreateMap<GetPapersModel, Papers>(papers);
            return new GetResponse<GetPapersModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<PapersModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iPapersRepository.GetAll();
            List<Papers> papers = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Papers>(row))
                .ToList();
            PapersModelCollection collection = await _mapper.CreateMap<
                PapersModelCollection,
                List<Papers>
            >(papers);
            return new CollectionResponse<PapersModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<PapersModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iPapersRepository.GetFilter(
                pagination
            );
            List<Papers> papers = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Papers>(row))
                .ToList();
            PapersModelCollection collection = await _mapper.CreateMap<
                PapersModelCollection,
                List<Papers>
            >(papers);
            return collection;
        }

        public async Task<Response> Insert(PapersModel papersModel)
        {
            Papers papers = await _mapper.CreateMap<Papers, PapersModel>(papersModel);
            bool success = await _iPapersRepository.Insert(papers);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Papers inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Papers inserted failed.",
            };
        }

        public async Task<string> Update(PapersModel papersModel)
        {
            Papers papers = await _mapper.CreateMap<Papers, PapersModel>(papersModel);
            bool success = await _iPapersRepository.Update(papers);
            if (success)
                return "Papers updated successfully.";
            else
                return "Papers update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iPapersRepository.Delete(id);
                if (deleted)
                    return "Papers deleted successfully.";
                else
                    return "Papers not found.";
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
                bool success = await _iPapersRepository.SetActiveStatus(id);
                if (success)
                    return "Papers status updated to active.";
                else
                    return "Papers not found.";
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
                bool success = await _iPapersRepository.SetInActiveStatus(id);
                if (success)
                    return "Papers status updated to inactive.";
                else
                    return "Papers not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
