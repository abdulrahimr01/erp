using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class UpscaboutService : IUpscaboutService
    {
        private readonly ILogger<UpscaboutService> _logger;
        private readonly IMapping _mapper;
        private readonly IUpscaboutRepository _iUpscaboutRepository;

        public UpscaboutService(
            ILogger<UpscaboutService> logger,
            IMapping mapper,
            IUpscaboutRepository iUpscaboutRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iUpscaboutRepository = iUpscaboutRepository;
        }

        public async Task<GetResponse<GetUpscaboutModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iUpscaboutRepository.GetById(id);
            Upscabout? upscabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Upscabout>(row))
                .FirstOrDefault();
            if (upscabout == null)
            {
                return new GetResponse<GetUpscaboutModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetUpscaboutModel response = await _mapper.CreateMap<GetUpscaboutModel, Upscabout>(
                upscabout
            );
            return new GetResponse<GetUpscaboutModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<UpscaboutModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iUpscaboutRepository.GetAll();
            List<Upscabout> upscabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Upscabout>(row))
                .ToList();
            UpscaboutModelCollection collection = await _mapper.CreateMap<
                UpscaboutModelCollection,
                List<Upscabout>
            >(upscabout);
            return new CollectionResponse<UpscaboutModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<UpscaboutModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iUpscaboutRepository.GetFilter(
                pagination
            );
            List<Upscabout> upscabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Upscabout>(row))
                .ToList();
            UpscaboutModelCollection collection = await _mapper.CreateMap<
                UpscaboutModelCollection,
                List<Upscabout>
            >(upscabout);
            return collection;
        }

        public async Task<Response> Insert(UpscaboutModel upscaboutModel)
        {
            Upscabout upscabout = await _mapper.CreateMap<Upscabout, UpscaboutModel>(
                upscaboutModel
            );
            bool success = await _iUpscaboutRepository.Insert(upscabout);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Upscabout inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Upscabout inserted failed.",
            };
        }

        public async Task<Response> Update(UpscaboutModel upscaboutModel)
        {
            Upscabout upscabout = await _mapper.CreateMap<Upscabout, UpscaboutModel>(
                upscaboutModel
            );
            bool success = await _iUpscaboutRepository.Update(upscabout);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Upscabout updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Upscabout updated failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iUpscaboutRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "Upscabout deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "Upscabout not found.",
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
                bool success = await _iUpscaboutRepository.SetActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Upscabout status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Upscabout entry not found",
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
                bool success = await _iUpscaboutRepository.SetInActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Upscabout status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Upscabout entry not found",
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
