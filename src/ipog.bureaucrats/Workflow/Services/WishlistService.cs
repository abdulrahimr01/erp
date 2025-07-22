using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly ILogger<WishlistService> _logger;
        private readonly IMapping _mapper;
        private readonly IWishlistRepository _iWishlistRepository;

        public WishlistService(
            ILogger<WishlistService> logger,
            IMapping mapper,
            IWishlistRepository iWishlistRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iWishlistRepository = iWishlistRepository;
        }

        public async Task<GetResponse<GetWishlistModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iWishlistRepository.GetById(id);
            Wishlist? wishlist = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Wishlist>(row))
                .FirstOrDefault();
            if (wishlist == null)
            {
                return new GetResponse<GetWishlistModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetWishlistModel response = await _mapper.CreateMap<GetWishlistModel, Wishlist>(
                wishlist
            );
            return new GetResponse<GetWishlistModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<WishlistModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iWishlistRepository.GetAll();
            List<Wishlist> wishlist = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Wishlist>(row))
                .ToList();
            WishlistModelCollection collection = await _mapper.CreateMap<
                WishlistModelCollection,
                List<Wishlist>
            >(wishlist);
            return new CollectionResponse<WishlistModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<WishlistModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iWishlistRepository.GetFilter(
                pagination
            );
            List<Wishlist> wishlist = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Wishlist>(row))
                .ToList();
            WishlistModelCollection collection = await _mapper.CreateMap<
                WishlistModelCollection,
                List<Wishlist>
            >(wishlist);
            return collection;
        }

        public async Task<Response> Insert(WishlistModel wishlistModel)
        {
            Wishlist wishlist = await _mapper.CreateMap<Wishlist, WishlistModel>(wishlistModel);
            bool success = await _iWishlistRepository.Insert(wishlist);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Wishlist inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Wishlist inserted failed.",
            };
        }

        public async Task<string> Update(WishlistModel wishlistModel)
        {
            Wishlist wishlist = await _mapper.CreateMap<Wishlist, WishlistModel>(wishlistModel);
            bool success = await _iWishlistRepository.Update(wishlist);
            if (success)
                return "Wishlist updated successfully.";
            else
                return "Wishlist update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iWishlistRepository.Delete(id);
                if (deleted)
                    return "Wishlist deleted successfully.";
                else
                    return "Wishlist not found.";
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
                bool success = await _iWishlistRepository.SetActiveStatus(id);
                if (success)
                    return "Wishlist status updated to active.";
                else
                    return "Wishlist not found.";
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
                bool success = await _iWishlistRepository.SetInActiveStatus(id);
                if (success)
                    return "Wishlist status updated to inactive.";
                else
                    return "Wishlist not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
