using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class TnpsccoursevideosService : ITnpsccoursevideosService
    {
        private readonly ILogger<TnpsccoursevideosService> _logger;
        private readonly IMapping _mapper;
        private readonly ITnpsccoursevideosRepository _iTnpsccoursevideosRepository;

        public TnpsccoursevideosService(
            ILogger<TnpsccoursevideosService> logger,
            IMapping mapper,
            ITnpsccoursevideosRepository iTnpsccoursevideosRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iTnpsccoursevideosRepository = iTnpsccoursevideosRepository;
        }

        public async Task<GetResponse<GetTnpsccoursevideosModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iTnpsccoursevideosRepository.GetById(
                id
            );
            Tnpsccoursevideos? tnpsccoursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Tnpsccoursevideos>(row))
                .FirstOrDefault();
            if (tnpsccoursevideos == null)
            {
                return new GetResponse<GetTnpsccoursevideosModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetTnpsccoursevideosModel response = await _mapper.CreateMap<
                GetTnpsccoursevideosModel,
                Tnpsccoursevideos
            >(tnpsccoursevideos);
            return new GetResponse<GetTnpsccoursevideosModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<TnpsccoursevideosModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iTnpsccoursevideosRepository.GetAll();
            List<Tnpsccoursevideos> tnpsccoursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Tnpsccoursevideos>(row))
                .ToList();
            TnpsccoursevideosModelCollection collection = await _mapper.CreateMap<
                TnpsccoursevideosModelCollection,
                List<Tnpsccoursevideos>
            >(tnpsccoursevideos);
            return new CollectionResponse<TnpsccoursevideosModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<TnpsccoursevideosModelCollection> GetFilter(
            PaginationModel paginationModel
        )
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iTnpsccoursevideosRepository.GetFilter(
                pagination
            );
            List<Tnpsccoursevideos> tnpsccoursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Tnpsccoursevideos>(row))
                .ToList();
            TnpsccoursevideosModelCollection collection = await _mapper.CreateMap<
                TnpsccoursevideosModelCollection,
                List<Tnpsccoursevideos>
            >(tnpsccoursevideos);
            return collection;
        }

        public async Task<Response> Insert(TnpsccoursevideosModel tnpsccoursevideosModel)
        {
            Tnpsccoursevideos tnpsccoursevideos = await _mapper.CreateMap<
                Tnpsccoursevideos,
                TnpsccoursevideosModel
            >(tnpsccoursevideosModel);
            bool success = await _iTnpsccoursevideosRepository.Insert(tnpsccoursevideos);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Tnpsccoursevideos inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Tnpsccoursevideos inserted failed.",
            };
        }

        public async Task<Response> Update(TnpsccoursevideosModel tnpsccoursevideosModel)
        {
            Tnpsccoursevideos tnpsccoursevideos = await _mapper.CreateMap<
                Tnpsccoursevideos,
                TnpsccoursevideosModel
            >(tnpsccoursevideosModel);
            bool success = await _iTnpsccoursevideosRepository.Update(tnpsccoursevideos);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Tnpsccoursevideos updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Tnpsccoursevideos update failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iTnpsccoursevideosRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "Tnpsccoursevideos deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "Tnpsccoursevideos not found.",
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Code = 500,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<Response> SetActiveStatus(long id)
        {
            try
            {
                bool success = await _iTnpsccoursevideosRepository.SetActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Tnpsccoursevideos status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Tnpsccoursevideos entry not found",
                        Success = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Code = 500,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<Response> SetInActiveStatus(long id)
        {
            try
            {
                bool success = await _iTnpsccoursevideosRepository.SetInActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Tnpsccoursevideos status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Tnpsccoursevideos entry not found",
                        Success = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Code = 500,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}
