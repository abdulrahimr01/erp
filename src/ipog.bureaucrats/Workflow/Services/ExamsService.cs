using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class ExamsService : IExamsService
    {
        private readonly ILogger<ExamsService> _logger;
        private readonly IMapping _mapper;
        private readonly IExamsRepository _iExamsRepository;

        public ExamsService(
            ILogger<ExamsService> logger,
            IMapping mapper,
            IExamsRepository iExamsRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iExamsRepository = iExamsRepository;
        }

        public async Task<GetResponse<GetExamsModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iExamsRepository.GetById(id);
            Exams? exams = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Exams>(row))
                .FirstOrDefault();
            if (exams == null)
            {
                return new GetResponse<GetExamsModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetExamsModel response = await _mapper.CreateMap<GetExamsModel, Exams>(exams);
            return new GetResponse<GetExamsModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<ExamsModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iExamsRepository.GetAll();
            List<Exams> exams = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Exams>(row))
                .ToList();
            ExamsModelCollection collection = await _mapper.CreateMap<
                ExamsModelCollection,
                List<Exams>
            >(exams);
            return new CollectionResponse<ExamsModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<ExamsModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iExamsRepository.GetFilter(pagination);
            List<Exams> exams = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Exams>(row))
                .ToList();
            ExamsModelCollection collection = await _mapper.CreateMap<
                ExamsModelCollection,
                List<Exams>
            >(exams);
            return collection;
        }

        public async Task<Response> Insert(ExamsModel examsModel)
        {
            Exams exams = await _mapper.CreateMap<Exams, ExamsModel>(examsModel);
            bool success = await _iExamsRepository.Insert(exams);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Exams inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Exams inserted failed.",
            };
        }

        public async Task<string> Update(ExamsModel examsModel)
        {
            Exams exams = await _mapper.CreateMap<Exams, ExamsModel>(examsModel);
            bool success = await _iExamsRepository.Update(exams);
            if (success)
                return "Exams updated successfully.";
            else
                return "Exams update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iExamsRepository.Delete(id);
                if (deleted)
                    return "Exams deleted successfully.";
                else
                    return "Exams not found.";
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
                bool success = await _iExamsRepository.SetActiveStatus(id);
                if (success)
                    return "Exams status updated to active.";
                else
                    return "Exams not found.";
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
                bool success = await _iExamsRepository.SetInActiveStatus(id);
                if (success)
                    return "Exams status updated to inactive.";
                else
                    return "Exams not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
