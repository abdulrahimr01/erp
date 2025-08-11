using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class CoursevideosService : ICoursevideosService
    {
        private readonly ILogger<CoursevideosService> _logger;
        private readonly IMapping _mapper;
        private readonly ICoursevideosRepository _iCoursevideosRepository;

        public CoursevideosService(
            ILogger<CoursevideosService> logger,
            IMapping mapper,
            ICoursevideosRepository iCoursevideosRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iCoursevideosRepository = iCoursevideosRepository;
        }

        public async Task<GetResponse<GetCoursevideosModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iCoursevideosRepository.GetById(id);
            Coursevideos? coursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Coursevideos>(row))
                .FirstOrDefault();
            if (coursevideos == null)
            {
                return new GetResponse<GetCoursevideosModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetCoursevideosModel response = await _mapper.CreateMap<
                GetCoursevideosModel,
                Coursevideos
            >(coursevideos);
            return new GetResponse<GetCoursevideosModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<CoursevideosModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iCoursevideosRepository.GetAll();
            List<Coursevideos> coursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Coursevideos>(row))
                .ToList();
            CoursevideosModelCollection collection = await _mapper.CreateMap<
                CoursevideosModelCollection,
                List<Coursevideos>
            >(coursevideos);
            return new CollectionResponse<CoursevideosModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<CoursevideosModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iCoursevideosRepository.GetFilter(
                pagination
            );
            List<Coursevideos> coursevideos = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Coursevideos>(row))
                .ToList();
            CoursevideosModelCollection collection = await _mapper.CreateMap<
                CoursevideosModelCollection,
                List<Coursevideos>
            >(coursevideos);
            return collection;
        }

        public async Task<Response> Insert(CoursevideosModel coursevideosModel)
        {
            Coursevideos coursevideos = await _mapper.CreateMap<Coursevideos, CoursevideosModel>(
                coursevideosModel
            );
            bool success = await _iCoursevideosRepository.Insert(coursevideos);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Coursevideos inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Coursevideos inserted failed.",
            };
        }

        public async Task<Response> Update(CoursevideosModel coursevideosModel)
        {
            Coursevideos coursevideos = await _mapper.CreateMap<Coursevideos, CoursevideosModel>(
                coursevideosModel
            );
            bool success = await _iCoursevideosRepository.Update(coursevideos);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Coursevideos updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Coursevideos updated failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iCoursevideosRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "Coursevideos deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "Coursevideos not found.",
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
                bool success = await _iCoursevideosRepository.SetActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Coursevideos status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Coursevideos entry not found",
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
                bool success = await _iCoursevideosRepository.SetInActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Coursevideos status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Coursevideos entry not found",
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
