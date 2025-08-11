using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ipog.bureaucrats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _iWishlistService;

        public WishlistController(IWishlistService iWishlistService)
        {
            _iWishlistService = iWishlistService;
        }

        // GET: Get Wishlist
        [HttpGet]
        public async Task<IActionResult> GetById(long id)
        {
            GetResponse<GetWishlistModel> response = await _iWishlistService.GetById(id);
            return Ok(response);
        }

        // GET: Get All Wishlist
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            CollectionResponse<WishlistModelCollection> collection =
                await _iWishlistService.GetAll();
            return Ok(collection);
        }

        // POST: Filter Wishlist
        [HttpPost("Filter")]
        public async Task<IActionResult> GetFilter([FromBody] PaginationModel paginationModel)
        {
            WishlistModelCollection collection = await _iWishlistService.GetFilter(paginationModel);
            return Ok(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] WishlistModel wishlistModel)
        {
            Response response = await _iWishlistService.Insert(wishlistModel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WishlistModel wishlistModel)
        {
            Response response = await _iWishlistService.Update(wishlistModel);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Response response = await _iWishlistService.Delete(id);
            return Ok(response);
        }

        [HttpPatch("active")]
        public async Task<IActionResult> SetActiveStatus(long id)
        {
            Response response = await _iWishlistService.SetActiveStatus(id);
            return Ok(response);
        }

        [HttpPatch("inactive")]
        public async Task<IActionResult> SetInActiveStatus(long id)
        {
            Response response = await _iWishlistService.SetInActiveStatus(id);
            return Ok(response);
        }
    }
}
