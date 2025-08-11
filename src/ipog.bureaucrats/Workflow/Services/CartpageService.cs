using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class CartpageService : ICartpageService
    {
        private readonly ILogger<CartpageService> _logger;
        private readonly IMapping _mapper;
        private readonly ICartpageRepository _iCartpageRepository;

        public CartpageService(
            ILogger<CartpageService> logger,
            IMapping mapper,
            ICartpageRepository iCartpageRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iCartpageRepository = iCartpageRepository;
        }

        public async Task<GetResponse<GetCartpageModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iCartpageRepository.GetById(id);
            Cartpage? cartpage = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Cartpage>(row))
                .FirstOrDefault();
            if (cartpage == null)
            {
                return new GetResponse<GetCartpageModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetCartpageModel response = await _mapper.CreateMap<GetCartpageModel, Cartpage>(
                cartpage
            );
            return new GetResponse<GetCartpageModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<CartpageModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iCartpageRepository.GetAll();
            List<Cartpage> cartpage = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Cartpage>(row))
                .ToList();
            CartpageModelCollection collection = await _mapper.CreateMap<
                CartpageModelCollection,
                List<Cartpage>
            >(cartpage);
            return new CollectionResponse<CartpageModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<CartpageModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iCartpageRepository.GetFilter(
                pagination
            );
            List<Cartpage> cartpage = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Cartpage>(row))
                .ToList();
            CartpageModelCollection collection = await _mapper.CreateMap<
                CartpageModelCollection,
                List<Cartpage>
            >(cartpage);
            return collection;
        }

        public async Task<Response> Insert(CartpageModel cartpageModel)
        {
            Cartpage cartpage = await _mapper.CreateMap<Cartpage, CartpageModel>(cartpageModel);
            bool success = await _iCartpageRepository.Insert(cartpage);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Cartpage inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Cartpage inserted failed.",
            };
        }

        public async Task<Response> Update(CartpageModel cartpageModel)
        {
            Cartpage cartpage = await _mapper.CreateMap<Cartpage, CartpageModel>(cartpageModel);
            bool success = await _iCartpageRepository.Update(cartpage);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Cartpage updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Cartpage updated failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iCartpageRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "Cartpage deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "Cartpage not found.",
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
                bool success = await _iCartpageRepository.SetActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Cartpage status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Cartpage entry not found",
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
                bool success = await _iCartpageRepository.SetInActiveStatus(id);
                if (success)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Cartpage status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Cartpage entry not found",
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
