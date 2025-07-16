using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class MenuService : IMenuService
    {
        private readonly ILogger<MenuService> _logger;
        private readonly IMapping _mapper;
        private readonly IMenuRepository _iMenuRepository;

        public MenuService(
            ILogger<MenuService> logger,
            IMapping mapper,
            IMenuRepository iMenuRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iMenuRepository = iMenuRepository;
        }

        public async Task<GetResponse<GetMenuModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iMenuRepository.GetById(id);
            Menu? menu = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Menu>(row))
                .FirstOrDefault();
            if (menu == null)
            {
                return new GetResponse<GetMenuModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetMenuModel response = await _mapper.CreateMap<GetMenuModel, Menu>(menu);
            return new GetResponse<GetMenuModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<MenuModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iMenuRepository.GetAll();
            List<Menu> menu = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Menu>(row))
                .ToList();
            MenuModelCollection collection = await _mapper.CreateMap<
                MenuModelCollection,
                List<Menu>
            >(menu);
            return new CollectionResponse<MenuModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<MenuModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iMenuRepository.GetFilter(pagination);
            List<Menu> menu = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Menu>(row))
                .ToList();
            MenuModelCollection collection = await _mapper.CreateMap<
                MenuModelCollection,
                List<Menu>
            >(menu);
            return collection;
        }

        public async Task<Response> Insert(MenuModel menuModel)
        {
            Menu menu = await _mapper.CreateMap<Menu, MenuModel>(menuModel);
            bool success = await _iMenuRepository.Insert(menu);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Menu inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Menu inserted failed.",
            };
        }

        public async Task<string> Update(MenuModel menuModel)
        {
            Menu menu = await _mapper.CreateMap<Menu, MenuModel>(menuModel);
            bool success = await _iMenuRepository.Update(menu);
            if (success)
                return "Menu updated successfully.";
            else
                return "Menu update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iMenuRepository.Delete(id);
                if (deleted)
                    return "Menu deleted successfully.";
                else
                    return "Menu not found.";
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
                bool success = await _iMenuRepository.SetActiveStatus(id);
                if (success)
                    return "Menu status updated to active.";
                else
                    return "Menu not found.";
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
                bool success = await _iMenuRepository.SetInActiveStatus(id);
                if (success)
                    return "Menu status updated to inactive.";
                else
                    return "Menu not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
