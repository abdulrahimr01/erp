using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class DefaultPageService : IDefaultPageService
    {
        private readonly ILogger<DefaultPageService> _logger;
        private readonly IMapping _mapper;
        private readonly IDefaultPageRepository _iDefaultPageRepository;

        public DefaultPageService(
            ILogger<DefaultPageService> logger,
            IMapping mapper,
            IDefaultPageRepository iDefaultPageRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iDefaultPageRepository = iDefaultPageRepository;
        }

        public async Task<GetResponse<GetDefaultPageModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iDefaultPageRepository.GetById(id);
            DefaultPage? defaultPage = result
                .Select(static row => DataMapperExtensions.MapRowToModel<DefaultPage>(row))
                .FirstOrDefault();
            if (defaultPage == null)
            {
                return new GetResponse<GetDefaultPageModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetDefaultPageModel response = await _mapper.CreateMap<GetDefaultPageModel, DefaultPage>(defaultPage);
            return new GetResponse<GetDefaultPageModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<DefaultPageModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iDefaultPageRepository.GetAll();
            List<DefaultPage> defaultPage = result
                .Select(static row => DataMapperExtensions.MapRowToModel<DefaultPage>(row))
                .ToList();
            DefaultPageModelCollection collection = await _mapper.CreateMap<
                DefaultPageModelCollection,
                List<DefaultPage>
            >(defaultPage);
            return new CollectionResponse<DefaultPageModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<DefaultPageModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iDefaultPageRepository.GetFilter(pagination);
            List<DefaultPage> defaultPage = result
                .Select(static row => DataMapperExtensions.MapRowToModel<DefaultPage>(row))
                .ToList();
            DefaultPageModelCollection collection = await _mapper.CreateMap<
                DefaultPageModelCollection,
                List<DefaultPage>
            >(defaultPage);
            return collection;
        }

        public async Task<Response> Insert(DefaultPageModel defaultPageModel)
        {
            DefaultPage defaultPage = await _mapper.CreateMap<DefaultPage, DefaultPageModel>(defaultPageModel);
            bool success = await _iDefaultPageRepository.Insert(defaultPage);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "DefaultPage inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "DefaultPage inserted failed.",
            };
        }

        public async Task<Response> Update(DefaultPageModel defaultPageModel)
        {
            DefaultPage defaultPage = await _mapper.CreateMap<DefaultPage, DefaultPageModel>(defaultPageModel);
            bool success = await _iDefaultPageRepository.Update(defaultPage);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "DefaultPage updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "DefaultPage update failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iDefaultPageRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "DefaultPage deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "DefaultPage not found.",
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
                bool success = await _iDefaultPageRepository.SetActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "DefaultPage status updated to active",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "DefaultPage entry not found",
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
                bool success = await _iDefaultPageRepository.SetInActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "DefaultPage status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "DefaultPage entry not found",
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
