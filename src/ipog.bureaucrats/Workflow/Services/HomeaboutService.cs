using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class HomeaboutService : IHomeaboutService
    {
        private readonly ILogger<HomeaboutService> _logger;
        private readonly IMapping _mapper;
        private readonly IHomeaboutRepository _iHomeaboutRepository;

        public HomeaboutService(
            ILogger<HomeaboutService> logger,
            IMapping mapper,
            IHomeaboutRepository iHomeaboutRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iHomeaboutRepository = iHomeaboutRepository;
        }

        public async Task<GetResponse<GetHomeaboutModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iHomeaboutRepository.GetById(id);
            Homeabout? homeabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Homeabout>(row))
                .FirstOrDefault();
            if (homeabout == null)
            {
                return new GetResponse<GetHomeaboutModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetHomeaboutModel response = await _mapper.CreateMap<GetHomeaboutModel, Homeabout>(
                homeabout
            );
            return new GetResponse<GetHomeaboutModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<HomeaboutModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iHomeaboutRepository.GetAll();
            List<Homeabout> homeabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Homeabout>(row))
                .ToList();
            HomeaboutModelCollection collection = await _mapper.CreateMap<
                HomeaboutModelCollection,
                List<Homeabout>
            >(homeabout);
            return new CollectionResponse<HomeaboutModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<HomeaboutModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iHomeaboutRepository.GetFilter(
                pagination
            );
            List<Homeabout> homeabout = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Homeabout>(row))
                .ToList();
            HomeaboutModelCollection collection = await _mapper.CreateMap<
                HomeaboutModelCollection,
                List<Homeabout>
            >(homeabout);
            return collection;
        }

        public async Task<Response> Insert(HomeaboutModel homeaboutModel)
        {
            Homeabout homeabout = await _mapper.CreateMap<Homeabout, HomeaboutModel>(
                homeaboutModel
            );
            bool success = await _iHomeaboutRepository.Insert(homeabout);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Homeabout inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Homeabout inserted failed.",
            };
        }

        public async Task<Response> Update(HomeaboutModel homeaboutModel)
        {
            Homeabout homeabout = await _mapper.CreateMap<Homeabout, HomeaboutModel>(
                homeaboutModel
            );
            bool success = await _iHomeaboutRepository.Update(homeabout);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Homeabout updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Homeabout updated failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iHomeaboutRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "Homeabout deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "Homeabout not found.",
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
                bool success = await _iHomeaboutRepository.SetActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Homeabout status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Homeabout entry not found",
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
                bool success = await _iHomeaboutRepository.SetInActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Homeabout status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Homeabout entry not found",
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
