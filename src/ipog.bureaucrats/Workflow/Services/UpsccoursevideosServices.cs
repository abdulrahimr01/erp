using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class UpsccoursevideosService : IUpsccoursevideosService
    {
        private readonly ILogger<UpsccoursevideosService> _logger;
        private readonly IMapping _mapper;
        private readonly IUpsccoursevideosRepository _iUpsccoursevideosRepository;

        public UpsccoursevideosService(
            ILogger<UpsccoursevideosService> logger,
            IMapping mapper,
            IUpsccoursevideosRepository iUpsccoursevideosRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iUpsccoursevideosRepository = iUpsccoursevideosRepository;
        }

        public async Task<GetResponse<GetUpsccoursevideosModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iUpsccoursevideosRepository.GetById(
                id
            );
            Upsccoursevideos? upsccoursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Upsccoursevideos>(row))
                .FirstOrDefault();
            if (upsccoursevideos == null)
            {
                return new GetResponse<GetUpsccoursevideosModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetUpsccoursevideosModel response = await _mapper.CreateMap<
                GetUpsccoursevideosModel,
                Upsccoursevideos
            >(upsccoursevideos);
            return new GetResponse<GetUpsccoursevideosModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<UpsccoursevideosModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iUpsccoursevideosRepository.GetAll();
            List<Upsccoursevideos> upsccoursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Upsccoursevideos>(row))
                .ToList();
            UpsccoursevideosModelCollection collection = await _mapper.CreateMap<
                UpsccoursevideosModelCollection,
                List<Upsccoursevideos>
            >(upsccoursevideos);
            return new CollectionResponse<UpsccoursevideosModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<UpsccoursevideosModelCollection> GetFilter(
            PaginationModel paginationModel
        )
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iUpsccoursevideosRepository.GetFilter(
                pagination
            );
            List<Upsccoursevideos> upsccoursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Upsccoursevideos>(row))
                .ToList();
            UpsccoursevideosModelCollection collection = await _mapper.CreateMap<
                UpsccoursevideosModelCollection,
                List<Upsccoursevideos>
            >(upsccoursevideos);
            return collection;
        }

        public async Task<Response> Insert(UpsccoursevideosModel upsccoursevideosModel)
        {
            Upsccoursevideos upsccoursevideos = await _mapper.CreateMap<
                Upsccoursevideos,
                UpsccoursevideosModel
            >(upsccoursevideosModel);
            bool success = await _iUpsccoursevideosRepository.Insert(upsccoursevideos);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Upsccoursevideos inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Upsccoursevideos inserted failed.",
            };
        }

        public async Task<string> Update(UpsccoursevideosModel upsccoursevideosModel)
        {
            Upsccoursevideos upsccoursevideos = await _mapper.CreateMap<
                Upsccoursevideos,
                UpsccoursevideosModel
            >(upsccoursevideosModel);
            bool success = await _iUpsccoursevideosRepository.Update(upsccoursevideos);
            if (success)
                return "Upsccoursevideos updated successfully.";
            else
                return "Upsccoursevideos update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iUpsccoursevideosRepository.Delete(id);
                if (deleted)
                    return "Upsccoursevideos deleted successfully.";
                else
                    return "Upsccoursevideos not found.";
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
                bool success = await _iUpsccoursevideosRepository.SetActiveStatus(id);
                if (success)
                    return "Upsccoursevideos status updated to active.";
                else
                    return "Upsccoursevideos not found.";
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
                bool success = await _iUpsccoursevideosRepository.SetInActiveStatus(id);
                if (success)
                    return "Upsccoursevideos status updated to inactive.";
                else
                    return "Upsccoursevideos not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
