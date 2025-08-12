using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class AboutService : IAboutService
    {
        private readonly ILogger<AboutService> _logger;
        private readonly IMapping _mapper;
        private readonly IAboutRepository _iAboutRepository;

        public AboutService(
            ILogger<AboutService> logger,
            IMapping mapper,
            IAboutRepository iAboutRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iAboutRepository = iAboutRepository;
        }

        public async Task<GetResponse<GetAboutModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iAboutRepository.GetById(id);
            About? about = result
                .Select(static row => DataMapperExtensions.MapRowToModel<About>(row))
                .FirstOrDefault();
            if (about == null)
            {
                return new GetResponse<GetAboutModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetAboutModel response = await _mapper.CreateMap<GetAboutModel, About>(about);
            return new GetResponse<GetAboutModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<AboutModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iAboutRepository.GetAll();
            List<About> about = result
                .Select(static row => DataMapperExtensions.MapRowToModel<About>(row))
                .ToList();
            AboutModelCollection collection = await _mapper.CreateMap<
                AboutModelCollection,
                List<About>
            >(about);
            return new CollectionResponse<AboutModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<AboutModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iAboutRepository.GetFilter(pagination);
            List<About> about = result
                .Select(static row => DataMapperExtensions.MapRowToModel<About>(row))
                .ToList();
            AboutModelCollection collection = await _mapper.CreateMap<
                AboutModelCollection,
                List<About>
            >(about);
            return collection;
        }

        public async Task<Response> Insert(AboutModel aboutModel)
        {
            About about = await _mapper.CreateMap<About, AboutModel>(aboutModel);
            bool success = await _iAboutRepository.Insert(about);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "About inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "About inserted failed.",
            };
        }

        public async Task<Response> Update(AboutModel aboutModel)
        {
            About about = await _mapper.CreateMap<About, AboutModel>(aboutModel);
            bool success = await _iAboutRepository.Update(about);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "About updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "About updated failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iAboutRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "About deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "About not found.",
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
                bool success = await _iAboutRepository.SetActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "About status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "About entry not found",
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
                bool success = await _iAboutRepository.SetInActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "About status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "About entry not found",
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
