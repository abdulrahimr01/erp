using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Entity;
using ipog.bureaucrats.Extension;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Models;
using ipog.bureaucrats.Workflow.IServices;

namespace ipog.bureaucrats.Workflow.Services
{
    public class CurrentAffairsService : ICurrentAffairsService
    {
        private readonly ILogger<CurrentAffairsService> _logger;
        private readonly IMapping _mapper;
        private readonly ICurrentAffairsRepository _iCurrentAffairsRepository;

        public CurrentAffairsService(
            ILogger<CurrentAffairsService> logger,
            IMapping mapper,
            ICurrentAffairsRepository iCurrentAffairsRepository
        )
        {
            _logger = logger;
            _mapper = mapper;
            _iCurrentAffairsRepository = iCurrentAffairsRepository;
        }

        public async Task<GetResponse<GetCurrentAffairsModel>> GetById(long id)
        {
            List<Dictionary<string, object>> result = await _iCurrentAffairsRepository.GetById(id);
            CurrentAffairs? currentaffairs = result
                .Select(static row => DataMapperExtensions.MapRowToModel<CurrentAffairs>(row))
                .FirstOrDefault();
            if (currentaffairs == null)
            {
                return new GetResponse<GetCurrentAffairsModel>()
                {
                    Code = 200,
                    Success = true,
                    Message = "No record found",
                };
            }
            GetCurrentAffairsModel response = await _mapper.CreateMap<GetCurrentAffairsModel, CurrentAffairs>(currentaffairs);
            return new GetResponse<GetCurrentAffairsModel>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Data = response,
            };
        }

        public async Task<CollectionResponse<CurrentAffairsModelCollection>> GetAll()
        {
            List<Dictionary<string, object>> result = await _iCurrentAffairsRepository.GetAll();
            List<CurrentAffairs> currentaffairs = result
                .Select(static row => DataMapperExtensions.MapRowToModel<CurrentAffairs>(row))
                .ToList();
            CurrentAffairsModelCollection collection = await _mapper.CreateMap<
                CurrentAffairsModelCollection,
                List<CurrentAffairs>
            >(currentaffairs);
            return new CollectionResponse<CurrentAffairsModelCollection>()
            {
                Code = 200,
                Success = true,
                Message = "Get successfully.",
                Record = new() { Count = collection.Count, Data = collection },
            };
        }

        public async Task<CurrentAffairsModelCollection> GetFilter(PaginationModel paginationModel)
        {
            Pagination pagination = await _mapper.CreateMap<Pagination, PaginationModel>(
                paginationModel
            );
            List<Dictionary<string, object>> result = await _iCurrentAffairsRepository.GetFilter(pagination);
            List<CurrentAffairs> currentaffairs = result
                .Select(static row => DataMapperExtensions.MapRowToModel<CurrentAffairs>(row))
                .ToList();
            CurrentAffairsModelCollection collection = await _mapper.CreateMap<
                CurrentAffairsModelCollection,
                List<CurrentAffairs>
            >(currentaffairs);
            return collection;
        }

        public async Task<Response> Insert(CurrentAffairsModel currentaffairsModel)
        {
            CurrentAffairs currentaffairs = await _mapper.CreateMap<CurrentAffairs, CurrentAffairsModel>(currentaffairsModel);
            bool success = await _iCurrentAffairsRepository.Insert(currentaffairs);
            if (success)
            {
                return new Response()
                {
                    Code = 200,
                    Success = true,
                    Message = "CurrentAffairs inserted successfully.",
                };
            }
            return new Response()
            {
                Code = 200,
                Success = false,
                Message = "CurrentAffairs inserted failed.",
            };
        }

        public async Task<string> Update(CurrentAffairsModel currentaffairsModel)
        {
            CurrentAffairs currentaffairs = await _mapper.CreateMap<CurrentAffairs, CurrentAffairsModel>(currentaffairsModel);
            bool success = await _iCurrentAffairsRepository.Update(currentaffairs);
            if (success)
                return "CurrentAffairs updated successfully.";
            else
                return "CurrentAffairs update failed.";
        }

        public async Task<string> Delete(long id)
        {
            try
            {
                bool deleted = await _iCurrentAffairsRepository.Delete(id);
                if (deleted)
                    return "CurrentAffairs deleted successfully.";
                else
                    return "CurrentAffairs not found.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<Response> SetActiveStatus(long id)
        {
            try
            {
                bool result = await _iCurrentAffairsRepository.SetActiveStatus(id);

                if (result)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Current Affair status updated to active.",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Current Affairs entry not found",
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
                bool result = await _iCurrentAffairsRepository.SetInActiveStatus(id);

                if (result)
                {
                    return new Response
                    {
                        Code = 200,
                        Message = "Current Affair status updated to inactive",
                        Success = true
                    };
                }
                else
                {
                    return new Response
                    {
                        Code = 404,
                        Message = "Current Affairs entry not found",
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
