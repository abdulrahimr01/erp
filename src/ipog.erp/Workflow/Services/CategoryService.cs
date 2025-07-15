using ipog.erp.DataSource.IRepository;
using ipog.erp.Entity;
using ipog.erp.Extension;
using ipog.erp.Mapping;
using ipog.erp.Models;
using ipog.erp.Workflow.IServices;

namespace ipog.erp.Workflow.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly IMapping _mapper;
        private readonly ICategoryRepository _iCategoryRepository;

        public CategoryService(
            ILogger<CategoryService> logger,
            IMapping mapper,
            ICategoryRepository iCategoryRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iCategoryRepository = iCategoryRepository;
        }

        public async Task<GetResponse<GetCategoryModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iCategoryRepository.GetById(id);
            Category? categorys = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Category>(row))
                .FirstOrDefault();
            if (categorys == null)
            {
                return new GetResponse<GetCategoryModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetCategoryModel response = await _mapper.CreateMap<GetCategoryModel, Category>(
                categorys
            );
            return new GetResponse<GetCategoryModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<CategoryModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iCategoryRepository.GetAll();
            List<Category> category = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Category>(row))
                .ToList();
            CategoryModelCollection collection = await _mapper.CreateMap<
                CategoryModelCollection,
                List<Category>
            >(category);
            return new CollectionResponse<CategoryModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<CategoryModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iCategoryRepository.GetFilter(
                pagination
            );
            List<Category> categorys = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Category>(row))
                .ToList();
            CategoryModelCollection collection = await _mapper.CreateMap<
                CategoryModelCollection,
                List<Category>
            >(categorys);
            return collection;
        }

        public async Task<Response> Insert(CategoryModel categoryModel)
        {
            Category category = await _mapper.CreateMap<Category, CategoryModel>(categoryModel);
            bool success = await _iCategoryRepository.Insert(category);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Category inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Category inserted failed.",
            };
        }

        public async Task<string> Update(CategoryModel categoryModel)
        {
            Category category = await _mapper.CreateMap<Category, CategoryModel>(categoryModel);
            bool success = await _iCategoryRepository.Update(category);
            if (success)
                return "Category updated successfully.";
            else
                return "Category update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iCategoryRepository.Delete(id);
                if (deleted)
                    return "Category deleted successfully.";
                else
                    return "Category not found.";
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
                bool success = await _iCategoryRepository.SetActiveStatus(id);
                if (success)
                    return "Category status updated to active.";
                else
                    return "Category not found.";
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
                bool success = await _iCategoryRepository.SetInActiveStatus(id);
                if (success)
                    return "Category status updated to inactive.";
                else
                    return "Category not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
