using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class EditorialsService : IEditorialsService
    {
        private readonly ILogger<EditorialsService> _logger;
        private readonly IMapping _mapper;
        private readonly IEditorialsRepository _iEditorialsRepository;

        public EditorialsService(
            ILogger<EditorialsService> logger,
            IMapping mapper,
            IEditorialsRepository iEditorialsRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iEditorialsRepository = iEditorialsRepository;
        }

        public async Task<GetResponse<GetEditorialsModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iEditorialsRepository.GetById(id);
            Editorials? editorials = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Editorials>(row))
                .FirstOrDefault();
            if (editorials == null)
            {
                return new GetResponse<GetEditorialsModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetEditorialsModel response = await _mapper.CreateMap<GetEditorialsModel, Editorials>(editorials);
            return new GetResponse<GetEditorialsModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<EditorialsModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iEditorialsRepository.GetAll();
            List<Editorials> editorials = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Editorials>(row))
                .ToList();
            EditorialsModelCollection collection = await _mapper.CreateMap<
                EditorialsModelCollection,
                List<Editorials>
            >(editorials);
            return new CollectionResponse<EditorialsModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<EditorialsModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iEditorialsRepository.GetFilter(pagination);
            List<Editorials> editorials = result
                .Select(static row => DataMapperExtensions.MapRowToModel<Editorials>(row))
                .ToList();
            EditorialsModelCollection collection = await _mapper.CreateMap<
                EditorialsModelCollection,
                List<Editorials>
            >(editorials);
            return collection;
        }

        public async Task<Response> Insert(EditorialsModel editorialsModel)
        {
            Editorials editorials = await _mapper.CreateMap<Editorials, EditorialsModel>(editorialsModel);
            bool success = await _iEditorialsRepository.Insert(editorials);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Editorials inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Editorials inserted failed.",
            };
        }

        public async Task<Response> Update(EditorialsModel editorialsModel)
        {
            Editorials editorials = await _mapper.CreateMap<Editorials, EditorialsModel>(editorialsModel);
            bool success = await _iEditorialsRepository.Update(editorials);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "Editorials updated successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "Editorials updated failed.",
            };
        }

        public async Task<Response> Delete(long id)
        {
            try
            {
                bool deleted = await _iEditorialsRepository.Delete(id);
                if (deleted)
                {
                    return new Response()
                    {
                        Code = 200,
                        Success = true,
                        Message = "Editorials deleted successfully.",
                    };
                }
                return new Response()
                {
                    Code = 200,
                    Success = false,
                    Message = "Editorials not found.",
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
                bool result = await _iEditorialsRepository.SetActiveStatus(id);

                if (result)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Editorials status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Editorials entry not found",
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
                bool result = await _iEditorialsRepository.SetInActiveStatus(id);

                if (result)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Editorials status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Editorials entry not found",
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
